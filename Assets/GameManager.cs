using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject StartScreen;
    public GameObject WinScreen;
    public GameObject EndScreen;
    public TextMeshProUGUI ScoreBoard;
    public TextMeshProUGUI Timer;
    public Ball Ball;

    private bool _isGameRunning = false;
    private bool _isGameOver = false;
    private int _score = 0;
    private float _timeRunning = 0;
    private int _brickCount = 0;

    private void GameWon()
    {
        _isGameRunning = false;
        _isGameOver = true;
        Destroy(Ball.gameObject);
        WinScreen.SetActive(true);
    }

    public void GameOver()
    {
        _isGameRunning = false;
        _isGameOver = true;
        Destroy(Ball.gameObject);
        EndScreen.SetActive(true);
    }

    private void Awake()
    {
        Instance = this;
        _brickCount = GameObject.FindObjectsOfType<Brick>().Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isGameOver)
        {
            if (!_isGameRunning && Input.GetButton("Jump"))
            {
                Ball.Accelarate();
                _isGameRunning = true;

                StartScreen.SetActive(false);
            }

            if (_isGameRunning)
            {
                _timeRunning += Time.deltaTime;

                Timer.text = ((int)(_timeRunning / 60)) + ":" + ((int)(_timeRunning % 60));
            }

            if (_score >= _brickCount)
            {
                GameWon();
            }
        }
    }

    public void BrickDestroyed()
    {
        _score++;
        ScoreBoard.text = _score.ToString();
    }
}
