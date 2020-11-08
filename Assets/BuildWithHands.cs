using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

[RequireComponent(typeof(DistanceToGround))]
public class BuildWithHands : MonoBehaviour
{
    DistanceToGround distanceToGround;
    [SerializeField] GameObject LeftController, RightController;
    //[SerializeField] TextMeshPro debugText;

    [SerializeField] GameObject PlayerCam;
    [SerializeField] float buildTriggerPoint = 100f;

    [SerializeField] float rayPointOffset = 2f;
    [SerializeField] GameObject smallWall;

    [SerializeField] GameObject particleObject;
    ParticleSystem ptSystem;
    float PrevDistance;

    float shovCount;

    void Start()
    {
        distanceToGround = GetComponent<DistanceToGround>();
        ptSystem = particleObject.GetComponent<ParticleSystem>();
    }
    void FixedUpdate()
    {
        if (distanceToGround.GetDistance(LeftController) && distanceToGround.GetDistance(RightController))
        {
            ShovingHands();
        }
        else
        {
            PrevDistance = 0f;
            shovCount = 0;
        }
        //debugText.text = shovCount.ToString();
    }

    void ShovingHands()
    {
        float distance = Vector3.Distance(LeftController.transform.position, RightController.transform.position);
        if (distance < PrevDistance)
        {
            Vector3 midPoint = RightController.transform.position + (LeftController.transform.position - RightController.transform.position) / 2;
            particleObject.transform.position = midPoint;
            float delteDistance = PrevDistance - distance;
            shovCount += 10 * delteDistance * Time.fixedDeltaTime;
            ptSystem.Play();

            //Debug.DrawLine(PlayerCam.transform.position, midPoint);

            if (shovCount > buildTriggerPoint)
            {
                //BuildSomething
                Vector3 SpawnForward = FlattenVecotr3(midPoint - PlayerCam.transform.position);
                
                Vector3 offset = new Vector3(0, rayPointOffset, 0);
                Vector3 rayPoint = midPoint + offset;
                RaycastHit hit;
                Ray downRay = new Ray(rayPoint, Vector3.down);

                if (Physics.Raycast(downRay, out hit))
                {
                    Debug.Log(hit.collider.gameObject.name);
                    if (hit.collider.gameObject.tag == "ground")
                    {
                        //build
                        Quaternion spawnRotation = Quaternion.LookRotation(SpawnForward);
                        GameObject SmallWallClone = Instantiate(smallWall, hit.point, spawnRotation);
                        shovCount = 0;
                    }
                    else if (hit.collider.gameObject.tag == "build")
                    {
                        //upgrade
                        hit.collider.gameObject.SendMessage("BuildLayer");
                        shovCount = 0;

                    }
                }
            }
        }
        else
        {
            ptSystem.Stop();
        }
        PrevDistance = distance;
    }

    //flattens vector3 on Y axis
    Vector3 FlattenVecotr3(Vector3 inputVector)
    {
        return new Vector3(inputVector.x,0,inputVector.z);
    }

}