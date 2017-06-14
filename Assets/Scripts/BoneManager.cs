using UnityEngine;
using System.Collections;

public class BoneManager : MonoBehaviour {

	public Transform BonePrefab;
	public float width;
	public float heightOffset;
	public float delaySeconds;
	bool waiting; 
	
	// Update is called once per frame
	void Update () {
		if ( !waiting)	StartCoroutine(CreateBone(delaySeconds));
	}

	IEnumerator CreateBone ( float delay) {
		waiting = true;
		Instantiate(BonePrefab, new Vector3(Random.Range(0, width), transform.position.y + heightOffset, 0.0f), Quaternion.identity);;
		yield return new WaitForSeconds(delay);
		waiting =false;
	}
}
