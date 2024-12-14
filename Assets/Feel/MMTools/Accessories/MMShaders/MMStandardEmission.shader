Shader "MoreMountains/MMControlledEmission"
{
    Properties
    {
        _TextureSample0("Texture Sample 0", 2D) = "white" {}
        _DiffuseColor("DiffuseColor", Color) = (1,1,1,1)
        _Opacity("Opacity", Range(0, 1)) = 1
        [HDR]_EmissionColor("EmissionColor", Color) = (1,1,1,1)
        _EmissionForce("EmissionForce", Float) = 0
        _UseEmissionFresnel("UseEmissionFresnel", Float) = 0
        _EmissionFresnelBias("EmissionFresnelBias", Float) = 1
        _EmissionFresnelScale("EmissionFresnelScale", Float) = 1
        _EmissionFresnelPower("EmissionFresnelPower", Float) = 1
        _UseOpacityFresnel("UseOpacityFresnel", Float) = 0
        _InvertOpacityFresnel("InvertOpacityFresnel", Float) = 0
        _OpacityFresnelBias("OpacityFresnelBias", Float) = 1
        _OpacityFresnelScale("OpacityFresnelScale", Float) = 1
        _OpacityFresnelPower("OpacityFresnelPower", Float) = 1
    }

    SubShader
    {
        Tags
        {
            "RenderType" = "Transparent"
            "Queue" = "Transparent+0"
            "IgnoreProjector" = "True"
            "IsEmissive" = "true"
        }

        Pass
        {
            Name "ForwardBase"
            Tags { "LightMode" = "ForwardBase" }

            CGPROGRAM
            #include "UnityPBSLighting.cginc"
            #include "Lighting.cginc"
            #pragma surface surf Standard alpha:fade keepalpha fullforwardshadows
            #pragma shader_feature _USEEMISSIONFRESNEL
            #pragma shader_feature _USEOPACITYFRESNEL
            #pragma shader_feature _INVERTOPACITYFRESNEL
            #pragma target 3.0

            struct Input
            {
                float2 uv_texcoord : TEXCOORD0;
                float3 worldPos : TEXCOORD1;
                float3 worldNormal : TEXCOORD2;
            };

            // Propiedades uniformes
            uniform sampler2D _TextureSample0;
            uniform float4 _TextureSample0_ST;
            uniform float4 _DiffuseColor;
            uniform float _Opacity;
            uniform float _EmissionForce;
            uniform float4 _EmissionColor;
            uniform float _EmissionFresnelBias;
            uniform float _EmissionFresnelScale;
            uniform float _EmissionFresnelPower;
            uniform float _OpacityFresnelBias;
            uniform float _OpacityFresnelScale;
            uniform float _OpacityFresnelPower;

            void surf(Input i, inout SurfaceOutputStandard o)
            {
                // Transformar las coordenadas de la textura con el tile y el offset
                float2 uv_TextureSample0 = i.uv_texcoord * _TextureSample0_ST.xy + _TextureSample0_ST.zw;
                o.Albedo = tex2D(_TextureSample0, uv_TextureSample0).rgb * _DiffuseColor.rgb;

                // Calcular Fresnel para la emisión
                float3 viewDir = normalize(UnityWorldSpaceViewDir(i.worldPos));
                float3 normal = normalize(i.worldNormal);
                float fresnelNdotV = dot(normal, viewDir);
                float fresnelFactor = (_EmissionFresnelBias + _EmissionFresnelScale * pow(1.0 - fresnelNdotV, _EmissionFresnelPower));

                // Si se usa fresnel para emisión
                #if defined(_USEEMISSIONFRESNEL)
                    o.Emission = _EmissionForce * _EmissionColor.rgb * fresnelFactor;
                #else
                    o.Emission = _EmissionForce * _EmissionColor.rgb;
                #endif

                // Calcular Fresnel para la opacidad
                float opacityFresnel = (_OpacityFresnelBias + _OpacityFresnelScale * pow(1.0 - fresnelNdotV, _OpacityFresnelPower));

                // Si se invierte la opacidad
                #if defined(_INVERTOPACITYFRESNEL)
                    opacityFresnel = 1.0 - opacityFresnel;
                #endif

                // Si se usa fresnel para opacidad
                #if defined(_USEOPACITYFRESNEL)
                    o.Alpha = opacityFresnel * _Opacity * _DiffuseColor.a;
                #else
                    o.Alpha = _Opacity * _DiffuseColor.a;
                #endif
            }
            ENDCG
        }
    }

    Fallback "Diffuse"
}
