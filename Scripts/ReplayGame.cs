using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayGame : MonoBehaviour
{

    [SerializeField]
    TimeCount timeCount;

    private float time;

    private void Start()
    {
        time = timeCount.time;
    }

    public void Replay()
    {
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            time = Time.timeScale = 1;
            SceneManager.LoadScene("GameScene");
        }
        else if (SceneManager.GetActiveScene().name == "GameScene2")
        {
            time = Time.timeScale = 1;
            SceneManager.LoadScene("GameScene2");
        }
        else
        {
            time = Time.timeScale = 1;
            SceneManager.LoadScene("GameScene3");
        }
    }
}
