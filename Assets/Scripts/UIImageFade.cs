using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIImageFade : MonoBehaviour
{
    public Image[] imagesToFade = new Image[0];
	public GameObject canvasToTurnOff;
    public float timeToFadeOut;
    public float fadeDuration;

	private void Start()
	{
		foreach (var img in imagesToFade)
		{
			img.DOFade(0, fadeDuration).SetDelay(timeToFadeOut);
		}
		StartCoroutine(Timer());
	}

	IEnumerator Timer()
	{
		yield return new WaitForSecondsRealtime(timeToFadeOut+fadeDuration);
		canvasToTurnOff.SetActive(false);
	}
}
