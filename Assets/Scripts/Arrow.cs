using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

	public bool pressed;
	public Color normalColor;
	public Color pressedColor;

	SpriteRenderer sr;

	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer>();
	}

	void OnMouseDown() {
		pressed = true;
		sr.color = pressedColor;
	}

	void OnMouseUp() {
		pressed = false;
		sr.color = normalColor;
	}
}
