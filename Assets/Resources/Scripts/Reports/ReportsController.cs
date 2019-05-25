using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReportsController : MonoBehaviour
{
   public void CloseReport ()
   {
	   SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
   }
	
	
}
