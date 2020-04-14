using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeUp : MonoBehaviour
{
    public GameObject TimeUpText;
    //public GameObject TimeUpFrame;
    

    [SerializeField]
    TimeCount timeCount;

  

    private float endTime;

    // Start is called before the first frame update
    void Start()
    {
        TimeUpText.SetActive(false);    // 非表示
        //TimeUpFrame.SetActive(false);

        endTime = timeCount.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(endTime <= 0)
        {
            TimeUpText.SetActive(true);
            //TimeUpFrame.SetActive(true);          
        }
    }
}
