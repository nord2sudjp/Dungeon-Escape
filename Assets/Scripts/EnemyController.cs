using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{   //�y�萔�̐ݒ�z�i���x���݌v�ŕύX�\�j
    const float WALK_FORCE = 7;  // ���ɐi�ގ��ɂ�����͂̋���
    const float MAX_WALK_SPEED = 1;  // ���ɐi�ޑ��x�̍ő�l

    //�yUnity Editor����ݒ肷��Public�ϐ��z
    public Rigidbody2D rigidBody;  // Rigidbody2D�R���|�[�l���g�̕ϐ���֐��̌Ăяo���p
    private int direction = 1;  // �G�i�T�\���j�̉������̕���������direction�ϐ��A�����l���E
    // �i�E�����������Ă���ꍇ�P�A�������������Ă���ꍇ�[�P�j
    private int stopCount = 0;  // �ǂɂԂ������ꍇ�A���t���[����ɔ��]���s�����߂̃J�E���g�p�ϐ�

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // speedx�ϐ��ɓG�i�T�\���j�̉������̃X�s�[�h�i��Βl�j����
        float speedx = Mathf.Abs(rigidBody.velocity.x);

        // �������̃X�s�[�h��MAX_WALK_SPEED�̃X�s�[�h��菬�����ꍇ
        if (speedx < MAX_WALK_SPEED)
        {
            // �G�i�T�\���j��direction�ϐ����P�̏ꍇ�͉E�ɁA�[�P�̏ꍇ�͍��ɗ͂�������
            rigidBody.AddForce(transform.right * direction * WALK_FORCE);
        }

        // direction�ϐ����P�̏ꍇ�͉E�ɁA�[�P�̏ꍇ�͍��ɁA�G�i�T�\���j��Sprite�i�G�j�̌�����ς���
        transform.localScale = new Vector3(0.1f * direction, 0.1f, 1);
        if (rigidBody.velocity.x == 0)
        {
            // �Q�[���J�n����ǂɂԂ��蔽�]�����ۂ̓X�s�[�h���[���Ȃ̂ŁA
            // �����҂@�\���Ȃ��Ɖi���ɔ��]���J��Ԃ��Ă��܂��B
            stopCount++;
            // �X�s�[�h���[���̏�Ԃ����t���[����������
            if (stopCount >= 10)
            {
                // direction�ϐ��Ɂ[�P�������ĕ������t�ɂ���
                direction = direction * -1;
                // �X�s�[�h���[���̏�Ԃ��J�E���g����J�E���^�[���[�����Z�b�g����
                stopCount = 0;
            }
        }

    }
}
