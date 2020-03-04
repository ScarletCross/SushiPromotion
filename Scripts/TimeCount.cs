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

    public GameObject RefreshButton;
    public GameObject TimeUpText;
   

    // Start is called before the first frame update
    void Start()
    {
        TimeUpText.SetActive(false);    // 非表示

        GetComponent<Text>().text = time.ToString("f2");  // 小数点以下第二位まで表示
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

        yield return new WaitForSeconds(2.0f);

        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("ResultScene");
        }

    }

}
