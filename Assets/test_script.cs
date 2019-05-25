using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_script : MonoBehaviour
{
    private bool isActive;
	public GameObject neu_prefab;
	public GameObject pos_prefab;
	public GameObject neg_prefab;
	public GameObject strat_move;

	public string new_name = "hello";
	private GameObject temp;
	
	public int sector;
	
	
	
	// Start is called before the first frame update
    void Start()
    {
        // isActive = false;
		//neu_prefab = Resources.Load<GameObject>("neutral_indicator");	
	
		if (neu_prefab != null)
			Debug.Log("is not null");
		else
			Debug.Log("is null");
		
		
    }

    // Update is called once per frame
    void Update()
    {	
		if (Input.GetKeyDown(KeyCode.A))
		{
			Debug.Log("A key pressed!");
			temp = Instantiate(neu_prefab, new Vector3(-1, 20, 0), Quaternion.identity);
			temp.name = new_name;
		}
		
		else if (Input.GetKeyDown(KeyCode.S))
		{
			Debug.Log("S key pressed!");
			temp = Instantiate(neg_prefab, new Vector3(-1, 20, 0), Quaternion.identity);
			temp.name = new_name;
		}
		
		else if (Input.GetKeyDown(KeyCode.D))
		{
			Debug.Log("D key pressed!");
			temp = Instantiate(pos_prefab, new Vector3(-1, 20, 0), Quaternion.identity);
			temp.name = new_name;
		}
		
		else if ((Input.GetKeyDown(KeyCode.Space)))
		{
			Debug.Log("Space key pressed!");
			temp = Instantiate(strat_move, new Vector3(-1, 20, 0), Quaternion.identity);
			temp.name = new_name;
		}
		
			/*switch (sector)
			{
				case 1:
					temp = Instantiate(neu_prefab, new Vector3(-1, 20, 0), Quaternion.identity);
					temp.name = new_name;
					break;
				case 2:
					//Instantiate(prefab, new Vector3(10, 10, 0), Quaternion.identity);
					break;
				case 3:
					//Instantiate(prefab, new Vector3(-10,-10, 0), Quaternion.identity);
					break;
				case 4:
					//Instantiate(prefab, new Vector3(10, -10, 0), Quaternion.identity);
					break;
				default:
					Debug.Log("Sector not found!");
					break;
			}
			*/
			Debug.Log(new_name);
		
		
    }
	
	// (GameObject)Resources.Load("/Prefabs/yourPrefab");
	
}
