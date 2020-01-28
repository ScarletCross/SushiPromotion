using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;


public class AdvertisementGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
    }

   
}
