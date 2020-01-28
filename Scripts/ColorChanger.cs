using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public void ChangeColor(GameObject gameObject, float alpha)
    {
        //  SpriteRendererコンポーネントを取得
        SpriteRenderer BallTexture = gameObject.GetComponent<SpriteRenderer>();

        //  alpha値を変更
        BallTexture.color = new Color(BallTexture.color.r, BallTexture.color.g, BallTexture.color.b, alpha);


    }
}
