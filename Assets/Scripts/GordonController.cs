using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GordonController : MonoBehaviour {

	public float speed;
	public Transform screenControl;
	public bool keyboard;
	public int boneCounter;
	public Transform shitPrefab;
	public Transform[] eyes;
    
	public Text bonesCounter_Text;

	Transform shitSpawn;
	bool running;
	bool shiting;
	Animator animator;
	Arrow leftArrow;
	Arrow rightArrow;

	// Use this for initialization
	void Start () {
		shitSpawn = transform.Find("Ass");
		leftArrow = screenControl.Find("LeftArrow").GetComponent<Arrow>();
		rightArrow = screenControl.Find("RightArrow").GetComponent<Arrow>();
		screenControl.gameObject.SetActive(!keyboard);
		animator = GetComponent<Animator>();
		running = false;
		boneCounter = 0;
		eyes[0] = transform.Find("RightEye");
		eyes[1] = transform.Find("LeftEye");
		StartCoroutine(Parpadea());
	}

	public void TakeShit () {
		Instantiate(shitPrefab, shitSpawn.position, Quaternion.identity);
	}

	public void Sit ( bool sitdown ) {
		animator.SetBool("Sit", sitdown);
	}

	void FixedUpdate () {
		float direccion = 0.0f;

		if ( keyboard ) {
			direccion = Input.GetAxis("Horizontal");
			if ( Input.GetKeyDown(KeyCode.Space) )
				Instantiate(shitPrefab, shitSpawn.position, Quaternion.identity);
		}
		else{
			if ( leftArrow.pressed ) direccion = -1.0f;
			else if ( rightArrow.pressed ) direccion = 1.0f;
			else 	direccion = 0.0f;
		}

		running =  direccion != 0.0f && !animator.GetBool("Sit");
		animator.SetBool("Running", running);

		if ( running ) {
			if ( transform.position.x > -7.5f && Mathf.Sign(direccion) == -1.0f ||  transform.position.x < 40.5f && Mathf.Sign(direccion) == 1.0f ) {
				GetComponent<Rigidbody2D>().velocity = new Vector2( direccion * speed, 0.0f );
				direccion = Mathf.Sign(direccion);
				transform.localScale = new Vector3(direccion, 1.0f,1.0f);
			}
			else {
				GetComponent<Rigidbody2D>().velocity = new Vector2( 0.0f, 0.0f );
				running = false;
			}
			Debug.Log(direccion);
		}
		else 
			GetComponent<Rigidbody2D>().velocity = new Vector2( 0.0f, 0.0f );
	}

	IEnumerator Parpadea () {
		while(true) {
			Debug.Log("Parpadea");
			foreach( Transform eye in eyes ) {
				eye.gameObject.SetActive(false);
			}
			yield return new WaitForSeconds(Random.Range(0.25f,3.5f));
			foreach( Transform eye in eyes ) {
				eye.gameObject.SetActive(true);
			}
			yield return new WaitForSeconds(0.2f);
		}
	}
}