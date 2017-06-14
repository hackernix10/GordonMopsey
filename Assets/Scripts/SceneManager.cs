using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {

	public void SelectScene ( int scene ) {
		Application.LoadLevel(scene);
	}
}