using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public GameObject panel;
    public GameObject winLabel;
    public GameObject loseLabel;
    public GameObject buttonRestart;

    private BoardController boardController;

    void Awake()
    {
        boardController = GetComponent<BoardController>();
    }

    void OnEnable()
    {
        BoardController.OnPlayerWin += OnPlayerWin;
        BoardController.OnPlayerDead += OnPlayerDead;
    }

    void OnDisable()
    {
        BoardController.OnPlayerWin -= OnPlayerWin;
        BoardController.OnPlayerDead -= OnPlayerDead;
    }

    void OnPlayerWin()
    {
        boardController.enabled = false;
        panel.SetActive(true);
        winLabel.SetActive(true);
        buttonRestart.SetActive(true);
    }

    void OnPlayerDead()
    {
        boardController.enabled = false;
        panel.SetActive(true);
        loseLabel.SetActive(true);
        buttonRestart.SetActive(true);
    }

    public void Restart()
    {
        boardController.enabled = true;
        panel.SetActive(false);
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
        buttonRestart.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
