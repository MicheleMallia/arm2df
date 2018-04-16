using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class buttonManager : MonoBehaviour {

	public Button[] buttons;
	public InputField input;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < buttons.Length; i++) {
			if(buttons[i].name.IndexOfAny(new char[]{'+', '*', '/', '^'})!=-1){
				buttons[i].interactable = false;
			}
		}
	}
	
	// Se premo - e l'input field è vuoto
	// disabilito - per poter premere func
	public void minusHide () {
		if (input.text == null) {
			buttons [19].interactable = false;
		}
	}

	void Update(){
		
	}
}
