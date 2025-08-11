Shader "Custom/WhiteNoise"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _NoiseSpeed ("Noise Speed", Float) = 1.0
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" } // Change to Transparent
        LOD 100
        Blend SrcAlpha OneMinusSrcAlpha // Add this line

        CGPROGRAM
        #pragma surface surf Standard alpha:fade // Enable alpha blending
        #pragma target 3.0

        struct Input
        {
            float2 uv_MainTex;
        };

        sampler2D _MainTex; // Add this line
        fixed4 _Color;
        float _NoiseSpeed;

        float rand(float2 co)
        {
            return frac(sin(dot(co.xy, float2(12.9898,78.233))) * 43758.5453);
        }


        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            float t = _Time.y * _NoiseSpeed;
            float noise = rand(IN.uv_MainTex * 100 + t);
            fixed4 tex = tex2D(_MainTex, IN.uv_MainTex);
            float3 noiseColor = float3(noise, noise, noise);
            o.Albedo = lerp(tex.rgb, noiseColor, 0.7) * _Color.rgb; // 0.7 = more noise, less texture
            o.Metallic = 0;
            o.Smoothness = 0;
            o.Alpha = _Color.a * max(tex.a, 0.1); // Avoid full transparency
        }

        ENDCG
    }
    FallBack "Diffuse"
}