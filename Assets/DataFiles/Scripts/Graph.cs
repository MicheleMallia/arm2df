using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Graph : MonoBehaviour {


	public Transform pointPrefab;

	[Range(10, 100)]
	public int resolution = 10;

	// Extract formula from a string method
	//Debug.Log((float)typeof(Mathf).GetMethod("Sin").Invoke(null, new object[]{position.x}));


	void Awake(){
		float step = 2f / resolution;
		Vector3 position;
		Vector3 scale = Vector3.one * step;
		position.z = 0f;
		for (int i = 0; i < resolution; i++) {
			Transform point = Instantiate(pointPrefab);
			position.x = (i + 0.5f) * step - 1f;
			position.y = position.x;
			point.localPosition = position;
			point.localScale = scale;
			point.SetParent(transform);
		}
	}
}
