using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSelection : MonoBehaviour,ILaser
{
    ObjectPooler objectPooler;
    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    [SerializeField]
    private Transform _transform;
    public void Default()
    {
        objectPooler.SpawnFromPool("Laser", _transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
    }

    public void Boosted()
    {
        objectPooler.SpawnFromPool("TripleLaser", _transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
    }
}
