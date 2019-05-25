using UnityEngine;
 using System.Collections;
 
 public class Line : MonoBehaviour {
 
     //private GameObject source = this;          // Reference to the first GameObject
     public GameObject destination;          // Reference to the second GameObject
	
	 public float width = 0.1f;
     
	 private LineRenderer line;                           // Line Renderer
 
     // Use this for initialization
     void Start () {
         // Add a Line Renderer to the GameObject
         line = this.gameObject.AddComponent<LineRenderer>();
         // Set color
		 // line.material.color = Color.red;
		 // Set the width of the Line Renderer
         line.startWidth = width;
         // Set the number of vertex fo the Line Renderer
         line.SetVertexCount(2);
		 
		 Debug.Log("LineRenderer successful.");
		 line.GetComponent<LineRenderer>().enabled = false;
		 
     }
     
     // Update is called once per frame
     void Update () {
         // Check if the GameObjects are not null
         Debug.Log("Hi I'm LineRenderer.");
		 
		 if (destination != null)
         {
             // Update position of the two vertex of the Line Renderer
             line.SetPosition(0, this.transform.position);
             line.SetPosition(1, destination.transform.position);
         }
     }
 }