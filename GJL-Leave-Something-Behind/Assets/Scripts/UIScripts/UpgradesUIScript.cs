//////////////////////////////////////////////////////////////////////////////////////////////
/// Filename:          UpgradesUIScript.cs
/// Author:            Jack Kellett
/// Date Created:      21/11/2021
/// Brief:             To control the UI that is displayed to the player in the upgrades menu.
//////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradesUIScript : MonoBehaviour {
	#region Variables to assign via the unity inspector (SerializeFields).
	[SerializeField]
	private TextMeshProUGUI maxHealthText = null;

	[SerializeField]
	private TextMeshProUGUI maxStaminaText = null;
	
	[SerializeField]
	private TextMeshProUGUI coinsText = null;

	[SerializeField]
	private StaminaScript playerStamina = null;

	[SerializeField]
	private HeathScript playerHealth = null;

	[SerializeField]
	private GameManagerScript gameManager = null;
	#endregion

	#region Private Variable Declarations.
	
	#endregion

	#region Private Functions.
	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {
		maxHealthText.text = "Current Max Health: " + playerHealth.GetMaxHealth();
		maxStaminaText.text = "Current Max Stamina: " + playerStamina.GetMaxStamina();
		coinsText.text = "Coins: " + gameManager.GetCoins();
	}
	#endregion
}
