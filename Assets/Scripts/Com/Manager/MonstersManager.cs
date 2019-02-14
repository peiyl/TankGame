using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 生成敌方坦克节点管理类
/// </summary>
public class MonstersManager : MonoBehaviour {

    public static MonstersManager instance;

    /// <summary>
    /// 坦克预制体
    /// </summary>
    public GameObject[] monsterTanks;
    /// <summary>
    /// 刷新地点
    /// </summary>
    public Transform[] monstersBirPoint;
    /// <summary>
    /// 场地中的敌方坦克
    /// </summary>
    //private int monstersNum = 0;
    public List<GameObject> monsterList = new List<GameObject>();
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        if (monsterList.Count <= 0)
            CreateMonterTanks();
    }
    /// <summary>
    /// 创建敌方坦克
    /// </summary>
    private void CreateMonterTanks()
    {
        for (int i = 0; i < monstersBirPoint.Length; i++)
        {
            GameObject tank = Instantiate(monsterTanks[Random.Range(0, monsterTanks.Length)], monstersBirPoint[i].position,monstersBirPoint[i].rotation)as GameObject;
            
        }
    }
    ///// <summary>
    ///// 当敌方坦克死亡，场上计数减一
    ///// </summary>
    //public void WhenMonsterDead()
    //{
    //    monstersNum--;
    //}
}
