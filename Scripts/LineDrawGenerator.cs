using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawGenerator : MonoBehaviour
{
   public GameObject LineTrack;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject CloneLineTrack = Instantiate(LineTrack);
            Debug.Log("作ったよ");
        }
    }
}
