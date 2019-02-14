using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 道具节点管理类
/// 道具的创建更新
/// </summary>
public class ObjectSpawner : MonoBehaviour {
    /// <summary>
    /// 道具预制体
    /// </summary>
    public GameObject propsPrefabs;
    private void Start()
    {
        CreateProps();
    }
    /// <summary>
    /// 生成道具
    /// </summary>
    public void CreateProps()
    {
        GameObject go = Instantiate(propsPrefabs, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
        go.GetComponent<Props>().os = this;
    }
    /// <summary>
    /// 清理道具时调用计时协程
    /// </summary>
    public void DestoryPowerup(GameObject go)
    {
        Destroy(go);
        StartCoroutine(WaitTime());
    }
    //计时协程
    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(30);
        CreateProps();
        StopCoroutine(WaitTime());
    }
}
