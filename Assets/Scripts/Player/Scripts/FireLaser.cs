using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLaser : MonoBehaviour
{
    public bool LaserBoost = false;
    private float _fireRate = 0.2f;
    private float _canFire = -1f;
    IFireInput IFireInput;
    ILaser ILaser;

    private void Start()
    {
        IFireInput = GetComponent<IFireInput>();
        if (IFireInput == null)
        {
            Debug.LogError("Fire is null");
        }

        ILaser = GetComponent<ILaser>();
        if (ILaser == null)
        {
            Debug.Log("Laser Instantiation is null");
        }
    }

    void Update()
    {
        if (IFireInput.FireInput() && Time.time > _canFire)
        {
            _canFire = Time.time + _fireRate;
            if (LaserBoost)
            {
                ILaser.Boosted();
            }
            else
            {
                ILaser.Default();
            }
        }
    }
}
