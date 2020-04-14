using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreAddition : MonoBehaviour
{
    public static int score = 0;
    public static int score2 = 0;
    public static int score3 = 0;

    // [SerializeField]
    //  BallGenerator ballGenerator;

    private int point = BallGenerator.point;

    // Start is called before the first frame update
    void Start()
    {
        if(score != 0 && SceneManager.GetActiveScene().name == "GameScene")
        {
            score = 0;
        }

        if (score2 != 0 && SceneManager.GetActiveScene().name == "GameScene2")
        {
            score2 = 0;
        }

        if (score3 != 0 && SceneManager.GetActiveScene().name == "GameScene3")
        {
            score3 = 0;
        }

        GetComponent<Text>().text = "得点：" + score.ToString();
        GetComponent<Text>().text = "得点：" + score2.ToString();
        GetComponent<Text>().text = "得点：" + score3.ToString();

    }

    

    public void AddScore (int point)
    {
        if(SceneManager.GetActiveScene().name == "GameScene")
        {
            score = score + point;
            GetComponent<Text>().text = "得点：" + score.ToString();
        }

        if (SceneManager.GetActiveScene().name == "GameScene2")
        {
            score2 = score2 + point;
            GetComponent<Text>().text = "得点：" + score2.ToString();
        }

        if (SceneManager.GetActiveScene().name == "GameScene3")
        {
            score3 = score3 + point;
            GetComponent<Text>().text = "得点：" + score3.ToString();
        }

    }

    public static int ResultScore()
    {

        if (SceneManager.GetActiveScene().name == "GameScene" ||
            SceneManager.GetActiveScene().name == "ResultScene")
        {
            return score;
        }
        else if (SceneManager.GetActiveScene().name == "GameScene2" ||
            SceneManager.GetActiveScene().name == "ResultScene2")
        {
            //score3 = score;   
            return score2;           
        }
        else
        {
            //score3 = score;          
            return score3;
        }           
    }


}
