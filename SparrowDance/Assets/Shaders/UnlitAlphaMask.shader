Shader "Unlit/UnlitAlphaMask"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Alpha ("Alpha (A)", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType" = "Transparent" "Queue" = "Transparent"}
    
        LOD 100

        ZWrite Off
       
        Blend SrcAlpha OneMinusSrcAlpha
        ColorMask RGB

       Pass {
                   SetTexture[_MainTex] {
                       Combine texture
                   }
                   SetTexture[_Alpha] {
                       Combine previous, texture
                   }
              }
               
    }
}
