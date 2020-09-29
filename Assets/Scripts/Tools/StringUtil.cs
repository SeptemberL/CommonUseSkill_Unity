using UnityEngine;
using System.Collections;
using System.Text;
using System;
using System.Collections.Generic;

public partial class StringUtil
{
    //自定义字符串函数公用的StringBuilder
    static StringBuilder _customSB = new StringBuilder();
    //共享的StringBuilder
    static StringBuilder shareSB = new StringBuilder();

    #region Concat
    /// <summary>
    /// 拼接字符串(2个)
    /// </summary>
    /// <param name="a1"></param>
    /// <param name="a2"></param>
    /// <returns></returns>
    public static string Concat(string a1, string a2)
    {
        _customSB.Remove(0, _customSB.Length);
        _customSB.Append(a1);
        _customSB.Append(a2);
        return _customSB.ToString();
    }
    /// <summary>
    /// 拼接字符串(3个)
    /// </summary>
    /// <param name="a1"></param>
    /// <param name="a2"></param>
    /// <param name="a3"></param>
    /// <returns></returns>
    public static string Concat(string a1, string a2, string a3)
    {
        _customSB.Remove(0, _customSB.Length);
        _customSB.Append(a1);
        _customSB.Append(a2);
        _customSB.Append(a3);
        return _customSB.ToString();
    }
    /// <summary>
    /// 拼接字符串(4个)
    /// </summary>
    /// <param name="a1"></param>
    /// <param name="a2"></param>
    /// <param name="a3"></param>
    /// <param name="a4"></param>
    /// <returns></returns>
    public static string Concat(string a1, string a2, string a3, string a4)
    {
        _customSB.Remove(0, _customSB.Length);
        _customSB.Append(a1);
        _customSB.Append(a2);
        _customSB.Append(a3);
        _customSB.Append(a4);
        return _customSB.ToString();
    }
    /// <summary>
    /// 拼接字符串(5个)
    /// </summary>
    /// <param name="a1"></param>
    /// <param name="a2"></param>
    /// <param name="a3"></param>
    /// <param name="a4"></param>
    /// <param name="a5"></param>
    /// <returns></returns>
    public static string Concat(string a1, string a2, string a3, string a4, string a5)
    {
        _customSB.Remove(0, _customSB.Length);
        _customSB.Append(a1);
        _customSB.Append(a2);
        _customSB.Append(a3);
        _customSB.Append(a4);
        _customSB.Append(a5);
        return _customSB.ToString();
    }
    /// <summary>
    /// 拼接字符串(6个)
    /// </summary>
    /// <param name="a1"></param>
    /// <param name="a2"></param>
    /// <param name="a3"></param>
    /// <param name="a4"></param>
    /// <param name="a5"></param>
    /// <param name="a6"></param>
    /// <returns></returns>
    public static string Concat(string a1, string a2, string a3, string a4, string a5, 
        string a6)
    {
        _customSB.Remove(0, _customSB.Length);
        _customSB.Append(a1);
        _customSB.Append(a2);
        _customSB.Append(a3);
        _customSB.Append(a4);
        _customSB.Append(a5);
        _customSB.Append(a6);
        return _customSB.ToString();
    }
    /// <summary>
    /// 拼接字符串(7个)
    /// </summary>
    /// <param name="a1"></param>
    /// <param name="a2"></param>
    /// <param name="a3"></param>
    /// <param name="a4"></param>
    /// <param name="a5"></param>
    /// <param name="a6"></param>
    /// <param name="a7"></param>
    /// <returns></returns>
    public static string Concat(string a1, string a2, string a3, string a4, string a5, 
        string a6, string a7)
    {
        _customSB.Remove(0, _customSB.Length);
        _customSB.Append(a1);
        _customSB.Append(a2);
        _customSB.Append(a3);
        _customSB.Append(a4);
        _customSB.Append(a5);
        _customSB.Append(a6);
        _customSB.Append(a7);
        return _customSB.ToString();
    }
    /// <summary>
    /// 拼接字符串(8个)
    /// </summary>
    /// <param name="a1"></param>
    /// <param name="a2"></param>
    /// <param name="a3"></param>
    /// <param name="a4"></param>
    /// <param name="a5"></param>
    /// <param name="a6"></param>
    /// <param name="a7"></param>
    /// <param name="a8"></param>
    /// <returns></returns>
    public static string Concat(string a1, string a2, string a3, string a4, string a5, 
        string a6, string a7, string a8)
    {
        _customSB.Remove(0, _customSB.Length);
        _customSB.Append(a1);
        _customSB.Append(a2);
        _customSB.Append(a3);
        _customSB.Append(a4);
        _customSB.Append(a5);
        _customSB.Append(a6);
        _customSB.Append(a7);
        _customSB.Append(a8);
        return _customSB.ToString();
    }
    /// <summary>
    /// 拼接字符串(9个)
    /// </summary>
    /// <param name="a1"></param>
    /// <param name="a2"></param>
    /// <param name="a3"></param>
    /// <param name="a4"></param>
    /// <param name="a5"></param>
    /// <param name="a6"></param>
    /// <param name="a7"></param>
    /// <param name="a8"></param>
    /// <param name="a9"></param>
    /// <returns></returns>
    public static string Concat(string a1, string a2, string a3, string a4, string a5, 
        string a6, string a7, string a8, string a9)
    {
        _customSB.Remove(0, _customSB.Length);
        _customSB.Append(a1);
        _customSB.Append(a2);
        _customSB.Append(a3);
        _customSB.Append(a4);
        _customSB.Append(a5);
        _customSB.Append(a6);
        _customSB.Append(a7);
        _customSB.Append(a8);
        _customSB.Append(a9);
        return _customSB.ToString();
    }
    /// <summary>
    /// 拼接字符串(10个)
    /// </summary>
    /// <param name="a1"></param>
    /// <param name="a2"></param>
    /// <param name="a3"></param>
    /// <param name="a4"></param>
    /// <param name="a5"></param>
    /// <param name="a6"></param>
    /// <param name="a7"></param>
    /// <param name="a8"></param>
    /// <param name="a9"></param>
    /// <param name="a10"></param>
    /// <returns></returns>
    public static string Concat(string a1, string a2, string a3, string a4, string a5, 
        string a6, string a7, string a8, string a9, string a10)
    {
        _customSB.Remove(0, _customSB.Length);
        _customSB.Append(a1);
        _customSB.Append(a2);
        _customSB.Append(a3);
        _customSB.Append(a4);
        _customSB.Append(a5);
        _customSB.Append(a6);
        _customSB.Append(a7);
        _customSB.Append(a8);
        _customSB.Append(a9);
        _customSB.Append(a10);
        return _customSB.ToString();
    }
    /// <summary>
    /// 拼接字符串(11个)
    /// </summary>
    /// <param name="a1"></param>
    /// <param name="a2"></param>
    /// <param name="a3"></param>
    /// <param name="a4"></param>
    /// <param name="a5"></param>
    /// <param name="a6"></param>
    /// <param name="a7"></param>
    /// <param name="a8"></param>
    /// <param name="a9"></param>
    /// <param name="a10"></param>
    /// <param name="a11"></param>
    /// <returns></returns>
    public static string Concat(string a1, string a2, string a3, string a4, string a5, 
        string a6, string a7, string a8, string a9, string a10, 
        string a11)
    {
        _customSB.Remove(0, _customSB.Length);
        _customSB.Append(a1);
        _customSB.Append(a2);
        _customSB.Append(a3);
        _customSB.Append(a4);
        _customSB.Append(a5);
        _customSB.Append(a6);
        _customSB.Append(a7);
        _customSB.Append(a8);
        _customSB.Append(a9);
        _customSB.Append(a10);
        _customSB.Append(a11);
        return _customSB.ToString();
    }
    /// <summary>
    /// 拼接字符串(12个)
    /// </summary>
    /// <param name="a1"></param>
    /// <param name="a2"></param>
    /// <param name="a3"></param>
    /// <param name="a4"></param>
    /// <param name="a5"></param>
    /// <param name="a6"></param>
    /// <param name="a7"></param>
    /// <param name="a8"></param>
    /// <param name="a9"></param>
    /// <param name="a10"></param>
    /// <param name="a11"></param>
    /// <param name="a12"></param>
    /// <returns></returns>
    public static string Concat(string a1, string a2, string a3, string a4, string a5, 
        string a6, string a7, string a8, string a9, string a10, 
        string a11, string a12)
    {
        _customSB.Remove(0, _customSB.Length);
        _customSB.Append(a1);
        _customSB.Append(a2);
        _customSB.Append(a3);
        _customSB.Append(a4);
        _customSB.Append(a5);
        _customSB.Append(a6);
        _customSB.Append(a7);
        _customSB.Append(a8);
        _customSB.Append(a9);
        _customSB.Append(a10);
        _customSB.Append(a11);
        _customSB.Append(a12);
        return _customSB.ToString();
    }
    /// <summary>
    /// 拼接字符串(13个)
    /// </summary>
    /// <param name="a1"></param>
    /// <param name="a2"></param>
    /// <param name="a3"></param>
    /// <param name="a4"></param>
    /// <param name="a5"></param>
    /// <param name="a6"></param>
    /// <param name="a7"></param>
    /// <param name="a8"></param>
    /// <param name="a9"></param>
    /// <param name="a10"></param>
    /// <param name="a11"></param>
    /// <param name="a12"></param>
    /// <param name="a13"></param>
    /// <returns></returns>
    public static string Concat(string a1, string a2, string a3, string a4, string a5, 
        string a6, string a7, string a8, string a9, string a10, 
        string a11, string a12, string a13)
    {
        _customSB.Remove(0, _customSB.Length);
        _customSB.Append(a1);
        _customSB.Append(a2);
        _customSB.Append(a3);
        _customSB.Append(a4);
        _customSB.Append(a5);
        _customSB.Append(a6);
        _customSB.Append(a7);
        _customSB.Append(a8);
        _customSB.Append(a9);
        _customSB.Append(a10);
        _customSB.Append(a11);
        _customSB.Append(a12);
        _customSB.Append(a13);
        return _customSB.ToString();
    }

