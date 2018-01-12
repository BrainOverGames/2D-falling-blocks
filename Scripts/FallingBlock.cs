using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour 
{
	public Vector2 speedMinMax;
	float speed;
	float visibleHeightThreshold;

	void Start()
	{
		speed = Mathf.Lerp (speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPercent ());
		visibleHeightThreshold = -Camera.main.orthographicSize-transform.localScale.y ;
	}

	void Update()
	{
		transform.Translate (Vector3.down * speed * Time.deltaTime,Space.Self);		//space.self ni lagaega tab bhi by default space.self hi lega

		if (transform.position.y < visibleHeightThreshold) {
			Destroy (gameObject);
		}
	}
}
