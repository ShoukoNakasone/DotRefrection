using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AppSetting {
    

    /// *****---------------------------------------------*****
    ///     プラットフォーム別の処理を実装する際、
    ///     defineを使うとコンパイルエラーが見つけにくいので、
    ///     ここで定義されている関数を使用すること。
    /// *****---------------------------------------------*****



    /// <summary>
    /// 
    /// </summary>
    public enum Plotform
    {
        UnityEditor = 0,
        Ios = 1,
        Android = 2,
        Another = 3,
    }
   
    /// <summary>
    /// プラットフォームの取得
    /// </summary>
    public static Plotform GetPlatform()
    {
        #if UNITY_EDITOR
        return Plotform.UnityEditor;
        #elif UNITY_ANDROID
        return RunPlotform.Android;
        #elif UNITY_IOS
        return RunPlotform.Ios;
        #else
        return RunPlotform.Another;
        #endif
    }

    /// <summary>
    /// プラットフォームがUnityEditorか
    /// </summary>
    /// <returns>true:UnityEditor false:それ以外</returns>
    public static bool IsUnityEditor()
    {
        return (GetPlatform() == Plotform.UnityEditor);
    }

    /// <summary>
    /// プラットフォームがIosか
    /// </summary>
    /// <returns>true:Iosれ以外</returns>
    public static bool IsIos()
    {
        return (GetPlatform() == Plotform.Ios);
    }

    /// <summary>
    /// プラットフォームがAndroidか
    /// </summary>
    /// <returns>true:Android false:それ以外</returns>
    public static bool IsAndroid()
    {
        return (GetPlatform() == Plotform.Android);
    }
}
