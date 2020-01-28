using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallChanger : MonoBehaviour
{

    [SerializeField]
    BallGenerator ballGenerator;

    
    public void BallChange()
    {
        // 配列にタグ「Respawn」がついているオブジェクトを全部格納
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Respawn");

        //  全部取り出して、削除する
        foreach (GameObject gameobejct in balls)
        {
            Destroy(gameobejct);
        }

        ballGenerator.SendMessage("DropBall", 50);

    }

}
