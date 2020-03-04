using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonFlush : MonoBehaviour
{
    public float speed = 1.0f;
    public Text text;
    public Image image;

    private float time;

    private enum ObjctType
    {
        Text,
        Image
    };

    private ObjctType objctType = ObjctType.Image;


    // Start is called before the first frame update
    void Start()
    {

        //  アタッチしているオブジェクトを判別

        if (this.gameObject.GetComponent<Image>())
        {
            objctType = ObjctType.Image;
        }
        else if (this.gameObject.GetComponent<Text>())
        {
            objctType = ObjctType.Text;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //  オブジェクトのアルファ値を変更
        if(this.objctType == ObjctType.Image)
        {
            image.color = GetAlphaColor(image.color);
        }
        else if(this.objctType == ObjctType.Text)
        {
            text.color = GetAlphaColor(text.color);
        }
    }

    private Color GetAlphaColor(Color color)
    {
        time += Time.deltaTime * 5.0f * speed;

        color.a = Mathf.Sin(time) * 0.5f + 0.5f;

        return color;

    }


}
