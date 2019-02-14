using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 用于管理场景中的object
/// 感觉没必要，先不写了
/// </summary>
public class ObjectManager : MonoBehaviour {
    public static ObjectManager Instance;
    //private GameObject Player;

    private void Awake()
    {
        Instance = this;
    }
}
