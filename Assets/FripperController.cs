using UnityEngine;
using System.Collections;

public class FripperController : MonoBehaviour
{
    //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

    private int leftID = -1;
    private int rightID = -1;

    // Use this for initialization
    void Start()
    {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {

        //左矢印キーを押した時左フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        //右矢印キーを押した時右フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        //矢印キー離された時フリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }



        //スマホ用
        foreach(Touch t in Input.touches)
        {
            if (t.phase == TouchPhase.Began)
            {
                if (t.position.x > Screen.width / 2 && tag == "RightFripperTag" && rightID == -1)
                {
                    Debug.Log("右タップ押した時フリッパーを動かす");
                    rightID = t.fingerId;
                    SetAngle(this.flickAngle);
                }
                else if (t.position.x <= Screen.width / 2 && tag == "LeftFripperTag" && leftID == -1)
                {
                    Debug.Log("左タップ押した時フリッパーを動かす");
                    leftID = t.fingerId;
                    SetAngle(this.flickAngle);
                }

            }


            //タップが離された時フリッパーを元に戻す
            if (t.phase == TouchPhase.Ended)
            {
                if (t.fingerId == rightID && tag == "RightFripperTag")
                {
                    rightID = -1;
                    Debug.Log("右タップ離した時フリッパーを戻す");
                    SetAngle(this.defaultAngle);
                }
                else if (t.fingerId == leftID && tag == "LeftFripperTag")
                {
                    leftID = -1;
                    Debug.Log("左タップ離した時フリッパーを戻す");
                    SetAngle(this.defaultAngle);
                }

            }
        }

    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}