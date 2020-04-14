using System.Collections;
using System.Collections.Generic;   
using UnityEngine;
using UnityEngine.UI;

public class BallGenerator : MonoBehaviour
{
    public GameObject BallPrefab;
    public Sprite[] BallSprites;

    public GameObject ScoreText;
    public static int point = 1000;
    private float magnification = 1.0f;

    public GameObject RefreshButton;
   

    public bool isPlaying = true;

    private int generateCount = 0;

    private float alpha = 0.5f;

    

    

   


    private GameObject FirstBall;   //  最初にドラッグしたボールを格納
    private GameObject LastBall;    //  最後にドラッグしたボールを格納
    private string CurrentBallName;     //  ボールの名前を格納



    [SerializeField]
    ColorChanger colorChanger;

    [SerializeField]
    UzuTrriger uzuTrriger;

    [SerializeField]
    SoundShot soundShot;

    [SerializeField]
    AlphaCheck alphaCheck;

  

    //  削除するボールを格納
    List<GameObject> RemovableBallList = new List<GameObject>();



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DropBall(50));   //  コルーチンの実行
        

    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            if (Input.GetMouseButtonDown(0) && FirstBall == null)
            {
                OnDragStart(); 
            }          
            else if (Input.GetMouseButtonUp(0))  //  クリックし終えたとき
            {
                OnDragEnd();
            }
            else if (FirstBall != null)  //  OnDragStart()実行後
            {
                OnDragging();
            }
        }
    }

    IEnumerator DropBall(int count)
    {

        if(count == 50)
        {
            StartCoroutine("BindPush");
            StartCoroutine("UzushioActivate");
        }


        for(int i = 0; i < count; i++)
        {
            Vector2 pos = new Vector2(Random.Range(-1.8f, 1.8f), 4.5f);

            //  z軸周りで回転
            GameObject ball = Instantiate(BallPrefab, pos, Quaternion.AngleAxis(Random.Range(-40, 40), Vector3.forward)) as GameObject;

            // 難易度調整
            int spriteID = Random.Range(0, BallSprites.Length);

            ball.name = "Fish" + spriteID;

            SpriteRenderer spriteObject = ball.GetComponent<SpriteRenderer>();
            spriteObject.sprite = BallSprites[spriteID];
            yield return new WaitForSeconds(0.05f);     // 0.05sごとにパズルピースを生成
        }
    }

    IEnumerator BindPush()
    {
        RefreshButton.GetComponent<Button>().interactable = false;  //  うずしおボタンが使えない状態
        yield return new WaitForSeconds(5.0f);

        RefreshButton.GetComponent<Button>().interactable = true;   //  うずしおボタンが使える状態
    }

    IEnumerator UzushioActivate() // うずしお効果エフェクトのオン/オフ
    {
        //  うずしお効果エフェクトのオン
        uzuTrriger.uzu.SetActive(true);

        yield return new WaitForSeconds(3.8f);


        // うずしお効果エフェクトのオフ
        uzuTrriger.uzu.SetActive(false);
    }

    

    public void OnDragStart()
    {
        //  クリックした位置をワールド座標に変換
        RaycastHit2D Hit2D = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if(Hit2D.collider != null)  // レーザーを飛ばしてコライダーに当たっていたら↓
        {
            GameObject HitObject = Hit2D.collider.gameObject;

            //  オブジェクト名を前方一致で判定
            string BallName = HitObject.name;

            if (BallName.StartsWith("Fish"))
            {
                //  それぞれ格納
                FirstBall = HitObject;

                LastBall = HitObject;

                //  名前を格納
                CurrentBallName = HitObject.name;

                RemovableBallList = new List<GameObject>(); //  削除対象オブジェクトリストの初期化

                PushToList(HitObject);  //  削除対象オブジェクトを格納
                generateCount = 0;
            }
        }

    }

    public void OnDragging()
    {
        RaycastHit2D Hit2D = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if(Hit2D.collider != null)
        {
            GameObject HitObject = Hit2D.collider.gameObject;


            //  同じ名前のボールをクリックし、かつ、LastBallとは別オブジェクトの時
            if(HitObject.name == CurrentBallName && LastBall != HitObject )
            {
                //  2つのオブジェクトの距離を取得
                float distance = Vector2.Distance(HitObject.transform.position, LastBall.transform.position);

                // alphaCheck.DefaultName();

                if (distance < 1.2f && gameObject.name != "pushed")
                {
                    //  削除対象オブジェクトとして格納
                    LastBall = HitObject;
                    
                    PushToList(LastBall);
                    
                }

            }
        }
    }

    public void OnDragEnd()
    {
       
        int RemoveCount = RemovableBallList.Count;

        if(RemoveCount >= 3)
        {

            for(int i = 0; i < RemoveCount; i++)
            {
                Destroy(RemovableBallList[i]);
                //soundShot.BallDestroySound();
            }

            magnification += ((RemoveCount / 10f) + (BallSprites.Length / 10f));         

            if(generateCount == 0)
            {
                //  ボールを新たに生成
                StartCoroutine(DropBall(RemoveCount));

                //  スコア加算
                ScoreText.SendMessage("AddScore", point * RemoveCount * magnification);

                magnification = 1.0f;

                
                generateCount = 1;

                if(RemoveCount <= 5)
                {
                    soundShot.BallDestroySound();
                }
                else if(RemoveCount <= 7)
                {
                    soundShot.BallDestroyGood();
                }
                else if(RemoveCount <= 9)
                {
                    soundShot.BallDestroyGreat();
                }
                else
                {
                    soundShot.BallDestroyPerfect();
                }
            }           
        }
        else
        {
            // alpha値を元に戻す
            for(int i = 0; i < RemoveCount; i++)
            {             
                colorChanger.ChangeColor(RemovableBallList[i], 1.0f);

                // gameObject.name = CurrentBallName;

             //   ReverseName(CurrentBallName);

               // gameObject.name = alphaCheck.DefaultName();
                //Debug.Log(gameObject.name);
            }

            magnification = 1.0f;   // うずしおボタンが押されたときにスコア加算されないようにする

        }

        FirstBall = null;
        LastBall = null;
    }


    public void PushToList(GameObject gameObject)
    {
        RemovableBallList.Add(gameObject);

        // alpha値を半減
        colorChanger.ChangeColor(gameObject, 0.5f);
        //gameObject.name = "pushed";

        StartCoroutine("NameChanger");
        
       // LastBall.tag = "Pushed";
        soundShot.BallLinkSound();
    }

    IEnumerator NameChanger()
    {
        gameObject.name = "pushed";
        Debug.Log(gameObject.name);

        yield return new WaitForSeconds(0.05f);

        gameObject.name = CurrentBallName;
        Debug.Log(gameObject.name);
    }

    public void Dropper()
    {
        StartCoroutine(DropBall(50));
    }

   /* public string DefaultName()
    {
        SpriteRenderer spriteObject = gameObject.GetComponent<SpriteRenderer>();
         
        Debug.Log(spriteObject.sprite);
        

        return LastBall.name;
    }*/

    public void ReverseName(string defaultName)
    {
        gameObject.name = CurrentBallName;
    }
   
}
