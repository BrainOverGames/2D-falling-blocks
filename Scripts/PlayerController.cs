using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;

public class PlayerController : MonoBehaviour 
{
	float screenHalfWidthInWorldUnits;
	public event System.Action OnPlayerDeath;

	void Start()
	{
		float playerHalfWidth = transform.localScale.x / 2f;
		screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize + playerHalfWidth;
		//if player must not move out of camera bounds(look at signs) 
		//screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize - playerHalfWidth;
	}

	void Update () 
	{
		Vector2 input = new Vector2 (CnInputManager.GetAxisRaw ("Horizontal"), 0f);
		transform.Translate (input * Time.deltaTime * 10);

		if (transform.position.x < -screenHalfWidthInWorldUnits) {
			transform.position = new Vector2 (screenHalfWidthInWorldUnits, transform.position.y);
			//if player must not move out of camera bounds(look at signs) 
			//transform.position = new Vector2 (-screenHalfWidthInWorldUnits, transform.position.y);
		}

		if (transform.position.x > screenHalfWidthInWorldUnits) {
			transform.position = new Vector2 (-screenHalfWidthInWorldUnits, transform.position.y);
			//if player must not move out of camera bounds(look at signs) 
			//transform.position = new Vector2 (screenHalfWidthInWorldUnits, transform.position.y);
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Block") {
			if (OnPlayerDeath != null) {
				OnPlayerDeath ();
			}
			Destroy (gameObject);
		}
	}
		
}
