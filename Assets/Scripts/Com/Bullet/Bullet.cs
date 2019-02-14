using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 子弹父类
/// </summary>
public class Bullet : MonoBehaviour {
    /// <summary>
    /// 用于初始加速度的刚体
    /// </summary>
    protected Rigidbody mRigidbody;
    
    /// <summary>
    /// 发射子弹的坦克
    /// </summary>
    protected GameObject myCollider;
    
    /// <summary>
    /// 爆炸特效
    /// </summary>
    public GameObject fxBulletExp;
    public GameObject fxBulletHit;
    public virtual void Start()
    {
        mRigidbody = GetComponent<Rigidbody>();
    }
    
    /// <summary>
    /// 设置生成子弹的对象的碰撞器
    /// </summary>
    /// <param name="collider"></param>
    public void SetMyCollider(GameObject collider)
    {
        myCollider = collider;
    }
    /// <summary>
    /// 生成特效并删除自身
    /// </summary>
    public void CreateFX()
    {
        Instantiate(fxBulletExp, transform.position, Quaternion.identity);
        Instantiate(fxBulletHit, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
