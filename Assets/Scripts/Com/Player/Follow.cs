//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Follow : MonoBehaviour {
//    private Vector3 offset = new Vector3(0, 14, -6);//相机相对于玩家的位置
//    private Transform target;
//    private Vector3 pos;
//    public float speed = 5;
//    Quaternion angel;
//    // Use this for initialization
//    void Start()
//    {
//        target = GameObject.FindGameObjectWithTag("Player").transform;

//    }

//    // Update is called once per frame
//    void Update()
//    {
//        pos = target.position + offset;
//        //调整相机与玩家之间的距离
//        transform.position = Vector3.Lerp(transform.position, pos, speed * Time.deltaTime);
//        //获取旋转角度
//        angel = Quaternion.LookRotation(target.position - this.transform.position);
//        transform.rotation = Quaternion.Slerp(this.transform.rotation, angel, speed * Time.deltaTime);
//    }

//}
