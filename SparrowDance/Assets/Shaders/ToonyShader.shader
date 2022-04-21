// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'
Shader "Unlit/ToonyShader"
{ Properties
    {
        _MainTex ("Texture", 2D) = "white" {} //main albedo - this is the img
        _LightColor("Light Color", Color) = (1,1,1,1)  //highlight
        _DarkColor("Dark Color", Color) = (1,1,1,1)  //shadow
        _Threshold1("Threshold 1", Range(0, 1)) = 0.33 //light threshold for the highlight
        _Threshold2("Threshold 2", Range(0, 1)) = 0.66 //light threshold for the shadow
        
        _OutlineColor("Outline Color", Color)=(1,1,1,1)
        _OutlineSize("OutlineSize", Range(0.0,0.5))=0.025
        _OutlineTexture("OutlineTexture", 2D) = "black" {} //this is the texture (pencil!) of the outline
        _DisplAmount("Displacement Amount", Range(0, 1)) = 1
        _Start ("Start", Range(0, 0.5)) = 0.1
        _Inner ("Inner", Range(0, 0.5)) = 0.2
        _Outer ("Outer", Range(0, 0.5)) = 0.22
        _End ("End", Range(0, 0.5)) = 0.3
    }
    SubShader
    {
    Tags { "RenderType"="Transparent" "Queue"="Transparent" "IgnoreProjector"="True" }
                LOD 100
                Blend SrcAlpha OneMinusSrcAlpha 
        Pass
        {
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            // make fog work
            #pragma multi_compile_fog
            #include "UnityCG.cginc"
           struct appdata
            {
                float4 vertex : POSITION;
                float2 uv_MainTex : TEXCOORD1;
                float3 normal : NORMAL;
            };
 
            struct v2f
            {
                UNITY_FOG_COORDS(1)
                float2 uv_MainTex : TEXCOORD1;
                float4 vertex : SV_POSITION;
                float lightDot : TEXCOORD0;
                
            };
        
            
            struct Input {
                float2 uv_MainTex : TEXCOORD1;
            };
            sampler2D _MainTex;
            fixed4 _LightColor;
            fixed4 _DarkColor;
 
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                half3 normal = normalize(mul(unity_ObjectToWorld, half4(v.normal, 0))).xyz;
                half lightDot = clamp(dot(normal, normalize(_WorldSpaceLightPos0)), -1.0, 1.0);
                o.lightDot = (lightDot + 1) / 2; 
                UNITY_TRANSFER_FOG(o,o.vertex);
                o.uv_MainTex = v.uv_MainTex;
                return o;
            }
             
            float _Threshold1; //this is supposed to be the overlay color for the highlights
            float _Threshold2; //this is the overlay color for the shadows
         
 
            fixed4 frag (v2f i, Input IN) : SV_Target
            {
                fixed4 col;
                fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
                if (i.lightDot > 0 && i.lightDot < _Threshold1) col = c * _DarkColor;
                else if (i.lightDot > _Threshold1 && i.lightDot < _Threshold2) col = c  * _LightColor;
                else col = c;
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
        Pass
        {
            Tags { "RenderType"="Transparent" "Queue"="Transparent" "IgnoreProjector"="True" }
            LOD 100
            Blend SrcAlpha OneMinusSrcAlpha 
            Cull front    
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            fixed4 _OutlineColor;
            float _OutlineSize;
            sampler2D _OutlineTexture;
            sampler2D _DisplTex;
            float _DisplAmount;
            float _Start;
            float _End;
            float _Inner;
            float _Outer;
            
           struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 uv_OutlineTexture : TEXCOORD2;
            };
 
            struct v2f
            {
                float4 position : SV_POSITION;
                float2 uv_OutlineTexture : TEXCOORD2;
                
            };
        
            struct Input {
                float2 uv_OutlineTexture : TEXCOORD2;
            };
            fixed4 singleSmoothstep(float _Start, float _End, v2f i) 
            {
                return smoothstep(_Start, _Inner, length(i.uv_OutlineTexture - 0.5));
            }
            fixed4 doubleSmoothstep(float _Start, float _End, float _Inner, float _Outer, v2f i) 
            {
            //smooths the shader edges so it's less jarring
                float value = smoothstep(_Start, _Inner, length(i.uv_OutlineTexture - 0.5));
                float value2 = smoothstep(_Outer, _End, length(i.uv_OutlineTexture - 0.5));
                return singleSmoothstep(value,value2,i);
            }
            
            v2f vert (appdata v)
            {
                v2f o;
                float3 normal = normalize(v.normal);
                float phase = _Time * 100.0;
                float3 wiggle = sin(phase * v.uv_OutlineTexture.xyx) * _DisplAmount ;
  
  //wiggling is here!!
  //wiggle is a sin wave * the disp Amount
  //added to the outline offset
  
                float3 outlineOffset = normal * (_OutlineSize + wiggle) ;
                float3 position = v.vertex + outlineOffset;
                o.uv_OutlineTexture = v.uv_OutlineTexture;
                o.position = UnityObjectToClipPos(position);
                return o;
            }
       
 
            fixed4 frag (v2f i, Input IN) : SV_Target
            {
                fixed4 col;
                fixed4 c = tex2D(_OutlineTexture, IN.uv_OutlineTexture ) ;
                col = c * doubleSmoothstep(_Start, _End,_Inner,_Outer, i) * _OutlineColor;
              
                //col = c* singleSmoothstep(_Start, _End, i);
                return col;
            }
            ENDCG
        }
 
    }
    Fallback "Standard"
}
