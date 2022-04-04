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
            Cull front    
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            fixed4 _OutlineColor;
            float _OutlineSize;
            sampler2D _OutlineTexture;
            
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
                float2 uv_MainTex : TEXCOORD1;
                float2 uv_OutlineTexture : TEXCOORD2;
            };
            
            v2f vert (appdata v)
            {
                v2f o;
                float3 normal = normalize(v.normal);
                float3 outlineOffset = normal * _OutlineSize;
                float3 position = v.vertex + outlineOffset;
                o.uv_OutlineTexture = v.uv_OutlineTexture;
                o.position = UnityObjectToClipPos(position);
     
                return o;
            }
       
 
            fixed4 frag (v2f i, Input IN) : SV_Target
            {
                fixed4 col;
                fixed4 c = tex2D(_OutlineTexture, IN.uv_OutlineTexture);
                col = c * _OutlineColor;
                return col;
            }
            ENDCG
        }
        
        
    }
    Fallback "Standard"
}
