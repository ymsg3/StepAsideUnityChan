using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    // carPrefab������
    public GameObject carPrefab;
    // coinPrefab������
    public GameObject coinPrefab;
    // cornPrefab������
    public GameObject cornPrefab;
    // �X�^�[�g�n�_
    private int startPos = 80;
    // �S�[���n�_
    private int goalPos = 360;
    // �A�C�e�����o��x�����͈̔�
    private float posRange = 3.4f;

    // ���W�ۑ�p�F
    // ���j�e�B�����̃I�u�W�F�N�g�擾�p
    private GameObject unitychan;
    // ���Ԋu�𐔂���
    private int distanceCnt = 0;

    // Use this for initialization
    void Start ()
    {
        // ���W�ۑ�p�F
        // ���j�e�B�����̃I�u�W�F�N�g���擾
        unitychan = transform.root.gameObject;
    }

    // Update is called once per frame
    void Update ()
    {

        // ���W�ۑ�p�F
        // ���j�e�B����񂩂�40�`50m���x��܂ł̈ʒu�ɃA�C�e���𐶐�

        // ���j�e�B�����̌��݈ʒu
        float unityZ = unitychan.transform.position.z;
        // �`��͈͂̏�����v�Z���đ��
        float drowZMax = unityZ + 45;

        // �`��͈͏�����`��J�n�ʒu���O���A�S�[���ʒu�𒴂��Ă�����A�������Ȃ�
        if (drowZMax < startPos || goalPos < drowZMax)
        {
            return;
        }

        // ���j�e�B�����̌��݈ʒu��15�Ŋ���؂�鎞�A�����J�E���g�𑝂₷
        if (Mathf.Round (unityZ) % 15 == 0)
        {
            distanceCnt++;
        }
        else
        {
            // ����؂�Ȃ��Ȃ�����J�E���g�����Z�b�g
            distanceCnt = 0;
        }

        // �J�E���g���m�F���A15m�Ɉ�x�̊Ԋu�ŕ`�揈���ɐi��
        if (distanceCnt != 1)
        {
            return;
        }

        // �`�揈��
        int num = Random.Range (1, 11);
        if (num <= 2)
        {
            // �R�[����x�������Ɉ꒼���ɐ���
            for (float j = -1; j <= 1; j += 0.4f)
            {
                GameObject cone = Instantiate (cornPrefab);
                cone.transform.position = new Vector3 (4 * j, cone.transform.position.y, drowZMax);
            }
        }
        else
        {
            // ���[�����ƂɃA�C�e���𐶐�
            for (int j = -1; j <= 1; j++)
            {
                // �A�C�e���̎�ނ����߂�
                int item = Random.Range (1, 11);
                // �A�C�e����u��z���W�̃I�t�Z�b�g�������_���ɐݒ�
                int offsetZ = Random.Range (-5, 6);
                // 60%�R�C���z�u:30%�Ԕz�u:10%�����Ȃ�
                if (1 <= item && item <= 6)
                {
                    // �R�C���𐶐�
                    GameObject coin = Instantiate (coinPrefab);
                    coin.transform.position = new Vector3 (posRange * j, coin.transform.position.y, drowZMax + offsetZ);
                }
                else if (7 <= item && item <= 9)
                {
                    // �Ԃ𐶐�
                    GameObject car = Instantiate (carPrefab);
                    car.transform.position = new Vector3 (posRange * j, car.transform.position.y, drowZMax + offsetZ);
                }
            }
        }

    }

}
