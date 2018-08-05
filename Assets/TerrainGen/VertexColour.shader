// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:8585,x:33002,y:32916,varname:node_8585,prsc:2|emission-5078-OUT;n:type:ShaderForge.SFN_VertexColor,id:3251,x:32230,y:32781,varname:node_3251,prsc:2;n:type:ShaderForge.SFN_Tex2d,id:6477,x:32198,y:32946,ptovrint:False,ptlb:1,ptin:_1,varname:node_6477,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:726711a7df5af28468587ac56f43ecc7,ntxv:3,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:9613,x:32198,y:33144,ptovrint:False,ptlb:2,ptin:_2,varname:node_9613,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:978867c9a0124a244b18bcd00f4ba763,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:7535,x:32198,y:33334,ptovrint:False,ptlb:3,ptin:_3,varname:_77de_6478,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:5152d951bf09f054ea58f579d5f1b699,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Multiply,id:9645,x:32468,y:32947,varname:node_9645,prsc:2|A-6477-RGB,B-3251-R;n:type:ShaderForge.SFN_Multiply,id:8790,x:32468,y:33144,varname:node_8790,prsc:2|A-9613-RGB,B-3251-G;n:type:ShaderForge.SFN_Multiply,id:9161,x:32468,y:33326,varname:node_9161,prsc:2|A-7535-RGB,B-3251-B;n:type:ShaderForge.SFN_Add,id:4696,x:32692,y:33022,varname:node_4696,prsc:2|A-9645-OUT,B-8790-OUT;n:type:ShaderForge.SFN_Add,id:5078,x:32766,y:33183,varname:node_5078,prsc:2|A-4696-OUT,B-9161-OUT;proporder:6477-9613-7535;pass:END;sub:END;*/

Shader "Custom/VertexColour" {
    Properties {
        _1 ("1", 2D) = "bump" {}
        _2 ("2", 2D) = "black" {}
        _3 ("3", 2D) = "black" {}
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        LOD 200
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _1; uniform float4 _1_ST;
            uniform sampler2D _2; uniform float4 _2_ST;
            uniform sampler2D _3; uniform float4 _3_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 _1_var = tex2D(_1,TRANSFORM_TEX(i.uv0, _1));
                float3 node_9645 = (_1_var.rgb*i.vertexColor.r);
                float4 _2_var = tex2D(_2,TRANSFORM_TEX(i.uv0, _2));
                float3 node_8790 = (_2_var.rgb*i.vertexColor.g);
                float4 _3_var = tex2D(_3,TRANSFORM_TEX(i.uv0, _3));
                float3 node_9161 = (_3_var.rgb*i.vertexColor.b);
                float3 emissive = ((node_9645+node_8790)+node_9161);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
