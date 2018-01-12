using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour 
{
	public GameObject fallingBlockPrefab;
	public Vector2 secondsBetweenSpawnsMinMax;
	public Vector2 spawnSizeMinMax;
	//public float spawnSizeMinMAx;	// scale negative ni hona chahiye
	public float spawnAngleMax;

	float nextSpawnTime;
	Vector2 screenHalfSizeWorldUnits;

	void Start()
	{
		screenHalfSizeWorldUnits = new Vector2 (Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
	}

	void Update()
	{
		if (Time.time > nextSpawnTime) {
			//starting me spawn time max h means jyada time lagega spawn hone me and gradually jaldi jaldi spawn honge 
			float secondsBetweenSpawns = Mathf.Lerp (secondsBetweenSpawnsMinMax.y, secondsBetweenSpawnsMinMax.x, Difficulty.GetDifficultyPercent ());
			//print (secondsBetweenSpawns);
			nextSpawnTime = Time.time + secondsBetweenSpawns;
			//float spawnSize = Random.Range (-spawnSizeMinMAx,spawnSizeMinMAx);	//scale negative ni hona chahiye
			float spawnSize=Random.Range(spawnSizeMinMax.x,spawnSizeMinMax.y);
			//print (spawnSize);
			float spawnAngle = Random.Range (-spawnAngleMax, spawnAngleMax);
			//print (spawnAngle);
			Vector2 spawnPosition = new Vector2 (Random.Range(-screenHalfSizeWorldUnits.x,screenHalfSizeWorldUnits.x),screenHalfSizeWorldUnits.y+spawnSize);
			GameObject newBlock= Instantiate (fallingBlockPrefab, spawnPosition, Quaternion.Euler(Vector3.forward*spawnAngle)) as GameObject;
			newBlock.transform.localScale = Vector2.one * spawnSize;
		}
	}
}
