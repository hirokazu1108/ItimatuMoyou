using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZukanViewController : MonoBehaviour
{ 
    public static float baseRotateY = 200.0f;
    public static float rotateY = 200.0f;

    [SerializeField] private GameObject model;

    void Update()
    {
        // ���N���b�N���Ă���Ȃ�(Y�����S��])
        if (Input.GetMouseButton(0))
        {
            float moveLen = Input.GetAxis("Mouse X") * Time.deltaTime * 6000;
            rotateY -= moveLen;
            model.transform.rotation = Quaternion.Euler(0, rotateY, 0);
        }
    }
}

