using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
/// <summary>
/// 敌方坦克类
/// </summary>
public class Monster : Tank {
    //强迫症格式注释（以下为必要组件）
    private Transform playerTransform;
    private NavMeshAgent myNavMeshAgent;
    //存储坦克姓名数组
    private string[] namesArr;
    
    /// <summary>
    /// idle状态时的目的地随机数
    /// </summary>
    private Vector3 idlePos;
    /// <summary>
    /// idle状态目标切换计时时间
    /// </summary>
    private float idleTime = 3.0f;
    private float idlecurrTime;

    /// <summary>
    /// 坦克死亡效果
    /// </summary>
    public GameObject fxPlayerExp;
    /// <summary>
    /// 炮台
    /// </summary>
    public GameObject tankTurret;
    /// <summary>
    /// 射击距离
    /// </summary>
    public float shootingDistance = 3.0f;
    /// <summary>
    /// 追逐距离
    /// </summary>
    public float chasingDistance = 15.0f;
    /// <summary>
    /// 射击计时器
    /// </summary>
    public float shootingTime = 2;
    private float currTime;
    private enum FSMState
    {
        idle,//待机
        Chasing,//追逐
        Shooting,//射击
    }private FSMState state;
    private void Awake()
    {
        MonstersManager.instance.monsterList.Add(gameObject);
    }
    void Start () {
        myNavMeshAgent = GetComponent<NavMeshAgent>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        state = FSMState.idle;
        //设置初始值
        maxHp = 100;
        hp = maxHp;
        shield = 3;
        namesArr = new string[] { "恶魔枷锁","白色相簿","罪恶王者","世界","天堂制造","便宜把戏"};
        SetTankName(namesArr[Random.Range(0, namesArr.Length)]);
        //坦克防御进度条初始化//在父类实现无效，不知道为什么。在player是可以的。
        shieldSlider.maxValue = shield;
        shieldSlider.value = shield;
    }

	void Update () {
        MonsterFollowPlayer();
    }
    private void MonsterFollowPlayer()
    {
       switch(state)
        {
            case FSMState.idle:
                Idle();
                break;
            case FSMState.Chasing:
                Chasing();
                break;
            case FSMState.Shooting:
                Shooting();
                break;
        }
    }
    /// <summary>
    /// 追逐
    /// </summary>
    private void Chasing()
    {
        myNavMeshAgent.SetDestination(playerTransform.position);
        if (Vector3.Distance(transform.position,playerTransform.position)<shootingDistance)
        {
            state = FSMState.Shooting;
        }
        if(Vector3.Distance(transform.position, playerTransform.position) > chasingDistance)
        {
            state = FSMState.idle;
        }
    }
    /// <summary>
    /// 射击
    /// </summary>
    private void Shooting()
    {
        myNavMeshAgent.SetDestination(transform.position);
        //炮台看向玩家
        //旋转角度计算
        Quaternion rotate = Quaternion.LookRotation(playerTransform.position - tankTurret.transform.position);
        //平滑过渡
        Quaternion targetRotate = Quaternion.Euler(0, rotate.eulerAngles.y, 0);
        tankTurret.transform.rotation = Quaternion.Slerp(tankTurret.transform.rotation, targetRotate, Time.deltaTime);
        //每两秒攻击一次
        if (Time.time>=currTime)
        {
            Shoot(bulletArr[0],gameObject);
            currTime = shootingTime + Time.time;
        }
        if(Vector3.Distance(transform.position,playerTransform.position)>shootingDistance)
        {
            state = FSMState.Chasing;
        }
    }
    /// <summary>
    /// 待机
    /// </summary>
    private void Idle()
    {
        //每三秒往随机目的地移动
        if (Time.time>=idlecurrTime)
        {
            idlePos = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
            myNavMeshAgent.SetDestination(transform.position + idlePos);
            idlecurrTime = Time.time + idleTime;
        }
        if (Vector3.Distance(transform.position, playerTransform.position) < chasingDistance)
        {
            state = FSMState.Chasing;
        }
    }
    public override void Dead()
    {
        Instantiate(fxPlayerExp, transform.position, Quaternion.identity);
        MonstersManager.instance.monsterList.Remove(gameObject);
        UIManager.Instance.AddScoreNum();
        Destroy(gameObject);
    }

}
