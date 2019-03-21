using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public GameObject flagLabel;
    public GameObject timerLabel;
    public GameObject panel;
    public GameObject winLabel;
    public GameObject loseLabel;
    public GameObject buttonRestart;

    private int flagCount = 0;
    private bool updateTimer = true;
    private float timer = 0;
    private float timerCount;
    private BoardController boardController;

    void Awake()
    {
        boardController = GetComponent<BoardController>();
        SetFlagLabel();
    }

    void OnEnable()
    {
        BoardController.OnPlayerWin += OnPlayerWin;
        BoardController.OnPlayerDead += OnPlayerDead;
        TileController.OnTileFlagChanged += OnTileFlagChanged;
    }

    void OnDisable()
    {
        BoardController.OnPlayerWin -= OnPlayerWin;
        BoardController.OnPlayerDead -= OnPlayerDead;
        TileController.OnTileFlagChanged -= OnTileFlagChanged;
    }

    void Update()
    {
        if (updateTimer)
        {
            if (timerCount > 1)
            {
                timer++;
                timerCount -= 1;
            }
            else
            {
                timerCount += Time.deltaTime;
            }
            timerLabel.GetComponent<Text>().text = this.convertNumberToTimeString(timer);
        }
    }

    void OnPlayerWin()
    {
        updateTimer = false;
        boardController.enabled = false;
        panel.SetActive(true);
        winLabel.SetActive(true);
        buttonRestart.SetActive(true);
    }

    void OnPlayerDead()
    {
        updateTimer = false;
        boardController.enabled = false;
        panel.SetActive(true);
        loseLabel.SetActive(true);
        buttonRestart.SetActive(true);
    }

    public void Restart()
    {
        updateTimer = true;
        boardController.enabled = true;
        panel.SetActive(false);
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
        buttonRestart.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private string convertNumberToTimeString(float number)
    {
        int minutes = (int)number / 60;
        int seconds = (int)number % 60;

        string minutesString = minutes < 10 ? "0" + minutes : minutes.ToString();
        string secondsString = seconds < 10 ? "0" + seconds : seconds.ToString();
        return minutesString + ":" + secondsString;
    }

    void OnTileFlagChanged(int increment)
    {
        if (increment > 0) flagCount++; else flagCount--;
        SetFlagLabel();
    }

    void SetFlagLabel()
    {
        flagLabel.GetComponent<Text>().text = "Flags: " + flagCount;
    }
}
