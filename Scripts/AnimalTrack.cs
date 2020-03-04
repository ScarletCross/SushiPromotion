using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalTrack : MonoBehaviour
{

    public Image animal;

    public float speed = 1.0f;

    private Vector3 recttrans;

    public RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {

        rectTransform = gameObject.GetComponent<RectTransform>();
        recttrans = rectTransform.position;

        //recttrans = animal.rectTransform.localPosition;

        //animal.rectTransform.localPosition = recttrans;

        
    }

    // Update is called once per frame
    void Update()
    {
        float sin = Mathf.Sin(Time.time);
        float cos = Mathf.Cos(Time.time);

        // animal.rectTransform.localPosition = new Vector3(recttrans.x * sin * speed, recttrans.y * cos * speed, recttrans.z);

        animal.rectTransform.localPosition = new Vector3(recttrans.x * sin * speed, recttrans.y * cos * speed, recttrans.z);
    }
}
