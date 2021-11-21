//////////////////////////////////////////////////////////////////////////////////////
/// Filename:        CastleScript.cs
/// Author:          Jack Kellett
/// Date Created:    21/11/2021
/// Brief:           To know when the player has reached the end of the level.
//////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CastleScript : MonoBehaviour {
	#region Private Variable Declarations.

	private static bool hasWon = false;


	#endregion

	#region Private Functions.

	private void Start()
	{
		hasWon = false;
	}

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player")
		{
			hasWon = true;
		}
	}
	#endregion

	#region Public Access Functions (Getters and Setters).

	public static bool GetWinState()
	{
		return hasWon;
	}
	#endregion
}
