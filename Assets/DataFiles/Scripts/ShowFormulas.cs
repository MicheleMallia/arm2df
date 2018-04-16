using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowFormulas : MonoBehaviour {


	public GameObject TableFormulas;
	bool trigger_formulas = false;
	// Use this for initialization
	void Start () {
		TableFormulas.SetActive(trigger_formulas);
	}
	
	// Update is called once per frame
	public void trigger () {
		trigger_formulas = !trigger_formulas;
		TableFormulas.SetActive(trigger_formulas);
	}
}
