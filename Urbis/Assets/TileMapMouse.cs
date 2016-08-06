﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TileMap))]
public class TileMapMouse : MonoBehaviour {

	TileMap tileMap;

	Vector3 currentTileCoord;

	public Transform selectionCube;

	// Use this for initialization
	void Start() {
		tileMap = GetComponent<TileMap> ();
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hitInfo;

		// see if mouse is over game map
		if (gameObject.GetComponent<Collider>().Raycast(ray, out hitInfo, Mathf.Infinity)) 
		{
			// move selector cude to the tile
			int x = Mathf.FloorToInt (hitInfo.point.x / tileMap.tileSize);
			int z = Mathf.FloorToInt (hitInfo.point.z / tileMap.tileSize);
			//Debug.Log ("Tile: " + x + ", " + z);

			currentTileCoord.x = x;
			currentTileCoord.z = z;

			selectionCube.transform.position = currentTileCoord;
		} else {
			// Do something else
			// Hide cube maybe?
		}

		if (Input.GetMouseButtonDown (0)) {
			Debug.Log ("Click!");
		}
	}
}
