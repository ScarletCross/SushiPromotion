using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScoreKeeper : MonoBehaviour
{
    public Text highScoreText;
    public Text highScoreText2;
    public Text highScoreText3;

    private int highScore = 0;
    private int highScore2 = 0;
    private int highScore3 = 0;

    private string key = "HIGH SCORE";  //  ハイスコア保存先キー
    private string key2 = "HIGH SCORE2";
    private string key3 = "HIGH SCORE3";

    private int score = ScoreAddition.score;
    private int score2 = ScoreAddition.score2;
    private int score3 = ScoreAddition.score3;

    [SerializeField]
    NewRecordSE newRecordSE;



    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt(key, 0); //  保存しておいたハイスコアをキーで呼び出し取得。保存されていなければ0
        highScoreText.text = "かんたん\n" + highScore.ToString();

        highScore2 = PlayerPrefs.GetInt(key2, 0);
        highScoreText2.text = "ふつう\n" + highScore2.ToString();

        highScore3 = PlayerPrefs.GetInt(key3, 0); 
        highScoreText3.text = "むずかしい\n" + highScore3.ToString();


    }

    // Update is called once per frame
    void Update()
    {

        if(SceneManager.GetActiveScene().name == "ResultScene")
        {
            if (score > highScore)
            {
                highScore = score;
                newRecordSE.NewRecord();
                PlayerPrefs.SetInt(key, highScore); //  ハイスコアをhighScoreで保存               
            }
        }
        if(SceneManager.GetActiveScene().name == "ResultScene" || SceneManager.GetActiveScene().name == "ConfigScene")
        {
            highScoreText.text = "かんたん\n" + highScore.ToString();
        }


        if (SceneManager.GetActiveScene().name == "ResultScene2")
        {
            if (score2 > highScore2)
            {
                highScore2 = score2;
                newRecordSE.NewRecord();
                PlayerPrefs.SetInt(key2, highScore2); //  ハイスコアをhighScoreで保存               
            }
        }
        if (SceneManager.GetActiveScene().name == "ResultScene2" || SceneManager.GetActiveScene().name == "ConfigScene")
        {
            highScoreText2.text = "ふつう\n" + highScore2.ToString();
        }

        if (SceneManager.GetActiveScene().name == "ResultScene3")
        {
            if (score3 > highScore3)
            {
                highScore3 = score3;
                newRecordSE.NewRecord();
                PlayerPrefs.SetInt(key3, highScore3); //  ハイスコアをhighScoreで保存               
            }
        }
        if (SceneManager.GetActiveScene().name == "ResultScene3" || SceneManager.GetActiveScene().name == "ConfigScene")
        {
            highScoreText3.text = "むずかしい\n" + highScore3.ToString();
        }





    }
}
