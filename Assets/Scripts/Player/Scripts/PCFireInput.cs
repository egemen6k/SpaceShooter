using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCFireInput : MonoBehaviour,IFireInput
{
    public bool FireInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
