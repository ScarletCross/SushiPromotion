using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoseMenuSE : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip cancelButton;
    public AudioClip title_replayButton;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    

    public void CancelButton()
    {
        audioSource.PlayOneShot(cancelButton);
    }

    public void Title_ReplayButton()
    {
        audioSource.PlayOneShot(title_replayButton);
    }
}
