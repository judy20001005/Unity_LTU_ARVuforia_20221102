using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    #region 資料
    //欄位屬性 field property:欄位資料額外輔助功能
    //SerializeField 序列化欄位，將私人資料儲存於記憶體並顯示
    //Header 標題
    //Range 範圍:限制數量範圍

    //預置物可以使用gameobject 資料類型
    [SerializeField, Header("怪物預置物")]
    private GameObject prefabEnemy;

    //浮點數 float 帶有小數點的正負數值，必須加f或F
    [SerializeField, Header("生成怪物間隔"), Range(0, 5)]
    private float spawnInterval = 2.5f;

    //存取座標資料類型 Transform
    //資料類型[] - 陣列:存放多筆資料
    [SerializeField, Header("怪物生成點陣列")]
    private Transform[] spawnPoints;
    #endregion

    //喚醒事件:播放遊戲時執行一次ˋ
    private void Awake()
    {
        //呼叫生成敵人方法
        SpawnEnemy();
        //重複延遲呼叫(方法名稱，延遲時間，重複頻率)
        InvokeRepeating("SpawnEnemy", 0, spawnInterval);
    }

    private void SpawnEnemy()
    {
        //隨機取得一個怪物生成點
        //隨機整數 = 隨機.範圍(最小值，最大值) 整數不會等於最大值
        int random = Random.Range(0, spawnPoints.Length);
        //print("隨機值:" + random);

        //生成(物件，隨機生成點的座標，隨機生成點的角度);
        Instantiate(
            prefabEnemy,
            spawnPoints[random].position,
            spawnPoints[random].rotation);
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
