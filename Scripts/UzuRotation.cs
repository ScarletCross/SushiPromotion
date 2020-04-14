using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UzuRotation : MonoBehaviour
{
   // public Image uzu;
    public float speed = 1.0f;
    private RectTransform rectTransform;
    private Vector3 axis = new Vector3(0f, 0f, 1f); // 回転軸z
    


    // Start is called before the first frame update
    void Start()
    {
        

        gameObject.GetComponent<Image>();
        rectTransform = gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {

        gameObject.SetActive(true);
        float angle = 180f * Time.deltaTime;
        Quaternion q = Quaternion.AngleAxis(angle, axis);   //  axis軸周りにangle回転させるクォータニオン

        this.rectTransform.rotation = q * this.rectTransform.rotation;


    }

   
}
