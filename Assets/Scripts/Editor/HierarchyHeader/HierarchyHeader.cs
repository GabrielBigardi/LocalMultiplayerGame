using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

//Simply re-styles a gameObject name in the Hiearchy window to be black and all caps.
//Allows us to seperate our gameObjects and not lose our minds.

[InitializeOnLoad]
public static class HierarchynHeader
{
    public static Dictionary<string, Color> headerColors = new Dictionary<string, Color>()
    {
        { "/black/", Color.black },
        { "/blue/", Color.blue },
        { "/cyan/", Color.cyan },
        { "/gray/", Color.gray },
        { "/green/", Color.green },
        { "/grey/", Color.grey },
        { "/magenta/", Color.magenta },
        { "/red/", Color.red },
        { "/white/", Color.white },
        { "/yellow/", Color.yellow }
    };

    static HierarchynHeader()
    {
        EditorApplication.hierarchyWindowItemOnGUI += HierarchyWindowItemOnGUI;
    }

    static void HierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
    {
        var gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;

        if(gameObject != null)
        {
            foreach (var headerColor in headerColors)
            {
                if (gameObject.name.StartsWith(headerColor.Key, System.StringComparison.Ordinal))
                {
                    EditorGUI.DrawRect(selectionRect, headerColor.Value);
                    EditorGUI.DropShadowLabel(selectionRect, gameObject.name.Replace(headerColor.Key, "").ToUpperInvariant());
                }
            }
        }
    }
}