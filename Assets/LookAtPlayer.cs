using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    GameObject player;

    void Start()
    {
        player = GameObject.Find("Main Camera");
    }

    void FixedUpdate()
    {
        transform.LookAt( new Vector3(player.transform.position.x,transform.position.y,player.transform.position.z));
    }
}