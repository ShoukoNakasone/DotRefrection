using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotObjectManager : MonoBehaviour {


    private List<GameObject> dotList = new List<GameObject>();

	// Use this for initialization
	void Start () 
    {
        // (仮)
        GameObject obj = this.gameObject.transform.Find("DotPrefab").gameObject;
        dotList.Add(obj);
	}
	
	// Update is called once per frame
	void Update () 
    {
	    //foreach (var x in dotList)
     //   {
     //       if (IsTouchObject(x))
     //       {
     //       }
     //   }
     IsTouchObject(null);
    }
    

    /// <summary>
    /// 該当オブジェクトがタッチされたか判定.
    /// </summary>
    /// <param name="aObject">該当オブジェクト情報</param>
    /// <returns>タッチされたか</returns>
    private bool IsTouchObject(GameObject aObject)
    {
        //if (Input.touchCount > 0)
        //{
        //    Touch touch = Input.GetTouch(0);
        //    Vector2 worldPoint = Camera.main.ScreenToWorldPoint(touch.position);
 
            if (InputManager.GetTouch() == InputManager.TouchInfo.Began)
            {
                Vector2 worldPoint = Camera.main.ScreenToWorldPoint(InputManager.GetTouchPosition());

                Debug.Log("worldPoint :x"+  worldPoint.x + "y:" + worldPoint.y);
              
                //タッチをした位置にオブジェクトがあるかどうかを判定
                RaycastHit2D hit = Physics2D.Raycast(worldPoint,Vector2.zero);
 
                if (hit)
                {
                 
                    Bounds rect =  hit.collider.bounds;
                 
　　　　　　　       //オブジェクトがある場合は、そのオブジェクトを消している
                    if(rect.Contains(worldPoint))
                    {
                         DebugFunctions.GetInstance().PrintText("たっち！");
                     
                    }
                }
                     
                     
            }
        //}

         return false;
    }
}
