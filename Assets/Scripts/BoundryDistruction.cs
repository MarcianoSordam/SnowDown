using System.Collections;
using UnityEngine;

public class BoundryDistruction : MonoBehaviour
{
    void OnCollisionEnter(Collision collider)
    {
        Debug.Log(collider.gameObject.name);
        collider.gameObject.SendMessage("SelfDestruct");
    }

}