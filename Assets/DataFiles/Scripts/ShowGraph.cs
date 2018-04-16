using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using B83.ExpressionParser;

public class ShowGraph : MonoBehaviour {

	public GameObject motherGraphs;

	public void changeGraph(){

		var parser = new ExpressionParser();
		//ParseException
		Expression exp = parser.EvaluateExpression("");
		Debug.Log("Result: " + exp.Value); 
		string selectedGraph = EventSystem.current.currentSelectedGameObject.name;

		for (int i = 0; i < motherGraphs.transform.childCount; i++) {
			if (motherGraphs.transform.GetChild (i).name == selectedGraph) {
				motherGraphs.transform.GetChild (i).gameObject.SetActive (true);
			} else {
				motherGraphs.transform.GetChild (i).gameObject.SetActive (false);
			}
		}
	}
}
