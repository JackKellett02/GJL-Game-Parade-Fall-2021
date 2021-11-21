/////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Filename:        HealthScript.cs
/// Author:          Jack Kellett
/// Date Created:    20/11/2021
/// Brief:           To catalog how much health something has and to allow an object to be damaged or healed.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeathScript : MonoBehaviour {
	#region Variables to assign via the unity inspector (SerializeFields).
	[SerializeField]
	private int maxHealth = 100;
	#endregion

	#region Private Variable Declarations.

	private bool isDead = false;
	private int currentHealth = 100;
	private float currentHealthPercentage = 100.0f;

	private AudioManagerScript audioManager = null;
	#endregion

	#region Private Functions.
	// Start is called before the first frame update
	void Start() {
		//Get the audio manager.
		audioManager = GameObject.FindGameObjectsWithTag("AudioManager")[0].GetComponent<AudioManagerScript>();

		//Set up health variables.
		maxHealth = GetMaxHealthPlayerPref(maxHealth);
		currentHealth = maxHealth;
		currentHealthPercentage = CalculateHealthPercentage();
	}

	// Update is called once per frame
	void Update() {
		if (currentHealth <= 0) {
			isDead = true;
			Debug.Log("LOG::Player killed!!");
		}
	}

	/// <summary>
	/// Checks the current max health player pref and gets it for the game during start.
	/// </summary>
	/// <param name="value"></param>
	/// <returns></returns>
	private int GetMaxHealthPlayerPref(int value) {
		if (!PlayerPrefs.HasKey("maxHealth")) {
			PlayerPrefs.SetInt("maxHealth", value);
		} else {
			value = PlayerPrefs.GetInt("maxHealth");
		}

		return value;
	}

	/// <summary>
	/// Updates the max health player pref to the current maxHealth value.
	/// </summary>
	private void UpdateHealthPlayerPref() {
		PlayerPrefs.SetInt("maxHealth", maxHealth);
	}

	private float CalculateHealthPercentage() {
		float percentage = ((float)currentHealth / (float)maxHealth) * 100.0f;
		return percentage;
	}
	#endregion

	#region Public Access Functions (Getters and Setters).

	public void HealToMax() {
		currentHealth = maxHealth;
		currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
		currentHealthPercentage = CalculateHealthPercentage();
		Debug.Log("LOG::Player healed to max!!");
	}

	public void HealByInt(int health) {
		currentHealth += health;
		currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
		currentHealthPercentage = CalculateHealthPercentage();
		Debug.Log("LOG::Player healed by " + health + " points!!");
	}

	/// <summary>
	/// Maximum possible health = 500 points.
	/// </summary>
	/// <param name="increment"></param>
	public void IncreaseMaxHealth(int increment) {
		maxHealth += increment;
		UpdateHealthPlayerPref();
		HealToMax();
		currentHealthPercentage = CalculateHealthPercentage();
		Debug.Log("LOG::Max health increased by " + increment + " points!!");
	}

	public void ResetMaxHealth() {
		maxHealth = 100;
		UpdateHealthPlayerPref();
		HealToMax();
		currentHealthPercentage = CalculateHealthPercentage();
	}

	public void DamageByInt(int health) {
		currentHealth -= health;
		currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
		currentHealthPercentage = CalculateHealthPercentage();
		audioManager.PlayPlayerHitSound();
		Debug.Log("LOG::Player damaged by " + health + " points!!");
	}

	public float GetCurrentHealthPercentage() {
		return currentHealthPercentage;
	}

	public int GetMaxHealth()
	{
		return maxHealth;
	}

	public bool GetDeathState() {
		return isDead;
	}
	#endregion
}
