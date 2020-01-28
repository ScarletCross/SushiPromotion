using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeUp : MonoBehaviour
{
    public GameObject TimeUpText;

    // Start is called before the first frame update
    void Start()
    {
        TimeUpText.SetActive(false);    // 非表示
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
