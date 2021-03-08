using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSelection : MonoBehaviour,ILaser
{
    [SerializeField]
    private GameObject _laserPrefab, _tripleShotPrefab;
    [SerializeField]
    private Transform _transform;
    public void Default()
    {  
        Instantiate(_laserPrefab, _transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity); 
    }

    public void Boosted()
    {
        Instantiate(_tripleShotPrefab, _transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
    }
}
