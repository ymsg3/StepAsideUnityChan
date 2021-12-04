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

    // トリガーモードで他のオブジェクトと接触した場合の処理
    private void OnTriggerEnter (Collider other)
    {
        // 課題用：画面外に出たアイテム（コイン、車、コーン）のオブジェクトを破棄
        string tagName = other.gameObject.tag;
        if (tagName == "CoinTag" || tagName == "CarTag" || tagName == "TrafficConeTag")
        {
            Destroy (other.gameObject);
        }
    }

}
