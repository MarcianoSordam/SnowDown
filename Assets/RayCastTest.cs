using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastTest : MonoBehaviour
{
    [SerializeField] float rayPointOffset = 2f;
    [SerializeField] GameObject cursor;

    Vector3 offset;
    void Update()
    {
        offset = new Vector3(0, rayPointOffset, 0);
        Vector3 rayPoint = transform.position + offset;
        RaycastHit hit;
        Ray downRay = new Ray(rayPoint, Vector3.down);

        if (Physics.Raycast(downRay, out hit))
        {
            Debug.Log(hit.collider.gameObject.name);
        }
        cursor.transform.position = rayPoint;
    }
}
