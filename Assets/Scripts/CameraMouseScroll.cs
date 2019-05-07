using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouseScroll : MonoBehaviour
{
 public int Boundary = 50; // distance from edge scrolling starts
 public int speed = 10;
 private int theScreenWidth;
 private int theScreenHeight;
 private Vector3 n_Pos;
 
 
 void Start() 
 {
     theScreenWidth = Screen.width;
     theScreenHeight = Screen.height;
	 n_Pos = transform.position;
	 

 }
 void Update() 
 {
     if(Input.GetButton("Fire1")){
	 if ((Input.mousePosition.x > theScreenWidth - Boundary))
     {
		n_Pos.x += speed * Time.deltaTime; // move on +X axis
		transform.position = n_Pos;
     }
     if (Input.mousePosition.x < 0 + Boundary)
     {
        n_Pos.x -= speed * Time.deltaTime; // move on -X axis
		transform.position = n_Pos;
     }
     if (Input.mousePosition.y > theScreenHeight - Boundary)
     {
        n_Pos.y += speed * Time.deltaTime; // move on +Z axis
		transform.position = n_Pos;
     }
     if (Input.mousePosition.y < 0 + Boundary)
     {
        n_Pos.y -= speed * Time.deltaTime; // move on -Z axis
		transform.position = n_Pos;
     }
	 }
 }   
 /*void OnGUI() 
 {
     GUI.Box( Rect( (Screen.width / 2) - 140, 5, 280, 25 ), "Mouse Position = " + Input.mousePosition );
     GUI.Box( Rect( (Screen.width / 2) - 70, Screen.height - 30, 140, 25 ), "Mouse X = " + Input.mousePosition.x );
     GUI.Box( Rect( 5, (Screen.height / 2) - 12, 140, 25 ), "Mouse Y = " + Input.mousePosition.y );
 }
 */
}
