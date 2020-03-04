using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTrack : MonoBehaviour
{
    private Vector3 StartPosition;
    private Vector3 EndPosition;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
             this.StartPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);

            gameObject.transform.position = Camera.main.ScreenToWorldPoint(StartPosition);
            //Debug.Log(gameObject.transform.position);

            //DeletePosition();

        }

        if (Input.GetMouseButtonUp(0))
        {
            Destroy(gameObject);
            Debug.Log("壊したよ");
        }

       /* if (Input.GetMouseButtonUp(0))
        {
            
            //Vector3 screenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
            //gameObject.transform.position = Camera.main.ScreenToWorldPoint(screenPosition - transform.position);
            gameObject.GetComponent<TrailRenderer>().time = 0f;
            Debug.Log("ラインが消えたよ");
           // Debug.Log(screenPosition);

            StartCoroutine("OnLineTrack");

        }*/
    }

   /* IEnumerator OnLineTrack()
    {

        gameObject.GetComponent<TrailRenderer>().time = 0.5f;
        yield return new WaitForSeconds(0.5f);
        Debug.Log("ラインが生成できるようになったよ");
    }*/

   /* public void DeletePosition()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Destroy(gameObject);

            this.EndPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);

            gameObject.transform.position = Camera.main.ScreenToWorldPoint(EndPosition);

            Vector3 distance = EndPosition - StartPosition;
            Debug.Log("距離は" + distance);

            //Vector3 screenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
            //gameObject.transform.position = Camera.main.ScreenToWorldPoint(screenPosition - transform.position);
            gameObject.GetComponent<TrailRenderer>().time = 0f;
            Debug.Log("ラインが消えたよ");
            // Debug.Log(screenPosition);

            StartCoroutine("OnLineTrack");

        }
        
    }*/

}
