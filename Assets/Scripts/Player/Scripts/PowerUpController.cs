using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour, IPowerUp
{
    private float _speedBoostTime = 5f;
    private float _tripleShotBoostTime = 5f;
    FireLaser _fireLaser;
    Movement _movement;
    PlayerLiveSystem _playerLiveSystem;

    private void Start()
    {
        _fireLaser = GetComponent<FireLaser>();
        if (_fireLaser == null)
        {
            Debug.LogError("Laser is null");
        }

        _movement = GetComponent<Movement>();
        if (_movement == null)
        {
            Debug.LogError("Movement is null");
        }

        _playerLiveSystem = GetComponent<PlayerLiveSystem>();
        if (_playerLiveSystem == null)
        {
            Debug.LogError("Lives System is null");
        }
    }
    public void ShieldBoost()
    {
        _playerLiveSystem._isShieldActive = true;
        _playerLiveSystem._shieldVisualizer.SetActive(true);
    }

    public void SpeedBoost()
    {
        _movement._speed *= 2f;
        StartCoroutine(SpeedPowerDownRoutine(_speedBoostTime));
    }

    IEnumerator SpeedPowerDownRoutine(float _timeToDown)
    {
        yield return new WaitForSeconds(_timeToDown);
        _movement._speed /= 2f;
    }

    public void TripleLaserBoost()
    {
        _fireLaser.LaserBoost = true;
        StartCoroutine(LaserPowerDownRoutine(_tripleShotBoostTime));
    }

    IEnumerator LaserPowerDownRoutine(float _timeToDown)
    {
        yield return new WaitForSeconds(_timeToDown);
        _fireLaser.LaserBoost = false;
    }
}
