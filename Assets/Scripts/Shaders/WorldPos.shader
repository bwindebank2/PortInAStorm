Shader "Unlit/WorldPos"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float3 worldPos : TEXCOORD1;

            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float3 worldPos : TEXCOORD1;

            };

            sampler2D _MainTex;
            float4 _MainTex_ST; // optional (tiling and offset)

            v2f vert (appdata v)
            {
                v2f o;
                o.worldPos = mul(UNITY_MATRIX_M, float4(v.vertex.xyz, 1) );
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex); // takes offset values and offsets input uv coords
                o.uv.x += _Time.y * 0.1;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                return float4(i.worldPos.xyz, 1);

                float4 col = tex2D(_MainTex, i.uv);
                return col;

            }
            ENDCG
        }
    }
}
