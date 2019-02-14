using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 道具：护盾
/// 功能：将角色的防御值加满
/// </summary>
public class PowerUpShield : Props
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
    //        if (other.GetComponent<Player>().AddShield())
    //            os.DestoryPowerup(gameObject);
    //    }
    //}
    private int shield;
    public override bool UpdateInfo(Player player)
    {
        return player.AddShield();
    }
}
