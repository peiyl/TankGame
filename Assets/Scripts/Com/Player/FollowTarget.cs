using UnityEngine;
using System.Collections;

/// <summary>
/// 摄像机跟随类
/// describe: 摄像机跟随目标管理
/// 
/// company:广州粤嵌通信科技股份有限公司
/// author:Jatn
/// e-mail:jatn@163.com
/// createdDate:2017-10-27
/// modifiedDate:2017-10-27
/// </summary>
public class FollowTarget : MonoBehaviour
{
    /// <summary>
    /// 跟随目标对象
    /// </summary>
    [HideInInspector]
    public Transform target;

    public LayerMask respawnMask;

    public float distance = 10.0f;

    public float height = 5.0f;

    [HideInInspector]
    public Camera cam;

    [HideInInspector]
    public Transform camTransform;

    void Start()
    {
        cam = GetComponent<Camera>();
        camTransform = transform;
       // Transform listener = GetComponentInChildren<AudioListener>().transform;
       // listener.position = transform.position + transform.forward * distance;
    }

    void LateUpdate()
    {
        if (!target)
            return;

        Quaternion currentRotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);

        Vector3 pos = target.position;
        pos -= currentRotation * Vector3.forward * Mathf.Abs(distance);
        //pos.y = target.position.y + Mathf.Abs(height);
        //transform.position = pos;
        transform.position = new Vector3(pos.x, target.position.y + Mathf.Abs(height), pos.z);
        transform.LookAt(target);

        transform.position = target.position - (transform.forward * Mathf.Abs(distance));
    }

    public void HideMask(bool shouldHide)
    {
        if (shouldHide) cam.cullingMask &= ~respawnMask;
        else cam.cullingMask |= respawnMask;
    }
}