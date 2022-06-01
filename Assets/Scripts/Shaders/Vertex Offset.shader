Shader "Unlit/Vertex Offset"
{
    Properties
    {
        // input data
        _ColorA("Color", Color) = (1,1,1,1)// a property that will be visible and editable in the inspector
        _ColorB("Color", Color) = (1,1,1,1)
        _ColorStart("Color Start", Range(0,1) ) = 0
        _ColorEnd("Color End", Range(0,1) ) = 1
        _WaveAmplitude("Wave Amplitude", Range(0,1)) = 0.1

        _Scale ("UV Scale", float) = 1
        _Offset ("Offset", float) = 0
    }
    SubShader
    { 
        // subshader tags
        Tags { "RenderType" = "Opaque" 
               "Queue" = "Geometry"
             }

        Pass
        {
            // pass tags
            //Cull Off
            // ZWrite Off
            //ZTest Always
            // Blend One One // additive
            // Blend DstColor Zero // multiply

            CGPROGRAM
            #pragma vertex vert // a way of telling the compiler what function to use for vertex & frag e.g. vertex "name of function to be used"
            #pragma fragment frag

            #include "UnityCG.cginc" // takes code from different files to use in the shader

            #define TAU 6.29318530718

            float4 _ColorA; // to use a property we must declare it here
            float4 _ColorB; // to use a property we must declare it here
            float _ColorStart;
            float _ColorEnd;
            float _WaveAmplitude;
            //float _Scale;
            //float _Offset;

            struct MeshData // per-vertex mesh data
            {
                // name of variable doesn't matter
                // ":" is called a symantic, it tells the compiler that we want the following data (e.g. POSITION) passed into the variable
                // generally going to use uv coordinates, position, normals
                // can also get vertex colour and tangent
                float3 normals : NORMAL; // local normal space direction
                //float4 tangent : TANGENT; // tangent direction (xyz) tangent sign (w)
                //float4 colour : COLOR; // vertex colors
                float4 vertex : POSITION; // vertex position
                float2 uv0 : TEXCOORD0; // uv0 diffuse/normal map textures
                float2 uv1 : TEXCOORD1; // uv1 lightmap coordinates
                // you don't need to use uv coordinates to use textures

            };

            struct v2f // interpolator
            {
                float4 vertex : SV_POSITION; // clip space position
                float3 normal : TEXCOORD0;
                float2 uv : TEXCOORD1;
                // float2 uv : TEXCOORD0; // any data you want it to be, in this case, this
            };

            float GetWave(float2 uv)
            {
                float2 uvsCentered = uv * 2 - 1;
                float radialDistance = length(uvsCentered); // *_WaveAmplitude;
                float wave = cos((radialDistance - _Time.y * 0.1f) * TAU * 5) * 0.5 + 0.5;
                wave *= 1 - radialDistance;
                return wave;
            }

            v2f vert (MeshData v) // vertex shader
            {
                v2f o; // o means output

                //float wave = cos((v.uv0.y - _Time.y * 0.1f) * TAU * 5);
                //float wave2 = cos((v.uv0.x - _Time.y * 0.1f) * TAU * 5);
                //v.vertex.y = wave * wave2 *_WaveAmplitude;

                v.vertex.y = GetWave(v.uv0)* _WaveAmplitude;

                o.vertex = UnityObjectToClipPos(v.vertex); // converts local space to clip space
                o.normal = UnityObjectToWorldNormal(v.normals); // just pass through'
                o.uv = v.uv0; //(v.uv0+_Offset) * _Scale; // passthrough
                return o;
            }

            // int gets converted to floating point anyway
            // float4 == vector4 (32 bit float) float works well for world space
            // half (16 bit float) pretty good for most things
            // fixed (lower precision) only useful in -1 to 1 range
            // float4 -> half4 -> fixed4
            // float4x4 -> half4x4 -> fixed4x4 (c# matrix 4x4)
            // lower precision is faster

            float InverseLerp(float a, float b, float v)
            {
                return (v - a) / (b - a);
            }

            float4 frag(v2f i) : SV_Target // symantic tells us that this fragment shader should output to frame buffer, writing to the target
            {
                // Swizzling is casting a value into another value
                // you can flip the indexes as well, e.g. flipping G & R will allow you to use green value in red

                //float4 myValue;
                //float2 otherValue = myValue.xy
                //t = frac(t); // shows when there are values that are not clamped
                ///float t = saturate (InverseLerp(_ColorStart, _ColorEnd, i.uv.x));

                // return outColor;
                //return t;
                return GetWave(i.uv);
            }
            ENDCG
        }
    }
}
