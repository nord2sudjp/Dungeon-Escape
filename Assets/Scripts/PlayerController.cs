using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //【定数の設定】（レベル設計で変更可能）
    const float WALK_FORCE = 9;  // 横に進む時にかける力の強さ
    const float JUMP_FORCE = 420;  // ジャンプ時にかける力の強さ
    const float MAX_WALK_SPEED = 1.3f;  // 横に進む速度の最大値

    public Rigidbody2D rigidBody;  // Rigidbody2Dコンポーネントの変数や関数の呼び出し用

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // スペースキーかマウスをクリック又はスマホ画面をタップした場合
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            // 上方向の速度がゼロの場合
            if (rigidBody.velocity.y == 0)
            {
                // Playerに上向きの力をかける
                rigidBody.AddForce(transform.up * JUMP_FORCE);
                // アニメーションのパラメータonGroundにfalseをセット
            }
        }

        int direction = 0; // Playerの横向きの方向を示すdirection変数、初期値をゼロ
        // （右方向を向いている場合１、左方向を向いている場合ー１）
        // （毎フレーム、方向を以下で確認）

        // 右矢印が押された場合、direction変数を１に
        if (Input.GetKey(KeyCode.RightArrow)) direction = 1;
        // 左矢印が押された場合、direction変数をー１に
        if (Input.GetKey(KeyCode.LeftArrow)) direction = -1;
        // スマホが右方向に一定角度以上傾けられた場合、direction変数を１に

        float speedx = Mathf.Abs(rigidBody.velocity.x);

        // 横方向のスピードがMAX_WALK_SPEEDのスピードより小さい場合
        if (speedx < MAX_WALK_SPEED)
        {
            // Playerにdirection変数が１の場合は右に、ー１の場合は左に力をかける
            rigidBody.AddForce(transform.right * direction * WALK_FORCE);
        }

        // direction変数がゼロ以外の場合
        if (direction != 0)
        {
            // direction変数が１の場合は右に、ー１の場合は左に、PlayerのSprite（絵）の向きを変える
            transform.localScale = new Vector3(0.1f * direction, 0.1f, 1);
        }
    }
}
