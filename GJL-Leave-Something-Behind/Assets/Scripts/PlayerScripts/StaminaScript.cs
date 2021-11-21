////////////////////////////////////////////////////////////////////////////////////////////////
/// Filename:            StaminaScript.cs
/// Author:              Jack Kellett
/// Date Created:        21/11/2021
/// Brief:               To decide if the player can keep running or not.
////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaScript : MonoBehaviour {
	#region Variables to assign via the unity inspector (SerializeFields).
	[SerializeField]
	private float maxStamina = 100;
	#endregion

	#region Private Variable Declarations.

	private bool isOutOfStamina = false;
	private float currentStamina = 100;
	private float currentStaminaPercentage = 100.0f;
	#endregion

	#region Private Functions.
	// Start is called before the first frame update
	void Start() {
		maxStamina = GetMaxStaminaPlayerPref(maxStamina);
		currentStamina = maxStamina;
		currentStaminaPercentage = CalculateStaminaPercentage();
	}

	// Update is called once per frame
	void Update() {
		if (currentStamina <= 0) {
			isOutOfStamina = true;
		}
	}

	/// <summary>
	/// Checks the current max health player pref and gets it for the game during start.
	/// </summary>
	/// <param name="value"></param>
	/// <returns></returns>
	private float GetMaxStaminaPlayerPref(float value) {
		if (!PlayerPrefs.HasKey("maxStamina")) {
			PlayerPrefs.SetFloat("maxStamina", value);
		} else {
			value = PlayerPrefs.GetFloat("maxStamina");
		}

		return value;
	}

	/// <summary>
	/// Updates the max health player pref to the current maxStamina value.
	/// </summary>
	private void UpdateStaminaPlayerPref() {
		PlayerPrefs.SetFloat("maxStamina", maxStamina);
	}

	private float CalculateStaminaPercentage() {
		float percentage = ((float)currentStamina / (float)maxStamina) * 100.0f;
		return percentage;
	}
	#endregion

	#region Public Access Functions (Getters and Setters).

	public void IncreaseToMax() {
		currentStamina = maxStamina;
		currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
		currentStaminaPercentage = CalculateStaminaPercentage();
	}

	public void IncreaseByFloat(float stamina) {
		currentStamina += stamina;
		currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
		currentStaminaPercentage = CalculateStaminaPercentage();
	}

	/// <summary>
	/// Maximum possible health = 500 pofloats.
	/// </summary>
	/// <param name="increment"></param>
	public void IncreaseMaxStamina(float increment) {
		maxStamina += increment;
		UpdateStaminaPlayerPref();
		IncreaseToMax();
		currentStaminaPercentage = CalculateStaminaPercentage();
	}

	public void DecreaseByFloat(float stamina) {
		currentStamina -= stamina;
		currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
		currentStaminaPercentage = CalculateStaminaPercentage();
	}

	public float GetStaminaPercentage() {
		return currentStaminaPercentage;
	}

	public float GetMaxStamina()
	{
		return maxStamina;
	}

	public bool GetOutOfStamina() {
		return isOutOfStamina;
	}
	#endregion
}
