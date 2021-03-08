using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour,IDamage
{
    private Player _player;
    private Animator _enemyAnimator;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            Debug.LogError("Audio Source is null");
        }

        _player = GameObject.Find("Player").GetComponent<Player>();
        if (_player == null)
        {
            Debug.LogError("_player is null");
        }

        _enemyAnimator = GetComponent<Animator>();
        if (_enemyAnimator == null)
        {
            Debug.LogError("Animator is null");
        }
    }

    void IDamage.Damage()
    {
        _enemyAnimator.SetTrigger("OnEnemyDeath");
        _audioSource.Play();
        Destroy(GetComponent<Collider2D>());
        Destroy(this.gameObject, 2.8f);
    } 
}
