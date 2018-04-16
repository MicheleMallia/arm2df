using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

using B83.ExpressionParser;

public class GraphGenerator : MonoBehaviour {

	public Transform pointPrefab;
	public Slider reso;
	public InputField input;
	public Text resoNumber;


	[Range(10, 100)]
	public int resolution = 10;

	void Start(){
		reso.onValueChanged.AddListener(delegate {ValueChangeCheck(); });
		GameObject.Find ("Shoot").GetComponent<Button> ().interactable = false;
	}

	public void ValueChangeCheck()
	{
		if (reso.value % 2 != 0)
			resolution = (int)reso.value+1;
		else
			resolution = (int)reso.value;
		resoNumber.text = resolution.ToString();

	}

	protected void deleteChilds(){
		if (transform.childCount > 0) {
			for (int i = 0; i < transform.childCount; i++) {
				Destroy(transform.GetChild(i).gameObject);
			}
		}
	}

	protected void Graph(string espressione){

		deleteChilds ();
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		float step = 2f / resolution;
		Vector3 position;
		Vector3 scale = Vector3.one * step;
		position.z = 0f;
			
		for (int i = 0; i < resolution; i++) {

			Transform point = Instantiate(pointPrefab);
			position.x = (i + 0.5f) * step - 1f;

			var parser = new ExpressionParser ();
			Expression exp = parser.EvaluateExpression (espressione);
			exp.Parameters ["x"].Value = position.x;
			position.y = (float)exp.Value;


			if (Double.IsNaN ((double)position.y)) {
				GameObject.Find ("NaN").transform.GetComponent<Text> ().text = "Some values are NaN";
			}

			point.localPosition = position*120;
			point.localScale = scale;
			point.localScale = new Vector3 (7f, 7f, 7f);
			point.SetParent(transform, false);
		}

	}

	public void graphGen(){
		
		string income = input.text;
		if (input.text.Length > 0) {
			if (income.Substring (income.Length - 1).IndexOfAny (new char[]{ '+', '*', '/', '^', '-' }) == -1) {
				var parser = new ExpressionParser ();
				Expression exp = parser.EvaluateExpression (income);
				if (exp.Value != 0 && income.IndexOfAny (new char[]{ 'x' }) == -1) {
					input.text = exp.Value.ToString ();
				} else if (exp.ToString ().IndexOfAny (new char[]{ 'x' }) != -1) {
					deleteChilds ();
					Graph (income);
					GameObject.Find ("Shoot").GetComponent<Button> ().interactable = true;
				}
			} else {
				GameObject.Find ("NaN").transform.GetComponent<Text> ().text = "You must insert a correct formula.";
				GameObject.Find ("Shoot").GetComponent<Button> ().interactable = false;
			}
		} else {
			input.placeholder.GetComponent<Text> ().text = "You must insert a formula before.";
			GameObject.Find ("Shoot").GetComponent<Button> ().interactable = false;
		}

	}

}
