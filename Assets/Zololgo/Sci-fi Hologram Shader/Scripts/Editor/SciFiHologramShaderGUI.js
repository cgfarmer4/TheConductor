
class SciFiHologramShaderGUI extends ShaderGUI
{
	var editor : MaterialEditor;
	var properties : MaterialProperty[];
	var material : Material;
	
    function OnGUI (editor : MaterialEditor, properties : MaterialProperty[])
	{
		var tempGUIColor : Color = GUI.color;
		this.editor = editor;
		this.properties = properties;
		this.material = editor.target as Material;
		//
		// general settings
		GUILayout.Label("General settings", EditorStyles.boldLabel);
		EditorGUI.indentLevel += 2;	
		editor.RangeProperty(GetProp("_Brightness"), "Brightness");	
		editor.RangeProperty(GetProp("_Fade"), "Fade");
		EditorGUI.indentLevel -= 2;	
		// rim light settings
		GUILayout.Label("Rim light settings", EditorStyles.boldLabel);
		EditorGUI.indentLevel += 2;	
		editor.ColorProperty(GetProp("_RimColor"), "Tint");	
		editor.RangeProperty(GetProp("_RimStrenght"), "Strength");
		editor.RangeProperty(GetProp("_RimFalloff"), "Falloff");
		EditorGUI.indentLevel -= 2;
		// main settings
		GUILayout.Label("\nMain texture", EditorStyles.boldLabel);
		EditorGUI.indentLevel += 2;	
		editor.ColorProperty(GetProp("_Color"), "Tint");	 
		EditorGUI.indentLevel -= 2;	
		editor.TexturePropertySingleLine(GUIContent("Texture",""), GetProp("_MainTex"));
		TextureUVTransformProperty(GetProp("_MainTex"));
		// scanlines
		GUILayout.Label("\nEffects", EditorStyles.boldLabel);
		editor.TexturePropertySingleLine(GUIContent("Scanlines",""), GetProp("_Scanlines"));
		editor.RangeProperty(GetProp("_ScanStr"), "Strength");	
		TextureUVTransformProperty(GetProp("_Scanlines"), "Scale", "Speed"); 		
		// scanlines #2
		ToggleVariant("Enable more scanlines", "SCAN2_ON", "SCAN2_OFF");
		if (IsKeyword("SCAN2_OFF")) GUI.color = Color(tempGUIColor.r,tempGUIColor.g,tempGUIColor.b,0.25);
		editor.TexturePropertySingleLine(GUIContent("Scanlines",""), GetProp("_Scan2"));
		editor.RangeProperty(GetProp("_ScanStr2"), "Strength");	
		TextureUVTransformProperty(GetProp("_Scan2"), "Scale", "Speed"); 
		GUI.color = tempGUIColor;
	}

	function IsKeyword(s : String) : boolean
	{
		var keywords : String[] = material.shaderKeywords;
		return System.Array.IndexOf(keywords,s) != -1;
	}
	
	function ToggleVariant(d : String, on : String, off : String)
	{
		var toggle : boolean = IsKeyword(on);
		EditorGUI.BeginChangeCheck ( );
		GUILayout.Space(10);
		toggle = EditorGUILayout.Toggle (d, toggle);
		if (EditorGUI.EndChangeCheck ( ))
		{
			var newKeywords : String[] = new String[0];
			newKeywords += [toggle ? on : off];
			material.shaderKeywords = newKeywords;
			EditorUtility.SetDirty (material);
		}
	}
	
	function GetProp (propName : String) : MaterialProperty
	{
		return FindProperty(propName, properties);
	}	

	function TextureUVTransformProperty(uvTransformProperty : MaterialProperty) : Vector4
	{
		TextureUVTransformProperty(uvTransformProperty, "Tiling", "Offset");
	}
	function TextureUVTransformProperty(uvTransformProperty : MaterialProperty, firstText : String, secondText : String) : Vector4
	{
		var position : Rect = EditorGUILayout.GetControlRect(true, 32.0, EditorStyles.layerMaskField, new GUILayoutOption[0]);
		var uvTransform : Vector4 = uvTransformProperty.textureScaleAndOffset;
		var value : Vector2 = new Vector2(uvTransform.x, uvTransform.y);
		var value2 : Vector2 = new Vector2(uvTransform.z, uvTransform.w);
		var num : float = EditorGUIUtility.labelWidth;
		var x : float = position.x + num;
		var x2 : float = position.x + 30;
		var totalPosition : Rect = new Rect(x2, position.y, EditorGUIUtility.labelWidth, 16.0);
		var position2 : Rect = new Rect(x, position.y, position.width - EditorGUIUtility.labelWidth, 16.0);
		EditorGUI.PrefixLabel(totalPosition, GUIContent(firstText));
		value = EditorGUI.Vector2Field(position2, GUIContent.none, value);
		totalPosition.y += 16.0;
		position2.y += 16.0;
		EditorGUI.PrefixLabel(totalPosition, GUIContent(secondText));
		value2 = EditorGUI.Vector2Field(position2, GUIContent.none, value2);
		var newUVTransform : Vector4 = Vector4(value.x, value.y, value2.x, value2.y);
		uvTransformProperty.textureScaleAndOffset = newUVTransform;
		return newUVTransform;
	}	
}