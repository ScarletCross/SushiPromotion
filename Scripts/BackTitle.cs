using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackTitle : MonoBehaviour
{

    [SerializeField]
    TimeCount timeCount;

    private float time;

    private void Start()
    {
        time = timeCount.time;
    }

    public void BackToTitle()
    {
        time = Time.timeScale = 1;
        SceneManager.LoadScene("TitleScene");
    }
}
