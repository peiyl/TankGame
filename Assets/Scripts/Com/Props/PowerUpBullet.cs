using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 道具碰撞器：子弹升级
/// 功能：更换子弹
/// </summary>
public class PowerUpBullet : Props
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
    //        other.GetComponent<Player>().bulletPowerNum = 8;
    //            updateTime = Time.time + updateBetweenTime;
    //    }
    //}
    private int addBulletNum = 8;
    //我想要子弹可以积累，所以没有写限制。
    public override bool UpdateInfo(Player player)
    {
        player.AddBulletPower(addBulletNum);
        return true;
    }
}
