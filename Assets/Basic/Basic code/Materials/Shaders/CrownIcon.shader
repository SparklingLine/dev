// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:1,cusa:True,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:True,tesm:0,olmd:1,culm:2,bsrc:0,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:1873,x:33229,y:32719,varname:node_1873,prsc:2|emission-8863-OUT,alpha-4004-OUT;n:type:ShaderForge.SFN_Tex2d,id:4677,x:32523,y:32628,ptovrint:False,ptlb:CrownFillTexture,ptin:_CrownFillTexture,varname:node_4677,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:3bf6142858a22484cb94550d38c72272,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Add,id:8863,x:33059,y:32818,varname:node_8863,prsc:2|A-5493-OUT,B-9468-OUT;n:type:ShaderForge.SFN_Tex2d,id:3317,x:32682,y:32888,ptovrint:False,ptlb:CrownOutTexture,ptin:_CrownOutTexture,varname:node_3317,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:5e418d1771a27da489d50c9a43272d04,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:9368,x:32725,y:32645,varname:node_9368,prsc:2|A-4677-RGB,B-4677-A;n:type:ShaderForge.SFN_Multiply,id:9468,x:32864,y:32858,varname:node_9468,prsc:2|A-3317-RGB,B-3317-A;n:type:ShaderForge.SFN_Slider,id:7973,x:32555,y:32798,ptovrint:False,ptlb:233,ptin:_233,varname:node_7973,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Multiply,id:5493,x:32880,y:32684,varname:node_5493,prsc:2|A-9368-OUT,B-7973-OUT;n:type:ShaderForge.SFN_Vector1,id:4004,x:32976,y:33001,varname:node_4004,prsc:2,v1:0;proporder:4677-3317-7973;pass:END;sub:END;*/

Shader "Shader Forge/Crown" {
    Properties {
        _CrownFillTexture ("CrownFillTexture", 2D) = "white" {}
        _CrownOutTexture ("CrownOutTexture", 2D) = "white" {}
        _233 ("233", Range(0, 1)) = 1
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
        [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
            "CanUseSpriteAtlas"="True"
            "PreviewType"="Plane"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One OneMinusSrcAlpha
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #pragma multi_compile _ PIXELSNAP_ON
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _CrownFillTexture; uniform float4 _CrownFillTexture_ST;
            uniform sampler2D _CrownOutTexture; uniform float4 _CrownOutTexture_ST;
            uniform float _233;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                #ifdef PIXELSNAP_ON
                    o.pos = UnityPixelSnap(o.pos);
                #endif
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
////// Lighting:
////// Emissive:
                float4 _CrownFillTexture_var = tex2D(_CrownFillTexture,TRANSFORM_TEX(i.uv0, _CrownFillTexture));
                float4 _CrownOutTexture_var = tex2D(_CrownOutTexture,TRANSFORM_TEX(i.uv0, _CrownOutTexture));
                float3 emissive = (((_CrownFillTexture_var.rgb*_CrownFillTexture_var.a)*_233)+(_CrownOutTexture_var.rgb*_CrownOutTexture_var.a));
                float3 finalColor = emissive;
                return fixed4(finalColor,0.0);
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #pragma multi_compile _ PIXELSNAP_ON
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = UnityObjectToClipPos( v.vertex );
                #ifdef PIXELSNAP_ON
                    o.pos = UnityPixelSnap(o.pos);
                #endif
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
