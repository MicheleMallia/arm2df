using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TakeScreenshot : MonoBehaviour {

	[SerializeField]
	GameObject hideGameObject;

	public void TakeAShot()
	{
		StartCoroutine ("CaptureIt");
	}

	IEnumerator CaptureIt()
	{	
		hideGameObject.transform.gameObject.SetActive (false);
		string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
		string fileName = "Screenshot" + timeStamp + ".png";
		string pathToSave = fileName;
		ScreenCapture.CaptureScreenshot(pathToSave);
		yield return new WaitForEndOfFrame();
		hideGameObject.transform.gameObject.SetActive (true);

		//Instantiate (blink, new Vector2(0f, 0f), Quaternion.identity);
	}

}
