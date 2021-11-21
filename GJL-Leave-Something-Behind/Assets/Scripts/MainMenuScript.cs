/////////////////////////////////////////////////////////////////////////////////////////////////////
/// Filename:           MainMenuScript.cs
/// Author:             JackKellett
/// Date Created:       21/11/2021
/// Brief:              To allow the player to start the game.
/////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {
	#region Variables to assign via the unity inspector (SerializeFields).
	[SerializeField]
	private KeyCode startKey = KeyCode.Space;
	#endregion

	#region Private Functions.
	// Update is called once per frame
	void Update() {
		if (Input.GetKeyDown(startKey)) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
	}
	#endregion
}
