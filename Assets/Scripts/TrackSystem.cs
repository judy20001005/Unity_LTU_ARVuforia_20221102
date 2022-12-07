using UnityEngine;
using UnityEngine.AI;

public class TrackSystem : MonoBehaviour
{
    [SerializeField, Header("追蹤速度"), Range(0, 5)]
    private float speed = 2;
    [SerializeField, Header("停止距離"), Range(0, 10)]
    private float stoppintDistance = 5;

    private string nameTarget = "DogPolyart";
    private Transform pointTarget;
    private NavMeshAgent nma;
    private Animator ani;
    private string parWalk = "走路";



    private void Awake()
    {
        //目標物件的座標資訊 = 遊戲物件,尋找(目標物名稱)轉型為變形
        pointTarget = GameObject.Find(nameTarget).transform;

        //nma = 取得元件<導覽網格代理器>() - 將代理器元件存放至 nma
        nma = GetComponent<NavMeshAgent>();
        nma.speed = speed;
        nma.stoppingDistance = stoppintDistance;

        ani = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //更新事件:一秒鐘約60次執行，60FPS(每秒幀數)
    private void Update()
    {
        TrackTarget();
    }

    private void TrackTarget()
    {
        //代理器.設定目的地(目標物件的座標)
        nma.SetDestination(pointTarget.position);

        // velocity 三維加速度
        //magnitude 三維向量的長度 - 將三維向量轉為浮點數
        //print($"<color=yellow>代理器的加速度:{nma.velocity.magnitude}</color>");
        ani.SetBool(parWalk, nma.velocity.magnitude != 0);
    }
}
