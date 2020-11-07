using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateFunctionLever : MonoBehaviour
{
    [SerializeField] ActivateLever lever;

    public void TurnOn()
    {
        lever.enabled = true;
    }
    public void TurnOff()
    {
        lever.enabled = false;

    }
}
