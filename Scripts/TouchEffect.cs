using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchEffect : MonoBehaviour
{
    [SerializeField]
    GameObject touchEffect = null;

    [SerializeField]
    Camera subCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            /* var pos = subCamera.ScreenToWorldPoint(Input.mousePosition + subCamera.transform.forward * 10);
             touchEffect.transform.position = pos;   */

            // タッチした画面座標からワールド座標へ変換
            Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5.0f));
            // 指定したエフェクトを作成
           // GameObject go = (GameObject)Instantiate(touchEffect, pos, Quaternion.identity);

            GameObject instans = (GameObject)Instantiate(touchEffect, pos, Quaternion.identity);

            // エフェクトを消す
            Destroy(instans, 0.6f);
        }
    }
}
