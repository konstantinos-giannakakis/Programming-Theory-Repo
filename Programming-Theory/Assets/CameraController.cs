using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y+0.2f, player.transform.position.z - 10);
    }
}
