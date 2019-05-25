using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform popupText;
	public static bool textstatus = false;
	
	void OnMouseEnter ()
	{
		if (textstatus == false)
		{
			popupText.GetComponent<TextMesh>().text = "sample text here";
			textstatus = true;
			Instantiate (popupText, new Vector3(transform.position.x, transform.position.y+2, 0), popupText.rotation);
			
		}
	}
	
	void OnMouseExit ()
	{
		if (textstatus == true)
		{
			textstatus = false;
			Instantiate (popupText, new Vector3(transform.position.x, transform.position.y+2, 0), popupText.rotation);
			
		}
	}
}
