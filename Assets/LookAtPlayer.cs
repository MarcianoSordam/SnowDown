using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    // Start is called before the first frame update

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt( new Vector3(player.transform.position.x,transform.position.y,player.transform.position.z));
    }
}
