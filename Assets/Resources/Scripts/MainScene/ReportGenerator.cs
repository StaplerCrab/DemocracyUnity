﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReportGenerator : MonoBehaviour
{
   public void GenerateReport ()
   {
	   SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	   //Debug.Log(JsonDataManager.MakeQuery("ASAS", "ASAS","ASAS","ASAS"));
   }

}
