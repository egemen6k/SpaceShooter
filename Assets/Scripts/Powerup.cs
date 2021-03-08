using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;
    [SerializeField] // 0 = Triple Shot 1 = Speed 2 = Shield
    private int powerupID;

    [SerializeField]
    private AudioClip _clip;

    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -4.5f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            IPowerUp IPowerUp = other.GetComponent<IPowerUp>();
            if (IPowerUp != null)
            {
                AudioSource.PlayClipAtPoint(_clip, transform.position);
                switch (powerupID)
                {
                    case 0:
                        IPowerUp.TripleLaserBoost();
                        break;
                    case 1:
                        IPowerUp.SpeedBoost();
                        break;
                    case 2:
                        IPowerUp.ShieldBoost();
                        break;
                    default:
                        break;
                }
            }
            Destroy(this.gameObject);
        }
    }
}
