using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeCount : MonoBehaviour
{
    public float time = 60f;

    [SerializeField]
    BallGenerator ballGenerator;

    [SerializeField]
    SoundShot soundShot;

    public GameObject RefreshButton;
    public GameObject TimeUpText;

    public bool isAdv = false;
    private int advCount = 0;

    private string advKey = "ADV_OPEN";
   

    // Start is called before the first frame update
    void Start()
    {
        TimeUpText.SetActive(false);    // 非表示

        GetComponent<Text>().text = time.ToString("f2");  // 小数点以下第二位まで表示

        advCount = PlayerPrefs.GetInt(advKey, 0);
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;

        GetComponent<Text>().text = time.ToString("f2");

        if (time <= 0)
        {
            StartCoroutine("ToResult");
            time = 0;
            GetComponent<Text>().text = time.ToString("f2");
        }
    }

    IEnumerator ToResult()
    {
        TimeUpText.SetActive(true);     // 表示

        RefreshButton.GetComponent<Button>().interactable = false;  // うずしおボタンを押せないように

        ballGenerator.isPlaying = false;

        soundShot.EndWhistleSound();

        yield return new WaitForSeconds(2.0f);

        soundShot.EndWhistleSoundEnd();

        if (Input.GetMouseButtonDown(0))
        {
            advCount++;
            PlayerPrefs.GetInt(advKey, advCount);
            //advCount++;
            Debug.Log(advCount);

            if(SceneManager.GetActiveScene().name == "GameScene")
            {
                SceneManager.LoadScene("ResultScene");
            }
            else if(SceneManager.GetActiveScene().name == "GameScene2")
            {
                SceneManager.LoadScene("ResultScene2");
            }
            else
            {
                SceneManager.LoadScene("ResultScene3");
            }
            
        }

    }

    public void AdvJudge()
    {
        if(advCount == 2)
        {
            isAdv = true;
            PlayerPrefs.DeleteKey(advKey);
            Debug.Log(advCount);
            //advCount = 0;
        }

        
    }

}