    /// <summary>
    /// 拼接字符串(14个)
    /// </summary>
    /// <param name="a1"></param>
    /// <param name="a2"></param>
    /// <param name="a3"></param>
    /// <param name="a4"></param>
    /// <param name="a5"></param>
    /// <param name="a6"></param>
    /// <param name="a7"></param>
    /// <param name="a8"></param>
    /// <param name="a9"></param>
    /// <param name="a10"></param>
    /// <param name="a11"></param>
    /// <param name="a12"></param>
    /// <param name="a13"></param>
    /// <param name="a14"></param>
    /// <returns></returns>
    public static string Concat(string a1, string a2, string a3, string a4, string a5, 
        string a6, string a7, string a8, string a9, string a10, 
        string a11, string a12, string a13, string a14)
    {
        _customSB.Remove(0, _customSB.Length);
        _customSB.Append(a1);
        _customSB.Append(a2);
        _customSB.Append(a3);
        _customSB.Append(a4);
        _customSB.Append(a5);
        _customSB.Append(a6);
        _customSB.Append(a7);
        _customSB.Append(a8);
        _customSB.Append(a9);
        _customSB.Append(a10);
        _customSB.Append(a11);
        _customSB.Append(a12);
        _customSB.Append(a13);
        _customSB.Append(a14);
        return _customSB.ToString();
    }
    /// <summary>
    /// 拼接字符串(15个)
    /// </summary>
    public static string Concat(string a1, string a2, string a3, string a4, string a5, 
        string a6, string a7, string a8, string a9, string a10, 
        string a11, string a12, string a13, string a14, string a15)
    {
        _customSB.Remove(0, _customSB.Length);
        _customSB.Append(a1);
        _customSB.Append(a2);
        _customSB.Append(a3);
        _customSB.Append(a4);
        _customSB.Append(a5);
        _customSB.Append(a6);
        _customSB.Append(a7);
        _customSB.Append(a8);
        _customSB.Append(a9);
        _customSB.Append(a10);
        _customSB.Append(a11);
        _customSB.Append(a12);
        _customSB.Append(a13);
        _customSB.Append(a14);
        _customSB.Append(a15);
        return _customSB.ToString();
    }
    /// <summary>
    /// 拼接字符串(16个)
    /// </summary>
    public static string Concat(string a1, string a2, string a3, string a4, string a5,
        string a6, string a7, string a8, string a9, string a10,
        string a11, string a12, string a13, string a14, string a15,
        string a16)
    {
        _customSB.Remove(0, _customSB.Length);
        _customSB.Append(a1);
        _customSB.Append(a2);
        _customSB.Append(a3);
        _customSB.Append(a4);
        _customSB.Append(a5);
        _customSB.Append(a6);
        _customSB.Append(a7);
        _customSB.Append(a8);
        _customSB.Append(a9);
        _customSB.Append(a10);
        _customSB.Append(a11);
        _customSB.Append(a12);
        _customSB.Append(a13);
        _customSB.Append(a14);
        _customSB.Append(a15);
        _customSB.Append(a16);
        return _customSB.ToString();
    }
    /// <summary>
    /// 拼接字符串(17个)
    /// </summary>
    public static string Concat(string a1, string a2, string a3, string a4, string a5,
        string a6, string a7, string a8, string a9, string a10,
        string a11, string a12, string a13, string a14, string a15,
        string a16, string a17)
    {
        _customSB.Remove(0, _customSB.Length);
        _customSB.Append(a1);
        _customSB.Append(a2);
        _customSB.Append(a3);
        _customSB.Append(a4);
        _customSB.Append(a5);
        _customSB.Append(a6);
        _customSB.Append(a7);
        _customSB.Append(a8);
        _customSB.Append(a9);
        _customSB.Append(a10);
        _customSB.Append(a11);
        _customSB.Append(a12);
        _customSB.Append(a13);
        _customSB.Append(a14);
        _customSB.Append(a15);
        _customSB.Append(a16);
        _customSB.Append(a17);
        return _customSB.ToString();
    }

