using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MobileMovementInput : MonoBehaviour,IInput
{
    public float Horizontal()
    {
        float Horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        return Horizontal;
    }

    public float Vertical()
    {
        float Vertical = CrossPlatformInputManager.GetAxis("Vertical");
        return Vertical;
    }
}
