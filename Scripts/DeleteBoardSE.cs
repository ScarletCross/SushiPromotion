using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBoardSE : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip deleteButton;
    public AudioClip backButton;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }



    public void DeleteButton()
    {
        audioSource.PlayOneShot(deleteButton);
    }

    public void BackButton()
    {
        audioSource.PlayOneShot(backButton);
    }

}
