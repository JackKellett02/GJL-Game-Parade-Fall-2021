//////////////////////////////////////////////////////////////////////////////////////////////////
/// Filename:         HealthBarScript.cs
/// Author:           Jack Kellett
/// Date Created:     20/11/2021
/// Brief:            To show the player how much health they have left
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarScript : MonoBehaviour {
	#region Variables to assign via the unity inspector (SerializeFields).
	[SerializeField]
	private GameObject segment1 = null;

	[SerializeField]
	private GameObject segment2 = null;

	[SerializeField]
	private GameObject segment3 = null;

	[SerializeField]
	private GameObject segment4 = null;

	[SerializeField]
	private GameObject segment5 = null;

	[SerializeField]
	private GameObject segment6 = null;

	[SerializeField]
	private GameObject segment7 = null;

	[SerializeField]
	private GameObject segment8 = null;

	[SerializeField]
	private GameObject segment9 = null;

	[SerializeField]
	private GameObject segment10 = null;
	#endregion

	#region Private Variable Declarations.

	private HeathScript playerHeathScript;
	private bool firstFrame = true;
	#endregion

	#region Private Functions.
	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {
		//Anything we only want to do in the first frame to ensure it's run after the start function is run.
		if (firstFrame) {
			firstFrame = false;
			playerHeathScript = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<HeathScript>();
		}

		if (playerHeathScript.GetCurrentHealthPercentage() <= 0.0f) {
			segment1.SetActive(false);
			segment2.SetActive(false);
			segment3.SetActive(false);
			segment4.SetActive(false);
			segment5.SetActive(false);
			segment6.SetActive(false);
			segment7.SetActive(false);
			segment8.SetActive(false);
			segment9.SetActive(false);
			segment10.SetActive(false);
		}
		if (playerHeathScript.GetCurrentHealthPercentage() > 0.0f) {
			segment1.SetActive(true);
			segment2.SetActive(false);
			segment3.SetActive(false);
			segment4.SetActive(false);
			segment5.SetActive(false);
			segment6.SetActive(false);
			segment7.SetActive(false);
			segment8.SetActive(false);
			segment9.SetActive(false);
			segment10.SetActive(false);
		}
		if (playerHeathScript.GetCurrentHealthPercentage() > 10.0f) {
			segment1.SetActive(true);
			segment2.SetActive(true);
			segment3.SetActive(false);
			segment4.SetActive(false);
			segment5.SetActive(false);
			segment6.SetActive(false);
			segment7.SetActive(false);
			segment8.SetActive(false);
			segment9.SetActive(false);
			segment10.SetActive(false);
		}
		if (playerHeathScript.GetCurrentHealthPercentage() > 20.0f) {
			segment1.SetActive(true);
			segment2.SetActive(true);
			segment3.SetActive(true);
			segment4.SetActive(false);
			segment5.SetActive(false);
			segment6.SetActive(false);
			segment7.SetActive(false);
			segment8.SetActive(false);
			segment9.SetActive(false);
			segment10.SetActive(false);
		}
		if (playerHeathScript.GetCurrentHealthPercentage() > 30.0f) {
			segment1.SetActive(true);
			segment2.SetActive(true);
			segment3.SetActive(true);
			segment4.SetActive(true);
			segment5.SetActive(false);
			segment6.SetActive(false);
			segment7.SetActive(false);
			segment8.SetActive(false);
			segment9.SetActive(false);
			segment10.SetActive(false);
		}
		if (playerHeathScript.GetCurrentHealthPercentage() > 40.0f) {
			segment1.SetActive(true);
			segment2.SetActive(true);
			segment3.SetActive(true);
			segment4.SetActive(true);
			segment5.SetActive(true);
			segment6.SetActive(false);
			segment7.SetActive(false);
			segment8.SetActive(false);
			segment9.SetActive(false);
			segment10.SetActive(false);
		}
		if (playerHeathScript.GetCurrentHealthPercentage() > 50.0f) {
			segment1.SetActive(true);
			segment2.SetActive(true);
			segment3.SetActive(true);
			segment4.SetActive(true);
			segment5.SetActive(true);
			segment6.SetActive(true);
			segment7.SetActive(false);
			segment8.SetActive(false);
			segment9.SetActive(false);
			segment10.SetActive(false);
		}
		if (playerHeathScript.GetCurrentHealthPercentage() > 60.0f) {
			segment1.SetActive(true);
			segment2.SetActive(true);
			segment3.SetActive(true);
			segment4.SetActive(true);
			segment5.SetActive(true);
			segment6.SetActive(true);
			segment7.SetActive(true);
			segment8.SetActive(false);
			segment9.SetActive(false);
			segment10.SetActive(false);
		}
		if (playerHeathScript.GetCurrentHealthPercentage() > 70.0f) {
			segment1.SetActive(true);
			segment2.SetActive(true);
			segment3.SetActive(true);
			segment4.SetActive(true);
			segment5.SetActive(true);
			segment6.SetActive(true);
			segment7.SetActive(true);
			segment8.SetActive(true);
			segment9.SetActive(false);
			segment10.SetActive(false);
		}
		if (playerHeathScript.GetCurrentHealthPercentage() > 80.0f) {
			segment1.SetActive(true);
			segment2.SetActive(true);
			segment3.SetActive(true);
			segment4.SetActive(true);
			segment5.SetActive(true);
			segment6.SetActive(true);
			segment7.SetActive(true);
			segment8.SetActive(true);
			segment9.SetActive(true);
			segment10.SetActive(false);
		}
		if (playerHeathScript.GetCurrentHealthPercentage() > 90.0f) {
			segment1.SetActive(true);
			segment2.SetActive(true);
			segment3.SetActive(true);
			segment4.SetActive(true);
			segment5.SetActive(true);
			segment6.SetActive(true);
			segment7.SetActive(true);
			segment8.SetActive(true);
			segment9.SetActive(true);
			segment10.SetActive(true);
		}
	}
	#endregion

	#region Public Access Functions (Getters and Setters).

	#endregion
}
