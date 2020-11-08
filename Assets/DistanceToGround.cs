using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class DistanceToGround : MonoBehaviour
{
    [SerializeField] GameObject LeftController, RightController;
    [SerializeField] TextMeshPro debugText;
    [SerializeField] float triggerPoint = 0.2f;
    [SerializeField] float buildTriggerPoint = 100f;

    [SerializeField] float rayPointOffset = 2f;
    [SerializeField] GameObject smallWall;
    [SerializeField] Camera camera;
    float PrevDistance;

    float shovCount;

    void FixedUpdate()
    {
        if (GetDistance(LeftController) && GetDistance(RightController))
        {
            ShovingHands();
        }
        else
        {
            PrevDistance = 0f;
            shovCount = 0;
        }
        debugText.text = shovCount.ToString();

    }

    bool GetDistance(GameObject controller)
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

    void ShovingHands()
    {
        float distance = Vector3.Distance(LeftController.transform.position, RightController.transform.position);
        if (distance < PrevDistance)
        {
            shovCount += 1 * Time.fixedDeltaTime;

            if (shovCount > buildTriggerPoint)
            {
                //BuildSomething
                Vector3 midPoint = RightController.transform.position + (LeftController.transform.position - RightController.transform.position) / 2;
                Vector3 offset = new Vector3(0, rayPointOffset, 0);
                Vector3 rayPoint = midPoint + offset;
                RaycastHit hit;
                Ray downRay = new Ray(rayPoint, Vector3.down);

                if (Physics.Raycast(downRay, out hit))
                {
                    //debugText.text = hit.collider.gameObject.name;
                    if (hit.collider.gameObject.tag == "ground")
                    {
                        //build
                        Quaternion spawnRotation = Quaternion.Euler(LeftController.transform.rotation.x, 0, LeftController.transform.rotation.z);
                        GameObject SmallWallClone = Instantiate(smallWall, hit.point, spawnRotation);
                        shovCount = 0;
                    }
                    else if (hit.collider.gameObject.tag == "build")
                    {
                        //upgrade
                        shovCount = 0;

                    }
                }
            }
        }
        PrevDistance = distance;

    }
}