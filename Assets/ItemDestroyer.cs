using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start ()
    {

    }

    // Update is called once per frame
    void Update ()
    {

    }

    // �g���K�[���[�h�ő��̃I�u�W�F�N�g�ƐڐG�����ꍇ�̏���
    private void OnTriggerEnter (Collider other)
    {
        // �ۑ�p�F��ʊO�ɏo���A�C�e���i�R�C���A�ԁA�R�[���j�̃I�u�W�F�N�g��j��
        string tagName = other.gameObject.tag;
        if (tagName == "CoinTag" || tagName == "CarTag" || tagName == "TrafficConeTag")
        {
            Destroy (other.gameObject);
        }
    }

}
