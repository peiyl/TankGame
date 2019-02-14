using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// 虚拟摇杆UI类
/// </summary>
public class UIJoystick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    /// <summary>
    /// 开始拖拽事件委托
    /// </summary>
    public event Action onDragBegin;

    /// <summary>
    /// 拖拽中事件委托
    /// </summary>
    public event Action<Vector2> onDrag;

    /// <summary>
    /// 结束拖拽事件委托
    /// </summary>
    public event Action onDragEnd;

    /// <summary>
    /// 拖拽目标
    /// </summary>
    public Transform target;

    /// <summary>
    /// 半径
    /// </summary>
    public float radius = 50f;

    /// <summary>
    /// 位置
    /// </summary>
    public Vector2 position;

    /// <summary>
    /// 是否拖拽中
    /// </summary>
    private bool isDragging = false;

    /// <summary>
    /// 矩形变换对象
    /// </summary>
    private RectTransform thumb;

    void Start()
    {
        thumb = target.GetComponent<RectTransform>();

#if UNITY_EDITOR
       // Graphic[] graphics = GetComponentsInChildren<Graphic>();
        //for (int i = 0; i < graphics.Length; i++)
            //graphics[i].raycastTarget = false;
#endif
    }

    /// <summary>
    /// 开始拖拽函数
    /// </summary>
    /// <param name="data"></param>
    public void OnBeginDrag(PointerEventData data)
    {
        isDragging = true;
        if (onDragBegin != null)
            onDragBegin();
    }

    /// <summary>
    /// 拖拽进行中函数
    /// </summary>
    /// <param name="data"></param>
    public void OnDrag(PointerEventData data)
    {
        RectTransform draggingPlane = transform as RectTransform;
        Vector3 mousePos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(draggingPlane, data.position, data.pressEventCamera, out mousePos))
        {
            thumb.position = mousePos;
        }
        float length = target.localPosition.magnitude;

        if (length > radius)
        {
            target.localPosition = Vector3.ClampMagnitude(target.localPosition, radius);
        }

        position = target.localPosition;
        position = position / radius * Mathf.InverseLerp(radius, 2, 1);
    }


    void Update()
    {
#if UNITY_EDITOR
        target.localPosition = position * radius;
        target.localPosition = Vector3.ClampMagnitude(target.localPosition, radius);
#endif
        if (isDragging && onDrag != null)
            onDrag(position);
    }

    /// <summary>
    /// 拖拽结束函数
    /// </summary>
    /// <param name="data"></param>
    public void OnEndDrag(PointerEventData data)
    {
        position = Vector2.zero;
        target.position = transform.position;
        isDragging = false;
        if (onDragEnd != null)
            onDragEnd();
    }
}
