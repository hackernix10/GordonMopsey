using UnityEngine;
using System.Collections;

public class Bone : MonoBehaviour {

	public Sprite[] sprites;
	public GordonController gordon;

	// Use this for initialization
	void Start () {
		gordon = GameObject.Find("Gordon").GetComponent<GordonController>();
		SelectSprite();
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player") {
			gordon.boneCounter++;
			gordon.bonesCounter_Text.text = gordon.boneCounter.ToString();
			coll.transform.GetComponent<AudioSource>().Play();
			Destroy(gameObject);
		}
	}

	void SelectSprite () {
		var randomInt = Random.Range(0, sprites.Length);
		GetComponent<SpriteRenderer>().sprite = sprites[randomInt];
	}
}

