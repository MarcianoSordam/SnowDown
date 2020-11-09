using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSegments : MonoBehaviour
{
    [SerializeField] WallManager wallManager;
    public void TakeDamage(double Damage)
    {
        wallManager.DmgWall(Damage);
    } 
}
