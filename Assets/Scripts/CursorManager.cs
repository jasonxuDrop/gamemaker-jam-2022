using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CursorManager : MonoBehaviour
{
	public GameObject pauseMenu;
	public GameObject deathMenu;
	public CharacterController controller;
	public CinemachineFreeLook cam;

	bool isCursorOn;
	bool isDead = false;


	private void Start()
	{
		SetCursor(false);
		deathMenu.SetActive(false);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape) && !isCursorOn)
		{
			SetCursor(!isCursorOn);
		}
	}

	public void SetCursor(bool state)
	{
		if (isDead)
			return;

		isCursorOn = state;
		pauseMenu.SetActive(state);
		Cursor.lockState = state? CursorLockMode.None : CursorLockMode.Locked;
		Cursor.visible = state;

		controller.enabled = !state;
		cam.enabled = !state;
	}

	public void Die()
	{
		isDead = true;
		deathMenu.SetActive(true);
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void ToStartScreen()
	{
		SceneManager.LoadScene(0);
	}
}
