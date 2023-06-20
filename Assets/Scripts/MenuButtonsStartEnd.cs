using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonsStartEnd : MonoBehaviour
{
	public void ToGame()
	{
		SceneManager.LoadScene(1);
	}

	public void ToMainMenu()
	{
		SceneManager.LoadScene(0);
	}

	public void QuitGame()
	{
#if UNITY_EDITOR
		// Application.Quit() does not work in the editor so
		// UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
		UnityEditor.EditorApplication.isPlaying = false;
#else
             Application.Quit();
#endif
	}

	public void ToWebsite()
	{
		Application.OpenURL("https://itch.io/jam/gmtk-jam-2022/rate/1623183");
	}
}
