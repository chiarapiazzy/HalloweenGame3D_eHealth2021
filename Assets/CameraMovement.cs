using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    
    private Vector3 offset = new Vector3(0, 1, -7);
    
    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
