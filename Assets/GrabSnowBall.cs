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
    bool prevState = false;
    
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
    }
}
