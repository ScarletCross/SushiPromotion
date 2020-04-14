using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScoreDeleter : MonoBehaviour
{
    public GameObject cancelButton;
    public GameObject excutionButton;

    public GameObject resetButton;
    public GameObject titleButton;
    //  public GameObject backResultButton;

    public GameObject deleteBoard;

    public Text deleteCompleteText;

    [SerializeField]
    DeleteBoard deleteBoarder;

    private int highScore = 0;
    private int highScore2 = 0;
    private int highScore3 = 0;

    private string key = "HIGH SCORE";  //  ハイスコア保存先キー
    private string key2 = "HIGH SCORE2";
    private string key3 = "HIGH SCORE3";


    // Start is called before the first frame update
    void Start()
    {
        deleteCompleteText.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CancelDeleteScore()
    {
        cancelButton.SetActive(false);
        excutionButton.SetActive(false);

        resetButton.SetActive(true);
        titleButton.SetActive(true);
        //  backResultButton.SetActive(true);

        deleteBoarder.high1.SetActive(true);
        deleteBoarder.high2.SetActive(true);
        deleteBoarder.high3.SetActive(true);

        deleteBoard.SetActive(false);
    }

     public void DeleteScore()
    {
        cancelButton.SetActive(false);
        excutionButton.SetActive(false);

        resetButton.SetActive(true);
       // titleButton.SetActive(true);
       // backResultButton.SetActive(true);
        deleteCompleteText.gameObject.SetActive(true);

        PlayerPrefs.DeleteKey("HIGH SCORE");
        PlayerPrefs.DeleteKey("HIGH SCORE2");
        PlayerPrefs.DeleteKey("HIGH SCORE3");

        highScore = PlayerPrefs.GetInt(key, 0); //  初期化
        highScore2 = PlayerPrefs.GetInt(key2, 0); 
        highScore3 = PlayerPrefs.GetInt(key3, 0); 



        SceneManager.LoadScene("TitleScene");
    }

    
}