    /// <summary>
    /// 拼接字符串(18个)
    /// </summary>
    public static string Concat(string a1, string a2, string a3, string a4, string a5,
        string a6, string a7, string a8, string a9, string a10,
        string a11, string a12, string a13, string a14, string a15,
        string a16, string a17, string a18)
    {
        _customSB.Remove(0, _customSB.Length);
        _customSB.Append(a1);
        _customSB.Append(a2);
        _customSB.Append(a3);
        _customSB.Append(a4);
        _customSB.Append(a5);
        _customSB.Append(a6);
        _customSB.Append(a7);
        _customSB.Append(a8);
        _customSB.Append(a9);
        _customSB.Append(a10);
        _customSB.Append(a11);
        _customSB.Append(a12);
        _customSB.Append(a13);
        _customSB.Append(a14);
        _customSB.Append(a15);
        _customSB.Append(a16);
        _customSB.Append(a17);
        _customSB.Append(a18);
        return _customSB.ToString();
    }
    /// <summary>
    /// 拼接字符串(19个)
    /// </summary>
    public static string Concat(string a1, string a2, string a3, string a4, string a5,
        string a6, string a7, string a8, string a9, string a10,
        string a11, string a12, string a13, string a14, string a15,
        string a16, string a17, string a18, string a19)
    {
        _customSB.Remove(0, _customSB.Length);
        _customSB.Append(a1);
        _customSB.Append(a2);
        _customSB.Append(a3);
        _customSB.Append(a4);
        _customSB.Append(a5);
        _customSB.Append(a6);
        _customSB.Append(a7);
        _customSB.Append(a8);
        _customSB.Append(a9);
        _customSB.Append(a10);
        _customSB.Append(a11);
        _customSB.Append(a12);
        _customSB.Append(a13);
        _customSB.Append(a14);
        _customSB.Append(a15);
        _customSB.Append(a16);
        _customSB.Append(a17);
        _customSB.Append(a18);
        _customSB.Append(a19);
        return _customSB.ToString();
    }
    /// <summary>
    /// 拼接字符串(20个)
    /// </summary>
    public static string Concat(string a1, string a2, string a3, string a4, string a5,
        string a6, string a7, string a8, string a9, string a10,
        string a11, string a12, string a13, string a14, string a15,
        string a16, string a17, string a18, string a19, string a20)
    {
        _customSB.Remove(0, _customSB.Length);
        _customSB.Append(a1);
        _customSB.Append(a2);
        _customSB.Append(a3);
        _customSB.Append(a4);
        _customSB.Append(a5);
        _customSB.Append(a6);
        _customSB.Append(a7);
        _customSB.Append(a8);
        _customSB.Append(a9);
        _customSB.Append(a10);
        _customSB.Append(a11);
        _customSB.Append(a12);
        _customSB.Append(a13);
        _customSB.Append(a14);
        _customSB.Append(a15);
        _customSB.Append(a16);
        _customSB.Append(a17);
        _customSB.Append(a18);
        _customSB.Append(a19);
        _customSB.Append(a20);
        return _customSB.ToString();
    }
    #endregion

