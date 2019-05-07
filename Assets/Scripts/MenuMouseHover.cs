using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMouseHover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.transform.GetComponent<Renderer>().material.color = Color.white;
    }

	void OnMouseEnter () 
	{
		this.transform.GetComponent<Renderer>().material.color = Color.red;
    }
	
	void OnMouseExit ()
	{
		this.transform.GetComponent<Renderer>().material.color = Color.white;
    }
}
