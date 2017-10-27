using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager {
   
    private static Vector3 TouchPosition = Vector3.zero;


    /// <summary>
    /// タッチ情報。UnityEngine.TouchPhase に None の情報を追加拡張。
    /// </summary>
    public enum TouchInfo
    {
        None = 99,      // タッチなし

        // 以下は UnityEngine.TouchPhase の値に対応
        Began = 0,      // タッチ開始
        Moved = 1,      // タッチ移動
        Stationary = 2, // タッチ静止
        Ended = 3,      // タッチ終了
        Canceled = 4,   // タッチキャンセル
    }

    
    /// <summary>
    /// タッチ情報を取得(エディタと実機を考慮)
    /// </summary>
    /// <returns>タッチ情報。タッチされていない場合は null</returns>
    public static TouchInfo GetTouch()
    {
        if (AppSetting.IsUnityEditor())
        {
            if (Input.GetMouseButtonDown(0)) { return TouchInfo.Began; }
            if (Input.GetMouseButton(0)) { return TouchInfo.Moved; }
            if (Input.GetMouseButtonUp(0)) { return TouchInfo.Ended; }
        }
        else
        {
            if (Input.touchCount > 0)
            {
                return (TouchInfo)((int)Input.GetTouch(0).phase);
            }
        }
        return TouchInfo.None;
    }

    /// <summary>
    /// タッチポジションを取得(エディタと実機を考慮)
    /// </summary>
    /// <returns>タッチポジション。タッチされていない場合は (0, 0, 0)</returns>
    public static Vector3 GetTouchPosition()
    {
        if (AppSetting.IsUnityEditor())
        {
            TouchInfo touch = GetTouch();
            if (touch != TouchInfo.None) { return Input.mousePosition; }
        }
        else
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                TouchPosition.x = touch.position.x;
                TouchPosition.y = touch.position.y;
                return TouchPosition;
            }
        }
        return Vector3.zero;
    }

    /// <summary>
    /// タッチワールドポジションを取得(エディタと実機を考慮)
    /// </summary>
    /// <param name='camera'>カメラ</param>
    /// <returns>タッチワールドポジション。タッチされていない場合は (0, 0, 0)</returns>
    public static Vector3 GetTouchWorldPosition(Camera camera)
    {
        return camera.ScreenToWorldPoint(GetTouchPosition());
    }

}
