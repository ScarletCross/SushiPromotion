using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewRecordSE : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip newRecordSE;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void NewRecord()
    {
        audioSource.PlayOneShot(newRecordSE);
    }
}
