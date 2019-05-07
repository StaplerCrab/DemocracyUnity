using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjControl : MonoBehaviour
{
    // public static string zoomActive = "n";
	public Rect windowRect = new Rect(20, 20, 120, 50);
	
	private bool PopUp = false;
	private string Info;
	Camera m_MainCam;
	Canvas infoCanvas;
	
	int numChild;
	private bool lineActive = false;
	
	// Start is called before the first frame update
    void Start()
    {
		m_MainCam = Camera.main;
		//relation = GameObject.Find("aToB");
		// relation.GetComponent<Line>().enabled = false;
	}

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Backspace))
		{
			Debug.Log("Backspace key is pressed");
			// zoomActive = "n";
			// m_MainCam.transform.position = SetInitial.initPosition;
			
			PopUp = false;
		}
    }

	void OnMouseDown () {
		/* if (zoomActive == "n")
		{
			zoomActive = "y";
			//m_MainCam.transform.position = new Vector3(transform.position.x, transform.position.y, -13);
			
			PopUp = true;
		}
		*/
		lineController();
		PopUp = true;
		
		
		
		
	}

	void DrawInfo()
    {
        Rect rect = new Rect (0, 0, (Screen.width - 1000), (Screen.height - 300));
        Rect close = new Rect (0,0,20,20);
        if (PopUp)
        {
            GUI.Box(rect, Info);
            if (GUI.Button(close,"X"))
            {
                // zoomActive = "n";
				
				PopUp = false;
            }
        }
    }
	
	void OnGUI ()
	{
		DrawInfo();
	}
	
	void lineController ()
	{
		// Get number of relationships object has
		numChild = this.transform.childCount;
		
		// Check if lines are visible.
		// If no, activate each relationship's LineRenderer.
		if (lineActive == false)
		{
			for (int i = 0; i < numChild; i++)
			{
				this.transform.GetChild(i).GetComponentInChildren<LineRenderer>().enabled = true;
				
			}
			
			// Set visible flag.
			lineActive = true;
		}
		// If yes, deactivate each relationship's LineRenderer.
		else
		{
			for (int i = 0; i < numChild; i++)
			{
				this.transform.GetChild(i).GetComponentInChildren<LineRenderer>().enabled = false;
			}
			// Reset visible flag.
			lineActive = false;
		}
	}
	
}
