using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class GrabSnowBall : MonoBehaviour
{
    [SerializeField] XRNode inputSource;
    [SerializeField] DistanceToGround distanceToGround;
    [SerializeField] GameObject snowball;
    [SerializeField] TextMeshPro debugText;
    bool prevState = false;

    // Update is called once per frame
    void Start(){
        Debug.Log("I AM ALIVE FOOL!!!");
    }
    
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.gripButton, out bool grip);

        if (grip && distanceToGround.GetDistance(gameObject) && !prevState)
        {
            prevState = true;
            GameObject snowballClone = Instantiate(snowball, transform.position, transform.rotation);
        }
        else if (!grip)
        {
            prevState = false;
        }

        debugText.text = grip.ToString();
    }
}
