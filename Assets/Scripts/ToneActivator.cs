using System.Collections;
using UnityEngine;

public class ToneActivator : MonoBehaviour
{
    [SerializeField] float period;
    [SerializeField] float delay;
    [SerializeField] float distanceTrigger;

    void Start()
    {      
        StartCoroutine(PlaySound());
    }

    IEnumerator PlaySound()
    {
        RaycastHit hit;
        Ray upRay = new Ray(transform.position, Vector3.up);

        // Cast a ray straight upwards.
        if (Physics.Raycast(upRay, out hit))
        {
            if (hit.distance<distanceTrigger)
            {
                //send message to block above
                
                //Debug.Log("sending activtor with delay = " + delay);

                hit.collider.gameObject.SendMessage("SoundActivation",delay);
            }
        }

        yield return new WaitForSeconds(period);
        StartCoroutine(PlaySound());

    }
}
