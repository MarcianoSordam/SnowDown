using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class DistanceToGround : MonoBehaviour
{
    [SerializeField] float triggerPoint;
    public bool GetDistance(GameObject controller)
    {
        RaycastHit hit;
        Ray downRay = new Ray(controller.transform.position, Vector3.down);

        if (Physics.Raycast(downRay, out hit))
        {
            if (hit.distance < triggerPoint)
            {
                return true;
            }
            return false;
        }
        return false;
    }

}