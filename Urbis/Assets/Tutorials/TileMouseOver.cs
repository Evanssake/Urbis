using UnityEngine;
using System.Collections;

public class TileMouseOver : MonoBehaviour {

    public Color tileColor;
    public Color highlightColor;

    void Start()
    {
        tileColor = gameObject.GetComponent<Renderer>().material.color;
    }

	void OnMouseOver()
    {
        gameObject.GetComponent<Renderer>().material.color = highlightColor;
    }

    void OnMouseExit()
    {
        gameObject.GetComponent<Renderer>().material.color = tileColor;
    }
	
	// Update is called once per frame
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (gameObject.GetComponent<Collider>().Raycast(ray, out hitInfo, Mathf.Infinity)) 
        {
            gameObject.GetComponent<Renderer>().material.color = highlightColor;
        } else
        {
            gameObject.GetComponent<Renderer>().material.color = tileColor;
        }
	}
} 
