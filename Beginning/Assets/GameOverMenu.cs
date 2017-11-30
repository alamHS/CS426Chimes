using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour {

	public void RestartGame()
	{
		Debug.Log ("restart");
		SceneManager.LoadScene ("StoryOne");
	}

	public void quitGame()
	{
		Debug.Log ("quits");
		Application.Quit();
	}

}
