using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int _score;

    private UIManager _uiManager;

    [SerializeField]
    private AudioClip _laserSoundClip;

    private AudioSource _laserSound;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _laserSound = GetComponent<AudioSource>();

        if (_laserSound == null)
        {
            Debug.LogError("Audio source is null");
        }
        else
        {
            _laserSound.clip = _laserSoundClip;
        }
    }

public void AddScore(int points)
    {
        _score += points;
        _uiManager.UpdateScore(_score);
    }
}