    /// <summary>
    /// 获得公用的StringBuilder
    /// </summary>
    /// <returns></returns>
    public static StringBuilder GetShareStringBuilder(bool bReset = true)
    {
        if (bReset)
        {
            shareSB.Remove(0, shareSB.Length);
        }        
        return shareSB;
    }

    /// <summary>
    /// 格式化字符串
    /// </summary>
    /// <param name="format"></param>
    /// <param name="args"></param>
    /// <returns></returns>
    public static string Format(string format, params object[] args)
    {
        try
        {
            _customSB.Remove(0, _customSB.Length);
            _customSB.AppendFormat(format, args);
            return _customSB.ToString();
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
            return format;
        }
    }

    /// <summary>
    /// 替换\\n 为\n
    /// </summary>
    /// <param name="baseStr"></param>
    /// <returns></returns>
    public static string ReplaceNewLineChar(string baseStr)
    {
        //if (!baseStr.Contains("\\n"))
        //{
        //    return baseStr;
        //}
        return baseStr.Replace("\\n", "\n");
    }

    /// <summary>
    /// 替换转义字符
    /// </summary>
    /// <param name="baseStr"></param>
    /// <returns></returns>
    public static string ReplaceTranslateChar(string baseStr)
    {
        baseStr = baseStr.Replace("\\n", "\n");
        baseStr = baseStr.Replace("\\t", "\t");
        baseStr = baseStr.Replace("\\b", "　");
        return baseStr;
    }

