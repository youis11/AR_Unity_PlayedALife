Shader "Anime/Anime-Shade" {
    Properties {
    	[Header(Main Settting)]
        _Color ("Main Color", Color) = (0.5,0.5,0.5,1)
        _Shade ("Shade Control", Range (1.0,10.0)) = 1.0
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _CutoffA ("Shadow Texture Cutoff", Range (0,1)) = 0.5
        _Cutoff ("Cutoff", Range (0,1)) = 0.5
        _CutoffRange ("Cutoff Range", Range (0,1)) = 0.1
        
        _BumpMap ("Normalmap", 2D) = "bump" {}
        _BumpMapRange ("Normal Map Range", Range (1,100)) = 1.0
        _Ramp ("Toon Ramp (RGB)", 2D) = "gray" {}
        
//        [Header(Control Cell Outline)]
//        _OutlineColor ("Outline Color", Color) = (0,0,0,1)
//		_Outline ("Outline width", Range (0.002, 0.03)) = 0.005
        

        
        _ShadowCutoff ("Shadow Cutoff", Range (0,1)) = 0.5
        _ShadowCutoffRange ("Shadow Cutoff Range", Range (0,1)) = 0.1
    }
 
    SubShader {
   
        //Cull Off
        Tags { "RenderType"="Opaque" }
        LOD 200
        //UsePass "Toon/Basic Outline/OUTLINE"
       //AlphaTest LEqual [_Cutoff]
        Blend SrcAlpha OneMinusSrcAlpha
        
    CGPROGRAM
    #pragma surface surf ToonRamp alphatest:_CutOff noambient addshadow
 
    sampler2D _Ramp;
 	fixed4 e;
 	fixed4 c;
 	sampler2D _MainTex;
    fixed4 _Color;
    fixed _Shade;
    
    half _ShadowCutoff;
    half _ShadowCutoffRange;
    
    half _Cutoff;
    half _CutoffRange;
    sampler2D _BumpMap;
    fixed _BumpMapRange;
    
    // custom lighting function that uses a texture ramp based
    // on angle between light direction and normal
    #pragma lighting ToonRamp alphatest:_CutOff noambient addshadow
    half4 LightingToonRamp (SurfaceOutput s, half3 lightDir, half atten)
    {
       // #ifndef USING_DIRECTIONAL_LIGHT
        lightDir = normalize(lightDir);
       // #endif
     
     	//s.Normal = e.rgb;
        half d = (dot (s.Normal, lightDir)*0.5 + 0.5) * -atten ;
        half3 ramp = tex2D (_Ramp, float2(d,d)).rgb;
     
        c.rgb = s.Albedo * _LightColor0.rgb * ramp;
        half r = _ShadowCutoff * (1 + _ShadowCutoffRange * 2) - _ShadowCutoffRange;
        c.a = ((ramp - r) * (1 / (_ShadowCutoffRange)));
        return c;
    }
 
    struct Input {
        float2 uv_MainTex : TEXCOORD0;
    };
 
    void surf (Input IN, inout SurfaceOutput o) {
        e = tex2D(_MainTex, IN.uv_MainTex) * _Color;
        half d = tex2D (_MainTex, IN.uv_MainTex).r;
        
        o.Albedo = e.rgb * 1.5;
        o.Albedo *= e.rgb;
        o.Albedo *= e.rgb;
        o.Albedo *= e.rgb;
        o.Albedo *= _Shade;
        half r = _Cutoff * (1 + _CutoffRange * 2) - _CutoffRange;
        o.Alpha = (d - r) * (1 / (_CutoffRange));
        fixed3 normala = UnpackNormal(tex2D(_BumpMap, IN.uv_MainTex)); 
        normala.z = normala.z/_BumpMapRange; 
        o.Normal = normalize(normala);
        //o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_MainTex));
    }
    ENDCG
        
    CGPROGRAM
    #pragma surface surf ToonRamp alphatest:_CutOff noambient addshadow
 
    sampler2D _Ramp;
 	fixed4 e;
 	fixed4 c;
 	sampler2D _MainTex;
    fixed4 _Color;
    
    half _ShadowCutoff;
    half _ShadowCutoffRange;
    
    half _Cutoff;
    half _CutoffRange;
    sampler2D _BumpMap;
    fixed _BumpMapRange;
    
    // custom lighting function that uses a texture ramp based
    // on angle between light direction and normal
    #pragma lighting ToonRamp alphatest:_CutOff noambient addshadow
    half4 LightingToonRamp (SurfaceOutput s, half3 lightDir, half atten)
    {
        //#ifndef USING_DIRECTIONAL_LIGHT
        lightDir = normalize(lightDir);
        //#endif
     
     	//s.Normal = e.rgb;
        half d = (dot (s.Normal, lightDir)*0.5 + 0.5) * atten;
        half3 ramp = tex2D (_Ramp, float2(d,d)).rgb;
     
        c.rgb = s.Albedo * _LightColor0.rgb * ramp;
        half r = _ShadowCutoff * (1 + _ShadowCutoffRange * 2) - _ShadowCutoffRange;
        c.a = ((ramp - r) * (1 / (_ShadowCutoffRange)));
        return c;
    }
 
    struct Input {
        float2 uv_MainTex : TEXCOORD0;
    };
 
    void surf (Input IN, inout SurfaceOutput o) {
        e = tex2D(_MainTex, IN.uv_MainTex) * _Color;
        half d = tex2D (_MainTex, IN.uv_MainTex).r;
        
        o.Albedo = e.rgb;
        half r = _Cutoff * (1 + _CutoffRange * 2) - _CutoffRange;
        o.Alpha = (d - r) * (1 / (_CutoffRange));
        fixed3 normala = UnpackNormal(tex2D(_BumpMap, IN.uv_MainTex)); 
        normala.z = normala.z/_BumpMapRange; 
        o.Normal = normalize(normala);
        //o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_MainTex));
    }
    ENDCG
    }
    
    Fallback "VertexLit"
}
