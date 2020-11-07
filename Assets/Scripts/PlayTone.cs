using System.Collections;
using UnityEngine;

public class PlayTone : MonoBehaviour
{
    [SerializeField] AudioSource tone;

    [SerializeField] float distanceTrigger;

    void Start()
    {      
        tone = GetComponent<AudioSource>();
    }

    public void SoundActivation(float delay)
    {
       StartCoroutine(PlaySound(delay));
    }

    IEnumerator PlaySound(float delay)
    {
        tone.Play();
        yield return new WaitForSeconds(delay);
        RaycastHit hit;
        Ray downRay = new Ray(transform.position, Vector3.up);

        // Cast a ray straight downwards.
        if (Physics.Raycast(downRay, out hit))
        {
            if (hit.distance<distanceTrigger)
            {
                //send message to block above with delay
                Debug.Log("sending next tone with delay = " + delay);
                
                hit.collider.gameObject.SendMessage("SoundActivation",delay);
            }
        }

        
    }
}
