using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
/// <summary>
/// 主角坦克类
/// 主角坦克管理
/// 坦克移动、旋转、子弹发射
/// </summary>
public class Player : Tank {
    //强迫症格式注释（以下为必要组件）
    private Rigidbody mRigidbody;
    private AudioSource playershot;
    /// <summary>
    /// 剩余红色子弹次数
    /// </summary>
    public int bulletPowerNum;
    /// <summary>
    /// 坦克死亡效果
    /// </summary>
    public GameObject fxPlayerExp;
    /// <summary>
    /// 炮台
    /// </summary>
    public GameObject tankTurret;
    //移动速度
    public float moveSpeed = 5f;
    //子弹发射时间
    public float shootTime = 0.5f;
    private float shootCurrTime;
    /// <summary>
    /// 炮台偏移欧拉角
    /// </summary>
    Vector3 angle;
    private bool isUIShoot = false;
    private bool isUIMove = false;

    void Awake () {
        playershot = GetComponent<AudioSource>();
        mRigidbody = GetComponent<Rigidbody>();
        FollowTarget ft = Camera.main.GetComponent<FollowTarget>();
        ft.target = this.transform;
        SetTankName("石之自由");
        //设置初始值
        maxHp = 100;
        hp = maxHp;
        maxShield = 3;
        shield = maxShield;
        bulletPowerNum = 0;
        //坦克防御进度条初始化
        shieldSlider.maxValue = maxShield;
        shieldSlider.value = maxShield;
    }
    private void Start()
    {
        //注册摇杆委托
        UIGame.Instance.jtRight.onDrag += (Vector2 dir)=> 
        {
            Shooting();
            //计算偏移欧拉角
            angle = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.y)).eulerAngles;
            //y轴进行xz方向旋转
            tankTurret.transform.rotation = Quaternion.Euler(0, angle.y, 0);
        };
        UIGame.Instance.jtRight.onDragBegin += () => { isUIShoot = true; };
        UIGame.Instance.jtRight.onDragEnd += () => { isUIShoot = false; };
        UIGame.Instance.jtLeft.onDrag += Move;
        UIGame.Instance.jtLeft.onDragBegin += () => { isUIMove = true; };
        UIGame.Instance.jtLeft.onDragEnd += () => { isUIMove = false; };
    }
    void Update () {
        if(!isUIMove)
            TankMove();
        if (!isUIShoot&&!EventSystem.current.IsPointerOverGameObject())
        {
            TurretRotate();
            if (Input.GetButton("Fire1"))
            {
                Shooting();
                Debug.Log("feiUI");
            }
        }
        //if(!EventSystem.current.IsPointerOverGameObject())
        //{
        //    TurretRotate();
        //    if (Input.GetButton("Fire1"))
        //    {
        //        Shooting();
        //        Debug.Log("feiUI");
        //    }
        //}

    }
    /// <summary>
    /// 玩家血量增加
    /// </summary>
    public void AddHP(int hp)
    {
        this.hp += hp;
        if (this.hp > maxHp)
        {
            this.hp = maxHp;
        }
        hpSlider.value = (float)this.hp / maxHp;
        Debug.Log("增加了" + hp + "点HP");
    }
    /// <summary>
    /// 玩家防御值补满
    /// </summary>
    public bool AddShield()
    {
        //如果玩家本来就是满的
        if (shield == maxShield)
        {
            return false;
        }
        else//不是满的说明使用成功
        {
            shield = maxShield;
            shieldSlider.value = maxShield;
            Debug.Log("补充了防御");
            return true;
        }
    }
    /// <summary>
    /// 玩家增加红色子弹
    /// </summary>
    /// <param name="num">增加的子弹数量</param>
    public void AddBulletPower(int num)
    {
        bulletPowerNum += num;
    }
    /// <summary>
    /// 玩家射击
    /// </summary>
    void Shooting()
    {
        if (Time.time >= shootCurrTime)
        {
            shootCurrTime = Time.time + shootTime;
            //判断是否剩余红色子弹道具
            if (bulletPowerNum <= 0)
            {
                Shoot(bulletArr[0], gameObject);
            }
            else//不为0则发射红色子弹，调用父类的方法和参数
            {
                bulletPowerNum--;
                Shoot(bulletArr[2], gameObject);
            }
            //播放射击音效
            playershot.Play();
        }
    }
    
    /// <summary>
    /// 键盘控制坦克移动
    /// </summary>
    void TankMove()
    {
        Vector2 moveDir;
        if (Input.GetAxisRaw("Horizontal")!=0||Input.GetAxisRaw("Vertical")!=0)
        {
            moveDir.x = Input.GetAxisRaw("Horizontal");
            moveDir.y = Input.GetAxisRaw("Vertical");
            Move(moveDir);
            ////坦克旋转。//目标角度
            //transform.rotation = Quaternion.LookRotation(new Vector3(moveDir.x, 0, moveDir.y));
            ////坦克移动
            //Vector3 newDis = transform.forward * moveSpeed * Time.deltaTime;
            //mRigidbody.MovePosition(transform.position + newDis);
        }
    }
    /// <summary>
    /// 坦克移动
    /// </summary>
    void Move(Vector2 dir)
    {
        //坦克旋转。//目标角度
        transform.rotation = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.y));
        //坦克移动
        Vector3 newDis = transform.forward * moveSpeed * Time.deltaTime;
        mRigidbody.MovePosition(transform.position + newDis);
    }
    /// <summary>
    /// 控制炮台旋转
    /// </summary>
    void TurretRotate()
    {
        //if (!EventSystem.current.IsPointerOverGameObject())
        //    return;
        //x方向比值
        float dirX = (Input.mousePosition.x - Screen.width / 2) / Screen.width / 2;
        //y方向比值
        float dirZ = (Input.mousePosition.y - Screen.height / 2) / Screen.height / 2;
        //计算偏移欧拉角
        angle = Quaternion.LookRotation(new Vector3(dirX, 0, dirZ)).eulerAngles;
        //y轴进行xz方向旋转
        tankTurret.transform.rotation = Quaternion.Euler(0, angle.y, 0);
    }
    public override void Dead()
    {
        Instantiate(fxPlayerExp, transform.position, Quaternion.identity);
        UIManager.Instance.ShowGOPanel();
        Destroy(gameObject);
    }
   
}
