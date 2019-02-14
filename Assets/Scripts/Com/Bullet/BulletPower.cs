using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 特殊红色子弹
/// 速度+2
/// 攻击力+4
/// 子弹数量+8（在Player脚本控制）
/// </summary>
public class BulletPower : Bullet {
    /// <summary>
    /// 坦克的攻击力
    /// </summary>
    private int attack = 14;
    /// <summary>
    /// 子弹移动速度
    /// </summary>
    private float speed = 12f;
    public override void Start()
    {
        base.Start();
        mRigidbody.velocity = transform.forward * speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == myCollider || other.tag == "Prop")
            return;
        
        if (other.tag == "Monster")
        {
            other.GetComponent<Monster>().TakeDamage(attack);
        }
        CreateFX();
    }
}
