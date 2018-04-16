using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour {

	public InputField input;
	public GameObject graph;
	private List<string> memory = new List<string> ();

	public void textToInputField(){
		string buttonClicked = EventSystem.current.currentSelectedGameObject.name;

		if (memory.Count > 6) {
			if (memory[memory.Count-1].IndexOfAny(new char[]{ '+', '*', '/', '^' }) != -1) {
				memory.Remove(memory[memory.Count - 1]);
			}
		} else {
			if(memory.Count == 0){
				if (buttonClicked.IndexOfAny (new char[]{ '+', '*', '/', '^' }) != -1) {
					input.text = input.text;
				} else {
					input.text += buttonClicked;
					memory.Add (buttonClicked);
				}
			}
			else if (memory.Count > 0) {
				if (memory [memory.Count - 1].IndexOfAny (new char[]{ '+', '*', '/', '^', '-' }) != -1 && buttonClicked.IndexOfAny (new char[] {
					'+',
					'*',
					'/',
					'^',
					'-'
				}) != -1) {
					input.text = input.text;
				}
				else if(memory[memory.Count-1].IndexOfAny (new char[]{ '+', '*', '/', '^', '-' }) == -1 && buttonClicked.IndexOfAny (new char[] {
					'+',
					'*',
					'/',
					'^',
					'-'
				}) == -1){
					input.text += "*"+buttonClicked;
					memory.Add ("*");
					memory.Add (buttonClicked);
				}

				else {
					input.text += buttonClicked;
					memory.Add (buttonClicked);
				}

			}
		}

	}

	public void delete(){
		input.text = "";
		input.placeholder.GetComponent<Text> ().text = "Insert formula";
		memory.Clear ();
		if (graph.transform.childCount > 0) {
			for (int i = 0; i < graph.transform.childCount; i++) {
				Destroy (graph.transform.GetChild (i).gameObject);
			}
		}
		GameObject.Find ("NaN").transform.GetComponent<Text> ().text = "";
		GameObject.Find ("Shoot").GetComponent<Button> ().interactable = false;
	}

}
