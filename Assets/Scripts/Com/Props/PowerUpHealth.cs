using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 道具：医疗
/// 功能：随机增加主角生命+（10-20）
/// </summary>
public class PowerUpHealth : Props
{
    ///// <summary>
    ///// 道具更新间隔
    ///// </summary>
    //private float updateBetweenTime = 30f;
    ///// <summary>
    ///// 道具下一次更新的时间
    ///// </summary>
    //private float updateTime;
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        UpdateInfo(other.gameObject);
    //    }
    //}
   
    public override bool UpdateInfo(Player player)
    {
        //改进：减少随机数计算次数，因为只用一次，所以创建变量反而增加内存
        if (player.HP == player.MaxHp)
            return false;
        player.AddHP(Random.Range(10, 21));
        return true;
    }
}
