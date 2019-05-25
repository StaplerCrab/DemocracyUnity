
using System.Collections;
using UnityEngine;
 
class DragTransform : MonoBehaviour
{
    private Color mouseOverColor = Color.blue;
    private Color originalColor = Color.yellow;
    private bool dragging = false;
    private float distance;
 
   /*
    void OnMouseEnter()
    {
        gameObject.GetComponent<Renderer>().material.color = mouseOverColor;
    }
	
    void OnMouseExit()
    {
        gameObject.GetComponent<Renderer>().material.color = originalColor;
    }
	*/
	
    void OnMouseDown()
    {
		Vector3 newPos = new Vector3(transform.position.x, transform.position.y + 50, transform.position.z);
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
    }
 
    void OnMouseUp()
    {
        dragging = false;
    }
 
    void Update()
    {
        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y + 50, Input.mousePosition.z));
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = rayPoint;
        }
    }
}
 