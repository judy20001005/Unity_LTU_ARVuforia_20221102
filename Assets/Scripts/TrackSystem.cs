using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSystem : MonoBehaviour
{
    [SerializeField, Header("追蹤速度"), Range(0, 5)]
    private float speed = 2;
    [SerializeField, Header("停止距離"), Range(0, 10)]
    private float stoppintDistance = 5;

    private string nameTarget = "大吉";
    private Transform pointTarget;
    private UnityEngine.AI.NavMeshAgent nma;


    private void Awake()
    {
        //目標物件的座標資訊 = 遊戲物件,尋找(目標物名稱)轉型為變形
        pointTarget = GameObject.Find(nameTarget).transform;
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
