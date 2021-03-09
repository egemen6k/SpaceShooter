using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int _score;

    private UIManager _uiManager;


    void Start()
    {


        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

public void AddScore(int points)
    {
        _score += points;
        _uiManager.UpdateScore(_score);
    }
}
