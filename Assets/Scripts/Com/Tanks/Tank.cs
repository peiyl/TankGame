using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 坦克类
/// 用于设置坦克共有参数和方法
/// </summary>
public class Tank:MonoBehaviour {
    /// <summary>
    /// 子弹发射特效,不知道为什么改成gameobject会报错
    /// </summary>
    public Transform fxShot;
    /// <summary>
    /// 子弹数组
    /// </summary>
    public GameObject[] bulletArr;
    /// <summary>
    /// 炮口位置
    /// </summary>
    public Transform shotPos;
    /// <summary>
    /// 坦克的名字
    /// </summary>
    public Text nameText;
    /// <summary>
    /// 坦克的血条
    /// </summary>
    public Slider hpSlider;
    /// <summary>
    /// 坦克的防御条
    /// </summary>
    public Slider shieldSlider;
    /// <summary>
    /// 坦克的生命值上限（子类可见）
    /// </summary>
    protected int maxHp;
    /// <summary>
    /// 坦克现有的生命值（子类可见）
    /// </summary>
    protected int hp;
    /// <summary>
    /// 防御值最大值
    /// </summary>
    public int maxShield;
    /// <summary>
    /// 现有防御值
    /// </summary>
    public int shield;
    /// <summary>
    /// 坦克现有的生命值
    /// </summary>
    public int HP
    {
        set { hp = value; }
        get { return hp; }
    }
    /// <summary>
    /// 坦克的生命值上限只读
    /// </summary>
    public int MaxHp
    {
        //set { maxHp = value; }
        get { return maxHp; }
    }

    /// <summary>
    /// 子弹发射
    /// </summary>
    /// <param name="g">发射的子弹预制体</param>
    /// <param name="myCollider">发射方的碰撞体</param>
    protected void Shoot(GameObject g, GameObject myCollider)
    {
        //生成子弹
        GameObject bullet = Instantiate(g, shotPos.position, shotPos.rotation) as GameObject;
        bullet.GetComponent<Bullet>().SetMyCollider(myCollider);
        //生成子弹特效
        Instantiate(fxShot, shotPos.position, Quaternion.identity);
    }
    /// <summary>
    /// 对坦克的伤害
    /// </summary>
    /// <param name="value">伤害的数值</param>
    public void TakeDamage(int value)
    {
        if (shield>=0)
        {
            shield--;
            shieldSlider.value = shield;
        }
        else
        {
            hp -= value;
            if (hp <= 0)
            {
                Dead();
            }
            hpSlider.value = (float)hp / maxHp;
        }
    }
    /// <summary>
    /// 设置坦克的名称显示
    /// </summary>
    /// <param name="name"></param>
    public void SetTankName(string name)
    {
        nameText.text = name;
    }
    /// <summary>
    /// 当生命值为零时坦克死亡
    /// </summary>
    public virtual void Dead()
    {

    }
}
