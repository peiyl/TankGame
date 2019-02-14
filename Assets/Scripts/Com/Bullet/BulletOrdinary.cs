using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 普通子弹类
/// </summary>
public class BulletOrdinary : Bullet {
    /// <summary>
    /// 坦克的攻击力
    /// </summary>
    private int attack = 10;
    /// <summary>
    /// 子弹移动速度
    /// </summary>
    private float speed = 10f;
    public override void Start()
    {
        base.Start();
        mRigidbody.velocity = transform.forward * speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == myCollider || other.tag == "Prop")
            return;
        if (other.tag == "Player")
        {
            other.GetComponent<Player>().TakeDamage(attack);
        }
        if (other.tag == "Monster")
        {
            other.GetComponent<Monster>().TakeDamage(attack);
        }
        CreateFX();
    }
}
