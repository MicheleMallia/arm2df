using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swipeRotate : MonoBehaviour {

	public Transform graph;
	public Transform xAxis;
	public Transform yAxis;

	void Start(){
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}

	void Update()
	{
		if (Input.touchCount == 1)
		{
			// GET TOUCH 0
			Touch touch0 = Input.GetTouch(0);

			// APPLY ROTATION
			if (touch0.phase == TouchPhase.Moved)
			{
				graph.transform.Rotate(0f, -touch0.deltaPosition.x, 0f);
				xAxis.transform.Rotate(-touch0.deltaPosition.x, 0f, 0f);
				yAxis.transform.Rotate(0f, -touch0.deltaPosition.x, 0f);
			}

		}
	}
}
