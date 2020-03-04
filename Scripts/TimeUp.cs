using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeUp : MonoBehaviour
{
    public GameObject TimeUpText;
    

    [SerializeField]
    TimeCount timeCount;

    public float endTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        TimeUpText.SetActive(false);    // 非表示

        endTime = timeCount.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(endTime <= 0)
        {
            TimeUpText.SetActive(true);
        }
    }
}
