using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInitial : MonoBehaviour
{
	
	public static Vector3 initPosition;
	// Start is called before the first frame update
    void Start()
    {
		initPosition = transform.position;
		Debug.Log("Initial Position is  " + initPosition);
    }
}
