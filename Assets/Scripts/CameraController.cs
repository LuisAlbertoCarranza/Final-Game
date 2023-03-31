using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Transform farBackground;
    private float lastXPos;
    public float minHeight, maxHeight;
    // Start is called before the first frame update
    void Start()
    {
       lastXPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeight, maxHeight),transform.position.z);
       float amoutnToMoveX = transform.position.x - lastXPos;
       farBackground.position = farBackground.position + new Vector3(amoutnToMoveX, 0f, 0f);
       lastXPos = transform.position.x;
    }
}