    /// <summary>
    /// 替换\\s 为(全角)空格
    /// </summary>
    /// <param name="baseStr"></param>
    /// <returns></returns>
    public static string ReplaceNewBlankSpaceChar(string baseStr)
    {
        //if (!baseStr.Contains("\\s"))
        //{
        //    return baseStr;
        //}
        return baseStr.Replace("\\s", "　");
    }

    /// <summary>
    /// 文本加持颜色
    /// </summary>
    /// <param name="color"></param>
    /// <param name="text"></param>
    /// <returns></returns>
    public static string UITextColor(string color, string text)
    {
        return StringUtil.Format("<color=#{0}>{1}</color>", color, text);
    }

    /// <summary>
    /// 文本加持颜色
    /// </summary>
    /// <param name="color"></param>
    /// <param name="text"></param>
    /// <returns></returns>
    public static string UITextColor(Color color, string text)
    {
        return UITextColor(ColorUtility.ToHtmlStringRGBA(color), text);
    }

    /// <summary>
    /// 整数转字符串
    /// </summary>
    /// <param name="num"></param>
    /// <param name="limit"></param>
    /// <param name="param"></param>
    /// <returns></returns>
    public static string Int2StringLimit(int num, int limit, string param = "")
    {
        if (num < limit)
        {
            return num.ToString(param);
        }
        else
        {
            return limit.ToString(param);
        }
    }

    /// <summary>
    /// 替换为linux的斜杠
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string StringSlashOfLinux(string str)
    {
        return str.Replace('\\', '/'); ;
    }

    /// <summary>
    /// 替换为win的斜杠
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string StringSlashOfWin(string str)
    {
        return str.Replace('/', '\\'); ;
    }

    /// <summary>
    /// 服务器接收的字符串不可有竖线
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string ToServerSafeString(string str)
    {
        return str.Replace("|", "/");
    }

    public static string DictionaryConvertString(Dictionary<int, int> dic)
    {
        _customSB.Remove(0, _customSB.Length);
        if(dic != null)
        {
            Dictionary<int, int>.Enumerator itor = dic.GetEnumerator();
            while(itor.MoveNext())
            {
                _customSB.Append(itor.Current.Key);
                _customSB.Append(",");
                _customSB.Append(itor.Current.Value);
                _customSB.Append(";");
            }
        }
        return _customSB.ToString();
    }
    #region 数字转美式字符串
    public static string Num2US(float num)
    {
        return num.ToString("n2").Replace(',',' ');
    }
    public static string Num2US(int num)
    {
        return num.ToString("n0").Replace(',', ' ');
    }
    public static string Num2US(long num)
    {
        return num.ToString("n0").Replace(',', ' ');
    }
    #endregion
}