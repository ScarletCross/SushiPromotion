using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UzuTrriger : MonoBehaviour
{
    [SerializeField]
    BallChanger ballChanger;

    public GameObject uzu;

    public float time = 0f;

    public float timeDelta = 0f;

    private bool uzuFlag = false;

   


    // Start is called before the first frame update
    void Start()
    {
        uzu.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeDelta += Time.deltaTime;

        /*  if(time >= 5)
          {
              Debug.Log("succes");
              time = 0;

             // uzu.SetActive(true);



             // uzu.SetActive(false);

          }

      */

     /*  if (isUzuFlag())
        {
            uzu.SetActive(true);
            time = 0;

            if(timeDelta >= 10f)
            {
                uzu.SetActive(false);
                uzuFlag = false;
                timeDelta = 0f;
            }

            
        }
        
        */



     /*  if (ballChanger.BallChange())
        {
            uzu.SetActive(true);
            time = 0;

            if (timeDelta >= 10f)
            {
                uzu.SetActive(false);
                uzuFlag = false;
                timeDelta = 0f;
            }


        }
        */



        /*   else
           {
               uzu.SetActive(false);
           }

       */

    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(5f);
    }

    public bool isUzuFlag()
    {
        //  
        if (time >= 5)
        {
            uzuFlag = true;

           // uzu.SetActive(true);
        
            return uzuFlag;
            
        }
        else
        {
            return false;
        }

        

    }

}
