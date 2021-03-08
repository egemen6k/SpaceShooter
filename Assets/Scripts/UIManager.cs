using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour,ILivesUpdate
{
    [SerializeField]
    private Text _scoreStaticText, _scoreDynamicText,_gameOverText, _restartText;
    [SerializeField]
    private Sprite[] _livesSprites;
    [SerializeField]
    private Image _LivesImg;
    private GameManager _gameManager;

    void Start()
    {
        _scoreStaticText.text = "Score: ";

        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        if (_gameManager == null)
        {
            Debug.LogError("_gameManager is null");
        }
    }

    public void UpdateScore(int playerScore)
    {
        _scoreDynamicText.text = playerScore.ToString();

    }

    public void OnLivesChange(int _lives)
    {
        _LivesImg.sprite = _livesSprites[_lives];

        if (_lives == 0)
        {
            GameOverSequence();
        }
    }
    void GameOverSequence()
    {
        _gameManager.GameOver();
        _gameOverText.gameObject.SetActive(true);
        _restartText.gameObject.SetActive(true);
        StartCoroutine(FlickerGameOver());
    }

    IEnumerator FlickerGameOver()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            _gameOverText.text = "";
            yield return new WaitForSeconds(0.5f);
            _gameOverText.text = "GAME OVER";
        }
    }

    public void ResumeGame()
    {
        _gameManager.ResumeGame();
    }

    public void MainMenu()
    {
        _gameManager.MainMenu();
    }

}
