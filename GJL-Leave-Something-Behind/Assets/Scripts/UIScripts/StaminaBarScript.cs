/////////////////////////////////////////////////////////////////////////////////////////////
/// Filename:          StaminaBarScript.cs
/// Author:            Jack Kellett
/// Date Created:      21/11/2021
/// Brief:             To Control the stamina bar to make it match the stamina percentage.
/////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaBarScript : MonoBehaviour {
	#region Variables to assign via the unity inspector (SerializeFields).
	[SerializeField]
	private StaminaScript playerStamina = null;

	[SerializeField]
	private RectTransform staminaBar = null;
	#endregion

	#region Private Variable Declarations.

	#endregion

	#region Private Functions.
	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update()
	{
		Vector3 movement = new Vector3(ConvertStaminaPercentageToBarMovement(), 0.0f, 0.0f);
		staminaBar.localPosition = movement;
	}

	private float ConvertStaminaPercentageToBarMovement() {
		float percentage = playerStamina.GetStaminaPercentage();
		percentage = 100 - percentage;
		return percentage * 6.5f;
	}
	#endregion

	#region Public Access Functions (Getters and Setters).

	#endregion
}
