using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;


public class AdvertisementGenerator : MonoBehaviour
{
    private int adv_Count;
    private string gameID = "3445651";  //  Google ID
    private bool advMode = true;

    public void Start()
    {
        Advertisement.Initialize(gameID, advMode);
    }



    public void CousingAdver()
    {
        adv_Count = Random.Range(0, 2);
       // Debug.Log(adv_Count);

        if(adv_Count == 1 && Advertisement.IsReady())
        {
            Advertisement.Show();
           
        }
        
    }
}
