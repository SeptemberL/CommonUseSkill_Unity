using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EditorUtil
{
    private static List<string> headerKeyList = new List<string>();
    public static void ClearHeaderKeyList()
    {
        headerKeyList.Clear();
    }

    public static List<string> GetHeaderKeyList()
    {
        return headerKeyList;
    }

    public static void SetHeaderState(string key, bool state)
    {
        EditorPrefs.SetBool(key, state);
    }

    public static bool DrawHeader(string text, float maxWidth = 0) { return DrawHeader(text, text, false, true, maxWidth); }
    public static bool DrawHeader(string text, string key, bool forceOn, bool minimalistic, float maxWidth = 0)
    {
        if (!headerKeyList.Contains(key))
            headerKeyList.Add(key);
        bool state = EditorPrefs.GetBool(key, true);

        if (!minimalistic) GUILayout.Space(3f);
        if (!forceOn && !state) GUI.backgroundColor = new Color(0.8f, 0.8f, 0.8f);
        GUILayout.BeginHorizontal();
        GUI.changed = false;

        List<GUILayoutOption> list = new List<GUILayoutOption>();
        list.Add(GUILayout.MinWidth(20f));
        if (maxWidth != 0)
            list.Add(GUILayout.Width(maxWidth));

        if (minimalistic)
        {
            if (state) text = "\u25BC" + (char)0x200a + text;
            else text = "\u25BA" + (char)0x200a + text;

            GUILayout.BeginHorizontal();
            GUI.contentColor = EditorGUIUtility.isProSkin ? new Color(1f, 1f, 1f, 0.7f) : new Color(0f, 0f, 0f, 0.7f);
            if (!GUILayout.Toggle(true, text, "PreToolbar2", list.ToArray())) state = !state;
            GUI.contentColor = Color.white;
            GUILayout.EndHorizontal();
        }
        else
        {
            text = "<b><size=11>" + text + "</size></b>";
            if (state) text = "\u25BC " + text;
            else text = "\u25BA " + text;
            if (!GUILayout.Toggle(true, text, "dragtab", list.ToArray())) state = !state;
        }

        if (GUI.changed) EditorPrefs.SetBool(key, state);

        if (!minimalistic) GUILayout.Space(2f);
        GUILayout.EndHorizontal();
        GUI.backgroundColor = Color.white;
        if (!forceOn && !state) GUILayout.Space(3f);
        return state;
    }
}
