using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	
	public bool isStart;
	public bool isLoad;
	public bool isQuit;
	
    void OnMouseUp ()
	{
		if (isStart)
		{
			SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
		}
		if (isLoad)
		{
			this.transform.GetComponent<Renderer>().material.color = Color.cyan;
		}
		
		if (isQuit)
		{
			Application.Quit();
			this.transform.GetComponent<Renderer>().material.color = Color.cyan;
		}
	}
}
