﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreGetter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int resultScore = ScoreAddition.ResultScore();
        GetComponent<Text>().text = "得点:" + resultScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
