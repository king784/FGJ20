Shader "Custom/WaterPipe"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _GradientTex("Gradient Texture", 2D) = "" {}
        _WaterValue ("Water value", Range(0.0, 1.0)) = 0.5
        _Direction ("Direction", Int) = 0
    }
    SubShader
    {
        Tags 
        {
            "Queue"="Transparent" 
            "RenderType"="Transparent" 
        }
        Blend SrcAlpha OneMinusSrcAlpha
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float4 color : COLOR;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                fixed4 color : COLOR;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            sampler2D _GradientTex;
            float4 _MainTex_ST;
            float _WaterValue;
            int _Direction;


            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.color = v.color;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                fixed4 gradCol = tex2D(_GradientTex, i.uv);
                if(_Direction == 0)
                {
                    if(gradCol.r > _WaterValue)
                    {
                        col.b *= 3.0;
                    }
                }
                else if(_Direction == 1)
                {
                    if(gradCol.r > 1-_WaterValue)
                    {
                        col.b *= 3.0;
                    }
                }
                return col;
            }
            ENDCG
        }
    }
}
