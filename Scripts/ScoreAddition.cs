using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreAddition : MonoBehaviour
{
    public static int score = 0;

   // [SerializeField]
  //  BallGenerator ballGenerator;

    private int point = BallGenerator.point;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = "得点：" + score.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore (int point)
    {
        score = score + point;
        GetComponent<Text>().text = "得点：" + score.ToString();

        Debug.Log(point);
    }

    public static int ResultScore()
    {
        return score;
    }


}
