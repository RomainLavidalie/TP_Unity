using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform CameraTransform;
    private Quaternion CameraReference;
    // Start is called before the first frame update
    void Start()
    {
        CameraTransform = GetComponent<Transform>();
        CameraReference = CameraTransform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(CameraTransform.rotation);
        CameraTransform.rotation = CameraReference;
    }
}
