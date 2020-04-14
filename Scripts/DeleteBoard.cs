using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteBoard : MonoBehaviour
{
    public GameObject deleteBoard;
    public GameObject titleButton;
    //  public GameObject backResultButton;
    public GameObject cancelButton;
    public GameObject excutionButton;

    public GameObject high1;
    public GameObject high2;
    public GameObject high3;

    // Start is called before the first frame update
    void Start()
    {
       

        deleteBoard.SetActive(false);
        cancelButton.SetActive(false);
        excutionButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDeleteBoard()
    {
        deleteBoard.SetActive(true);
        cancelButton.SetActive(true);
        excutionButton.SetActive(true);

        titleButton.SetActive(false);
        high1.SetActive(false);
        high2.SetActive(false);
        high3.SetActive(false);

        //  backResultButton.SetActive(false);

    }


}
