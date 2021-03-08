using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCMovementInput : MonoBehaviour,IInput
{
    public float Horizontal()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        return Horizontal;
    }

    public float Vertical()
    {
        float Vertical = Input.GetAxis("Vertical");
        return Vertical;
    }
}
