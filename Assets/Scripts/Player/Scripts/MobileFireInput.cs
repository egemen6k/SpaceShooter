using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MobileFireInput : MonoBehaviour,IFireInput
{
    public bool FireInput()
    {
        if ( CrossPlatformInputManager.GetButtonDown("Fire"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
