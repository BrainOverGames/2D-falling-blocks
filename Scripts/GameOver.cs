using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour 
{
	public GameObject gameOverUI;
	public Text secondsSurvivedUI;
	public Button restartButton;

	bool isGameOver;

	void Start()
	{
		restartButton.onClick.AddListener (RestartOnClick);
		FindObjectOfType<PlayerController> ().OnPlayerDeath += OnGameOver;
	}

	public void Update()
	{
		if (isGameOver) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				SceneManager.LoadScene (0);
			}
		}
	}

	void RestartOnClick()
	{
		if (isGameOver) {
			SceneManager.LoadScene (0);
		}
	}

	void OnGameOver()
	{
		gameOverUI.SetActive (true);
		secondsSurvivedUI.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString ();
		isGameOver = true;
	}
}
