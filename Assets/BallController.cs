using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    // Use this for initialization
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");
    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Hahaha";
        }


    }

    //スコア用

    //スコアを表示するテキスト
    public GameObject ScoreText;
    private int score = 0;

    void OnCollisionEnter(Collision other)
    {
        // タグによって得点を変える
        if (other.gameObject.tag == "SmallStarTag")
        {
            score += 100;
        }
        else if (other.gameObject.tag == "LargeStarTag")
        {
            score += 150;
        }
        else if (other.gameObject.tag == "SmallCloudTag" || other.gameObject.tag == "LargeCloudTag")
        {
            score += 300;
        }

        ScoreText.GetComponent<Text>().text = "Score : " + score.ToString();
    }

}