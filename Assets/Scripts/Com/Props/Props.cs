using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 道具基类
/// </summary>
public class Props : MonoBehaviour {
    /// <summary>
    /// 节点对象
    /// </summary>
    [HideInInspector]//隐藏面板显示
    public ObjectSpawner os;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (UpdateInfo(other.gameObject.GetComponent<Player>()))
                os.DestoryPowerup(gameObject);
        }
    }
    public virtual bool UpdateInfo(Player player)
    {
        return false;
    }
}
