using TMPro;

using UnityEngine;

namespace de.firegate.breakout
{
	public class GameManager : MonoBehaviour
	{
		public static GameManager Instance;

		public GameObject StartScreen;
		public GameObject WinScreen;
		public GameObject EndScreen;
		public TextMeshProUGUI ScoreBoard;
		public TextMeshProUGUI Timer;
		public Ball Ball;

		private bool _isGameRunning;
		private bool _isGameOver;
		private int _score;
		private float _timeRunning;
		private int _brickCount;

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
			_brickCount = FindObjectsOfType<Brick>().Length;
		}

		// Update is called once per frame
		private void Update()
		{
			if ( !_isGameOver )
			{
				if ( !_isGameRunning && Input.GetButton("Jump") )
				{
					Ball.Accelarate();
					_isGameRunning = true;

					StartScreen.SetActive(false);
				}

				if ( _isGameRunning )
				{
					_timeRunning += Time.deltaTime;

					Timer.text = (int) (_timeRunning / 60) + ":" + (int) (_timeRunning % 60);
				}

				if ( _score >= _brickCount ) GameWon();
			}
		}

		public void BrickDestroyed()
		{
			_score++;
			ScoreBoard.text = _score.ToString();
		}
	}
}
