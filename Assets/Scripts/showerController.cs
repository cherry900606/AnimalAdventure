using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showerController : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 計算目標位置，保持 y 軸不變
        Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, target.position.z);

        // 移動 prefab 到目標位置
        transform.position = targetPosition;
    }
}
