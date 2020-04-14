using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{

    [SerializeField]
    ButtonSound buttonSound;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoSelect()
    {

        StartCoroutine("Interval");

        SceneManager.LoadScene("SelectScene");
    }

    IEnumerator Interval()
    {
        buttonSound.OnDecisionButton();
        yield return new WaitForSeconds(1.0f);    
    }
    


    public void StartToGame()
    {
        
        int resultScore = ScoreAddition.ResultScore();
        resultScore = 0;
        if (SceneManager.GetActiveScene().name == "ResultScene2")
        {
            SceneManager.LoadScene("GameScene2");
        }
        else if(SceneManager.GetActiveScene().name == "ResultScene3")
        {
            SceneManager.LoadScene("GameScene3");
        }
        else
        {
            SceneManager.LoadScene("GameScene");
        }
        
    }

    public void StartToGame2()
    {

        int resultScore = ScoreAddition.ResultScore();
        resultScore = 0;
        SceneManager.LoadScene("GameScene2");
    }

    public void StartToGame3()
    {

        int resultScore = ScoreAddition.ResultScore();
        resultScore = 0;
        SceneManager.LoadScene("GameScene3");
    }

    public void BackToTitle()
    {
        
        int resultScore = ScoreAddition.ResultScore();
        resultScore = 0;
        SceneManager.LoadScene("TitleScene");
    }

    public void ResultToConfig()
    {
        SceneManager.LoadScene("ConfigScene");
    }

    public void ConfigToResult()
    {
        SceneManager.LoadScene("ResultScene");
    }
}
