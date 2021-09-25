using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //�y�萔�̐ݒ�z�i���x���݌v�ŕύX�\�j
    const float WALK_FORCE = 9;  // ���ɐi�ގ��ɂ�����͂̋���
    const float JUMP_FORCE = 420;  // �W�����v���ɂ�����͂̋���
    const float MAX_WALK_SPEED = 1.3f;  // ���ɐi�ޑ��x�̍ő�l

    public Rigidbody2D rigidBody;  // Rigidbody2D�R���|�[�l���g�̕ϐ���֐��̌Ăяo���p

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �X�y�[�X�L�[���}�E�X���N���b�N���̓X�}�z��ʂ��^�b�v�����ꍇ
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            // ������̑��x���[���̏ꍇ
            if (rigidBody.velocity.y == 0)
            {
                // Player�ɏ�����̗͂�������
                rigidBody.AddForce(transform.up * JUMP_FORCE);
                // �A�j���[�V�����̃p�����[�^onGround��false���Z�b�g
            }
        }

        int direction = 0; // Player�̉������̕���������direction�ϐ��A�����l���[��
        // �i�E�����������Ă���ꍇ�P�A�������������Ă���ꍇ�[�P�j
        // �i���t���[���A�������ȉ��Ŋm�F�j

        // �E��󂪉����ꂽ�ꍇ�Adirection�ϐ����P��
        if (Input.GetKey(KeyCode.RightArrow)) direction = 1;
        // ����󂪉����ꂽ�ꍇ�Adirection�ϐ����[�P��
        if (Input.GetKey(KeyCode.LeftArrow)) direction = -1;
        // �X�}�z���E�����Ɉ��p�x�ȏ�X����ꂽ�ꍇ�Adirection�ϐ����P��

        float speedx = Mathf.Abs(rigidBody.velocity.x);

        // �������̃X�s�[�h��MAX_WALK_SPEED�̃X�s�[�h��菬�����ꍇ
        if (speedx < MAX_WALK_SPEED)
        {
            // Player��direction�ϐ����P�̏ꍇ�͉E�ɁA�[�P�̏ꍇ�͍��ɗ͂�������
            rigidBody.AddForce(transform.right * direction * WALK_FORCE);
        }

        // direction�ϐ����[���ȊO�̏ꍇ
        if (direction != 0)
        {
            // direction�ϐ����P�̏ꍇ�͉E�ɁA�[�P�̏ꍇ�͍��ɁAPlayer��Sprite�i�G�j�̌�����ς���
            transform.localScale = new Vector3(0.1f * direction, 0.1f, 1);
        }
    }
}
