using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TransitionController : MonoBehaviour
{

    public enum Scenes
    {
        Null,
        Title,
        Game,
        Result
    }

    public enum State
    {
        FadeIn,
        Wait,
        FadeOut
    }

    public Scenes scenes = Scenes.Null;
    public Image fadeImage;
    public float fadeSpeed = 1.0f;

    private Vector3 fadeImageScale;
    private State state;
    private float fadeScale;
    private bool isFadeOut;

    private bool sceneChangeFlag;




    // Start is called before the first frame update
    void Start()
    {
        sceneChangeFlag = false;
        fadeImage.rectTransform.SetAsLastSibling();

        state = State.FadeIn;
        fadeImageScale = fadeImage.rectTransform.localScale;

        SetupFade(false);

    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.FadeIn:
                if (FadeUpdate())
                {
                    state = State.Wait;
                }
                break;
            case State.Wait:
                if(sceneChangeFlag || Input.GetMouseButtonDown(0))
                {
                    SetupFade(true);
                    state = State.FadeOut;
                }
                break;
            case State.FadeOut:
                if (FadeUpdate())
                {
                    ChangeScene();
                }
                break;
        }
    }

    public void ChangeScene()
    {
        switch(scenes)
        {
            case Scenes.Title:
                SceneManager.LoadScene("TitleScene");
                break;
            case Scenes.Game:
                SceneManager.LoadScene("GameScene");
                break;
            case Scenes.Result:
                SceneManager.LoadScene("ResultScene");
                break;
        }
    }


    private void SetupFade(bool isOut)
    {
        isFadeOut = isOut;
        fadeScale = 0.0f;

        if (isOut)
        {
            fadeImage.gameObject.SetActive(true);
        }
    }

    private bool FadeUpdate()
    {
        fadeScale += fadeSpeed * Time.deltaTime;

        if(fadeScale >= 1.0f)
        {
            if (isFadeOut)
            {
                fadeImage.rectTransform.localScale = fadeImageScale;
            }
            else
            {
                fadeImage.gameObject.SetActive(false);
            }

            return true;
        }

        float scaleRate = ((isFadeOut) ? fadeScale : (1.0f - fadeScale));
        fadeImage.rectTransform.localScale = new Vector3(fadeImageScale.x * scaleRate, fadeImageScale.y * scaleRate, fadeImageScale.z);

        return false;

    }

    public void RequestSceneChange()
    {
        sceneChangeFlag = true;
    }

    public void RequestSceneChange(Scenes sce)
    {
        scenes = sce;
        sceneChangeFlag = true;
    }

    public bool isWaiting()
    {
        return (state == State.Wait);
    }
}
