using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoseMenu : MonoBehaviour
{
    public GameObject poseMenu;
    public GameObject replayButton;
    public GameObject titleButton;
    public GameObject closeButton;
    public GameObject pauseText;
    public GameObject pausePanel;

    [SerializeField]
    TimeCount timeCount;

    private float time;

 
    

    // Start is called before the first frame update
    void Start()
    {
        poseMenu.SetActive(false);
        replayButton.SetActive(false);
        titleButton.SetActive(false);
        closeButton.SetActive(false);
        pauseText.SetActive(false);
        pausePanel.SetActive(false);

        time = timeCount.time;
    }

    public void OnMenuBoard()
    {
        
        poseMenu.SetActive(true);
        replayButton.SetActive(true);
        titleButton.SetActive(true);
        closeButton.SetActive(true);
        pauseText.SetActive(true);
        pausePanel.SetActive(true);
        

        time = Time.timeScale = 0;
    }


    public void OffMenuBoard()
    {
        poseMenu.SetActive(false);
        replayButton.SetActive(false);
        titleButton.SetActive(false);
        closeButton.SetActive(false);
        pauseText.SetActive(false);
        pausePanel.SetActive(false);

        time = Time.timeScale = 1;
    }

   
}
