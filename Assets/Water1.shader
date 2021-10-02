Shader "Custom/Water1"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
        _AltTex("Alt Texture", 2D) = "white" {}
        _Noise("Noise", 2D) = "white" {}
        _Speed("Speed", Float) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;
        sampler2D _AltTex;
        sampler2D _Noise;
        float _Speed;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            float2 originPos = IN.uv_MainTex;
            originPos.x += _Time[0] * _Speed;
            originPos.y += _Time[0] * _Speed;
            fixed4 col = tex2D (_MainTex, originPos) * _Color;
            float2 pos = IN.uv_MainTex;
            pos.x += tex2D(_Noise, float2(originPos.x + _Time[0] * _Speed, originPos.y - _Time[0] * _Speed)).r;
            pos.y += tex2D(_Noise, float2(originPos.y + 42 - _Time[0] * _Speed, originPos.x + 76 + _Time[0] * _Speed)).r;
            fixed4 altCol = tex2D(_AltTex, pos);
            fixed4 c = tex2D(_MainTex, originPos) * _Color;
            if (altCol.r > 0)
            {
                c.r += 0.2f;
                c.g += 0.2f;
                c.b += 0.2f;
            }
            else
            {
                c.r = 1;
            }
            o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = col.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
