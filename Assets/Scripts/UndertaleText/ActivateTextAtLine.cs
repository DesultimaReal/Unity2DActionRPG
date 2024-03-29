﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTextAtLine : MonoBehaviour {
	public TextAsset theText;
	public TextAsset GoodbyeText;
	public int startLine;
	public int endLine;
	public TextBoxManager theTextBox;

	public bool destroyWhenActivated;
	public bool requireButtonPress;
	private bool waitForPress;

	// Use this for initialization
	void Start() {
		theTextBox = FindObjectOfType<TextBoxManager>();
	}

	// Update is called once per frame
	void Update() {
		if (waitForPress && Input.GetKeyDown(KeyCode.J))
		{
			waitForPress = false;
			PlayText();
			theText = GoodbyeText;
		}
	}
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player")
		{
			if (requireButtonPress)
			{
				waitForPress = true;
				return;
			}
			PlayText();
		}
	}
	public void PlayText(){
		theTextBox.ReloadScript(theText);
		theTextBox.currentLine = startLine;
		theTextBox.endAtLine = endLine;
		theTextBox.EnableTextBox();
		if (destroyWhenActivated)
		{
			Destroy(gameObject);
		}
	}
	private void OnTriggerExit2D(Collider2D other)
	{
		if(other.name == "Player")
		{
			waitForPress = false;
		}
	}
}
