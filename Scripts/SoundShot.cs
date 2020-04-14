using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundShot : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip ballDestroy;
    public AudioClip ballLink;
    public AudioClip endWhistle;
    public AudioClip uzusio;
    public AudioClip good;
    public AudioClip great;
    public AudioClip perfect;
    public AudioClip poseButton;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void BallDestroySound()
    {
        audioSource.PlayOneShot(ballDestroy);
    }

    public void BallDestroyGood()
    {
        audioSource.PlayOneShot(good);
    }

    public void BallDestroyGreat()
    {
        audioSource.PlayOneShot(great);
    }

    public void BallDestroyPerfect()
    {
        audioSource.PlayOneShot(perfect);
    }

    public void BallLinkSound()
    {
        audioSource.PlayOneShot(ballLink);
    }

     public void EndWhistleSound()
    {
        audioSource.PlayOneShot(endWhistle);
    }

    public void EndWhistleSoundEnd()
    {
        audioSource.Stop();
    }

    public void Uzusio()
    {
        audioSource.PlayOneShot(uzusio);           
    }

    public void PoseButton()
    {
        audioSource.PlayOneShot(poseButton);
    }



}
