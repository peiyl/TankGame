using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 坦克名称血条的UI朝向
/// </summary>
public class HUD : MonoBehaviour {
    private void Update()
    {
        transform.rotation = Camera.main.transform.rotation;
    }
}
