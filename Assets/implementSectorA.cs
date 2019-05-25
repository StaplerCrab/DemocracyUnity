using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class implementSectorA : MonoBehaviour
{
	public GameObject neu_prefab;
	// public GameObject pos_prefab;
	// public GameObject neg_prefab;

    // Update is called once per frame
    public void Implement ()
    {
        GameObject temp = Instantiate(neu_prefab, sectorOrigin.SEC_ONE_REF, Quaternion.identity);
    }
}
