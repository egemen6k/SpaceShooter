using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    IDamage IDamage;

    private void Start()
    {
        IDamage = GetComponent<IDamage>();
        if (IDamage == null)
        {
            Debug.LogError("Enemy Damage implementation is null");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<IDamage>().Damage();
            IDamage.Damage();
        }
        else if (other.tag == "Laser")
        {
            Player _player = GameObject.Find("Player").GetComponent<Player>();
            if (_player != null)
            {
                _player.AddScore(10);
            }

            IDamage.Damage();
            Destroy(other.gameObject);
        }
    }
}
