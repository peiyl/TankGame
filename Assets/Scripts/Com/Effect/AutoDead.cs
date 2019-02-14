using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 定时自动销毁
/// </summary>
public class AutoDead : MonoBehaviour {
    /// <summary>
    /// 延迟时间
    /// </summary>
    public float delay;
    /// <summary>
    /// 粒子数组
    /// </summary>
    private ParticleSystem[] pSystems;
    private void Awake()
    {
        pSystems = GetComponentsInChildren<ParticleSystem>();
        if (delay > 0)
            return;
        for (int i = 0; i < pSystems.Length; i++)
        {
            if (pSystems[i].duration>delay)
            {
                delay = pSystems[i].duration;
            }
        }
    }
    void Start () {
        for (int i = 0; i < pSystems.Length; i++)
        {
            //Don't set random seed while system is playing!
            //pSystems[i].randomSeed = (uint)Random.Range(0f, uint.MaxValue);
            pSystems[i].Play();
        }
        Destroy(gameObject, delay);
	}
}
