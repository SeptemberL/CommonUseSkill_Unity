using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalFunctions 
{

    public static void ParseVector4(ref Vector4 v4, string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            v4 = Vector4.zero;
            return;
        }
        string[] array = str.Split(',', ';', '=');
        if (array.Length >= 1)
            ParseFloat(ref v4.x, array[0]);
        if (array.Length >= 2)
            ParseFloat(ref v4.y, array[1]);
        if (array.Length >= 3)
            ParseFloat(ref v4.z, array[2]);
        if (array.Length >= 4)
            ParseFloat(ref v4.w, array[3]);
    }

    /*解析字符串到颜色RGB值*/
    public static Color ParseColorRGB(string str)
    {
        Color col = Color.white;
        string[] array = str.Split(',', ';', '=');
        col.r = int.Parse(array[0]) / 255f;
        col.g = int.Parse(array[1]) / 255f;
        col.b = int.Parse(array[2]) / 255f;
        return col;
    }

    public static Color ParseColorRGBA(string str)
    {
        Color col = Color.white;
        string[] array = str.Split(',', ';', '=');
        col.r = int.Parse(array[0]) / 255f;
        col.g = int.Parse(array[1]) / 255f;
        col.b = int.Parse(array[2]) / 255f;
        col.a = int.Parse(array[3]) / 255f;
        return col;
    }

    
    public static void ParseVector2(ref Vector2 v2, string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            v2 = Vector2.zero;
            return;
        }

        string[] array = str.Split(',', ';', '=');
        if (array.Length >= 1)
            ParseFloat(ref v2.x, array[0]);
        if (array.Length >= 2)
            ParseFloat(ref v2.y, array[1]);
    }
    public static void ParseVector3(ref Vector3 v3, string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            v3 = Vector3.zero;
            return;
        }
        string[] array = str.Split(',', ';', '=');
        if (array.Length >= 1)
            ParseFloat(ref v3.x, array[0]);
        if (array.Length >= 2)
            ParseFloat(ref v3.y, array[1]);
        if (array.Length >= 3)
            ParseFloat(ref v3.z, array[2]);
    }
    //转换float
    public static void ParseFloat(ref float target, string str)
    {
        ParseFloat(ref target, str, 0f);
    }

    //转换float
    public static void ParseFloat(ref float target, string str, float defaultValue)
    {
        if (string.IsNullOrEmpty(str))
        {
            target = defaultValue;
            return;
        }
        str = str.Replace("(", "");
        str = str.Replace(")", "");
        float result = defaultValue;//使用默认值
        if (float.TryParse(str, out result))
        {
            target = result;
        }
        else
        {
            Debug.LogError("ParseFloat Error at field : " + str);
            target = defaultValue;
        }
    }
}
