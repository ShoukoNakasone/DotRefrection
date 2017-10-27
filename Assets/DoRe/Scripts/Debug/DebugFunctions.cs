using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugFunctions : MonoBehaviour {

    private static DebugFunctions instance;

    public Text DebugText;  // 文字表示用のテキスト
    

    /// <summary>
    /// インスタンスの取得
    /// </summary>
    /// <returns></returns>
    public static DebugFunctions GetInstance()
    {
        return instance;
    }

    /// <summary>
    /// </summary>
	void Awake() 
    {
        instance = this;

        if (DebugText != null)
        {
            DebugText.text = "";
        }
	}
	

    /// <summary>
    /// 画面にテキストを表示
    /// 表示行数を変更する場合は「maxLineCount」の値を変える
    /// </summary>
    /// <param name="_text">表示するテキスト</param>
    public void PrintText( string _text )
    {
        if (DebugText == null) return;

        int lineCount = 1;      // 行数のカウント
        int maxLineCount = 10;  // 最大行数

        string tmpText = _text + "\n";
        
        for (int i = 0; i < DebugText.text.Length; i++)
        {
            tmpText += DebugText.text[i];

            // 改行があったらカウントを増やす
            if (DebugText.text[i] == '\n') lineCount++;

            // 最大行数に達したら終了
            if (lineCount > maxLineCount) break;
        }

        DebugText.text = tmpText;
        
    }
}
