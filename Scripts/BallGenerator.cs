using System.Collections;
using System.Collections.Generic;   // リストを使うのに必要
using UnityEngine;
using UnityEngine.UI;

public class BallGenerator : MonoBehaviour
{
    public GameObject BallPrefab;
    public Sprite[] BallSprites;

    public GameObject ScoreText;
    private int point = 100;
    private float magnification = 1.0f;

    public GameObject RefreshButton;

    public bool isPlaying = true;


    private GameObject FirstBall;   //  最初にドラッグしたボールを格納
    private GameObject LastBall;    //  最後にドラッグしたボールを格納
    private string CurrentBallName;     //  ボールの名前を格納



    [SerializeField]
    ColorChanger colorChanger;

  

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

            //  クリックし終えたとき
            else if (Input.GetMouseButtonUp(0))
            {
                OnDragEnd();
            }
            //  OnDragStart()実行後
            else if (FirstBall != null)
            {
                OnDragging();
            }
        }
        
            
       
        

    }

    IEnumerator DropBall(int count) //　コルーチン
    {

        if(count == 50)
        {
            StartCoroutine("BindPush");
        }


        for(int i = 0; i < count; i++)
        {
            Vector2 pos = new Vector2(Random.Range(-1.8f, 1.8f), 4.5f);

            //  z軸周りで回転
            GameObject ball = Instantiate(BallPrefab, pos, Quaternion.AngleAxis(Random.Range(-40, 40), Vector3.forward)) as GameObject;

            int spriteID = Random.Range(0, 5);

            ball.name = "Fish" + spriteID;

            SpriteRenderer spriteObject = ball.GetComponent<SpriteRenderer>();
            spriteObject.sprite = BallSprites[spriteID];
            yield return new WaitForSeconds(0.05f);     // 0.05sごとにパズルピースを生成
        }
    }

    IEnumerator BindPush()
    {
        RefreshButton.GetComponent<Button>().interactable = false;
        yield return new WaitForSeconds(5.0f);

        RefreshButton.GetComponent<Button>().interactable = true;

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
            if(HitObject.name == CurrentBallName && LastBall != HitObject)
            {
                //  2つのオブジェクトの距離を取得
                float distance = Vector2.Distance(HitObject.transform.position, LastBall.transform.position);

                if(distance < 1.0f)
                {
                    //  削除対象オブジェクトとして格納
                    LastBall = HitObject;
                    PushToList(HitObject);
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

                
            }

            magnification += (RemoveCount / 10f);

            //  スコア加算
            ScoreText.SendMessage("AddScore", point * RemoveCount * magnification);

            magnification = 1.0f;



            //  ボールを新たに生成
            StartCoroutine(DropBall(RemoveCount + Random.Range(0, 2)));
        }
        else
        {
            // alpha値を元に戻す
            for(int i = 0; i < RemoveCount; i++)
            {
                Debug.Log("reset!");
                colorChanger.ChangeColor(RemovableBallList[i], 1.0f);
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
    }

   


}
