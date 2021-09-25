using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{   //【定数の設定】（レベル設計で変更可能）
    const float WALK_FORCE = 7;  // 横に進む時にかける力の強さ
    const float MAX_WALK_SPEED = 1;  // 横に進む速度の最大値

    //【Unity Editorから設定するPublic変数】
    public Rigidbody2D rigidBody;  // Rigidbody2Dコンポーネントの変数や関数の呼び出し用
    private int direction = 1;  // 敵（サソリ）の横向きの方向を示すdirection変数、初期値を右
    // （右方向を向いている場合１、左方向を向いている場合ー１）
    private int stopCount = 0;  // 壁にぶつかった場合、数フレーム後に反転を行うためのカウント用変数

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // speedx変数に敵（サソリ）の横方向のスピード（絶対値）を代入
        float speedx = Mathf.Abs(rigidBody.velocity.x);

        // 横方向のスピードがMAX_WALK_SPEEDのスピードより小さい場合
        if (speedx < MAX_WALK_SPEED)
        {
            // 敵（サソリ）にdirection変数が１の場合は右に、ー１の場合は左に力をかける
            rigidBody.AddForce(transform.right * direction * WALK_FORCE);
        }

        // direction変数が１の場合は右に、ー１の場合は左に、敵（サソリ）のSprite（絵）の向きを変える
        transform.localScale = new Vector3(0.1f * direction, 0.1f, 1);
        if (rigidBody.velocity.x == 0)
        {
            // ゲーム開始時や壁にぶつかり反転した際はスピードがゼロなので、
            // 少し待つ機能がないと永遠に反転を繰り返してしまう。
            stopCount++;
            // スピードがゼロの状態が一定フレーム続いたら
            if (stopCount >= 10)
            {
                // direction変数にー１をかけて方向を逆にする
                direction = direction * -1;
                // スピードがゼロの状態をカウントするカウンターをゼロリセットする
                stopCount = 0;
            }
        }

    }
}
