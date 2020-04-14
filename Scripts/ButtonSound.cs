using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip buttonBack;
    public AudioClip decisionButton;
    public AudioClip warningSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBackButton()
    {
        audioSource.PlayOneShot(buttonBack);
    }

    public void OnDecisionButton()
    {
        audioSource.PlayOneShot(decisionButton);
    }

    public void WarningSound()
    {
        audioSource.PlayOneShot(warningSound);
    }
}
