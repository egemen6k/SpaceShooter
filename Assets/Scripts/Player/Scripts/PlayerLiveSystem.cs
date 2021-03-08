using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerLiveSystem : MonoBehaviour,IDamage,ILivesUpdate
{
    [SerializeField]
    private GameObject _rightEngine, _leftEngine;
    [Range(0,3)]
    private int _lives;
    public GameObject _shieldVisualizer;
    public bool _isShieldActive = false;
    private ILivesUpdate[] IlivesUpdateArray;

    private void Start()
    {
        int _maxLives = 3;
        _lives = _maxLives;

        IlivesUpdateArray = FindObjectsOfType<MonoBehaviour>().OfType<ILivesUpdate>().ToArray();
        if (IlivesUpdateArray == null)
        {
            Debug.Log("Lives Update Interface implementation had problem");
        }

    }
    public void Damage()
    {
        if (_isShieldActive)
        {
            _isShieldActive = false;
            _shieldVisualizer.SetActive(false);
            return;
        }

        _lives--;

        if (_lives == 2)
        {
            _rightEngine.SetActive(true);
        }
        else if (_lives == 1)
        {
            _leftEngine.SetActive(true);
        }

        foreach (ILivesUpdate item in IlivesUpdateArray)
        {
            item.OnLivesChange(_lives);
        }
    }

    public void OnLivesChange(int _lives)
    {
        if (_lives < 1)
        {
            Destroy(this.gameObject);
        }
    }
}
