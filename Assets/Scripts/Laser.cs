using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour,IPooledObject
{
    [SerializeField]
    private float _speed = 8f;
    [SerializeField]
    private AudioSource _laserSound;
    public bool _isEnemyLaser = false;

    public void OnObjectSpawn()
    {
        _laserSound = GetComponent<AudioSource>();
        if (_laserSound != null)
        {
            _laserSound.Play();
        }
    }

    void Update()
    {
        if (_isEnemyLaser == false)
        {
            MoveUp();
        }
        else
        {
            MoveDown();
        }
    }

    void MoveUp()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);

        if (transform.position.y > 8f)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            gameObject.SetActive(false);
        }
    }

    void MoveDown()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -8f)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            gameObject.SetActive(false);
        }
    }

    public void AssignEnemyLaser()
    {
        _isEnemyLaser = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && _isEnemyLaser == true)
        {
            IDamage IDamage = other.GetComponent<IDamage>();

            if (IDamage != null)
            {
                IDamage.Damage();
                gameObject.SetActive(false);
            }
        }
    }


}
