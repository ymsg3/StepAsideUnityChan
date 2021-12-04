using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    // carPrefabを入れる
    public GameObject carPrefab;
    // coinPrefabを入れる
    public GameObject coinPrefab;
    // cornPrefabを入れる
    public GameObject cornPrefab;
    // スタート地点
    private int startPos = 80;
    // ゴール地点
    private int goalPos = 360;
    // アイテムを出すx方向の範囲
    private float posRange = 3.4f;

    // 発展課題用：
    // ユニティちゃんのオブジェクト取得用
    private GameObject unitychan;
    // 一定間隔を数える
    private int distanceCnt = 0;

    // Use this for initialization
    void Start ()
    {
        // 発展課題用：
        // ユニティちゃんのオブジェクトを取得
        unitychan = transform.root.gameObject;
    }

    // Update is called once per frame
    void Update ()
    {

        // 発展課題用：
        // ユニティちゃんから40～50m程度先までの位置にアイテムを生成

        // ユニティちゃんの現在位置
        float unityZ = unitychan.transform.position.z;
        // 描画範囲の上限を計算して代入
        float drowZMax = unityZ + 45;

        // 描画範囲上限が描画開始位置より前か、ゴール位置を超えていたら、何もしない
        if (drowZMax < startPos || goalPos < drowZMax)
        {
            return;
        }

        // ユニティちゃんの現在位置が15で割り切れる時、距離カウントを増やす
        if (Mathf.Round (unityZ) % 15 == 0)
        {
            distanceCnt++;
        }
        else
        {
            // 割り切れなくなったらカウントをリセット
            distanceCnt = 0;
        }

        // カウントを確認し、15mに一度の間隔で描画処理に進む
        if (distanceCnt != 1)
        {
            return;
        }

        // 描画処理
        int num = Random.Range (1, 11);
        if (num <= 2)
        {
            // コーンをx軸方向に一直線に生成
            for (float j = -1; j <= 1; j += 0.4f)
            {
                GameObject cone = Instantiate (cornPrefab);
                cone.transform.position = new Vector3 (4 * j, cone.transform.position.y, drowZMax);
            }
        }
        else
        {
            // レーンごとにアイテムを生成
            for (int j = -1; j <= 1; j++)
            {
                // アイテムの種類を決める
                int item = Random.Range (1, 11);
                // アイテムを置くz座標のオフセットをランダムに設定
                int offsetZ = Random.Range (-5, 6);
                // 60%コイン配置:30%車配置:10%何もなし
                if (1 <= item && item <= 6)
                {
                    // コインを生成
                    GameObject coin = Instantiate (coinPrefab);
                    coin.transform.position = new Vector3 (posRange * j, coin.transform.position.y, drowZMax + offsetZ);
                }
                else if (7 <= item && item <= 9)
                {
                    // 車を生成
                    GameObject car = Instantiate (carPrefab);
                    car.transform.position = new Vector3 (posRange * j, car.transform.position.y, drowZMax + offsetZ);
                }
            }
        }

    }

}
