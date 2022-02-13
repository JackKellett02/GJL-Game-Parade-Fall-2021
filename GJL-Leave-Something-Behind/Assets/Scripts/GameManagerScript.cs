//////////////////////////////////////////////////////////////////////////////////////////////////
/// Filename:          GameManagerScript.cs
/// Author:            Jack Kellett
/// Date Created:      21/11/2021
/// Brief:             To tell when the player has won or lost the game.
//////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour {
	#region Variables to assign via the unity inspector (SerializeFields).
	[SerializeField]
	private KeyCode startButton = KeyCode.Return;

	[SerializeField]
	private GameObject playerObjectReference = null;

	[SerializeField]
	private float howLongTillReturnToMenu = 5.0f;

	[SerializeField]
	private int coinCost = 10;

	[SerializeField]
	private int coinsPerSecond = 2;

	[SerializeField]
	private int healthButtonIncrease = 10;

	[SerializeField]
	private int staminaButtonIncrease = 10;

	[SerializeField]
	private GameObject gameUI = null;

	[SerializeField]
	private GameObject upgradesUI = null;
	#endregion

	#region Private Variable Declarations.

	private HeathScript playerHealthScript;
	private StaminaScript playerStaminaScript;
	private bool hasStarted = false;

	//Player upgrade variables.
	private int coins = 0;
	private float timer = 0.0f;
	#endregion

	#region Private Functions.
	// Start is called before the first frame update
	void Start() {
		playerHealthScript = playerObjectReference.GetComponent<HeathScript>();
		playerStaminaScript = playerObjectReference.GetComponent<StaminaScript>();

		//Player Upgrade variables.
		coins = GetPlayerCoins();
		timer = 0.0f;
	}

	// Update is called once per frame
	void Update() {
		ShouldGameStart();
		DisplayUI();
		IncreasePlayerCoins();
		CheckPlayerStats();
		CheckIfPlayerHasWon();
	}

	/// <summary>
	/// Brings the player back to the start of the level and resets any necessary variables.
	/// </summary>
	private void ResetLevel() {
		UpdatePlayerCoins();
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	/// <summary>
	/// Checks if the game has already started and if it hasn't it starts moving the scene.
	/// </summary>
	private void ShouldGameStart() {
		if (Input.GetKeyDown(startButton) && !hasStarted) {
			hasStarted = true;
			MovementScript.SetIsMoving(true);
		}
	}

	private void DisplayUI() {
		if (!hasStarted) {
			gameUI.SetActive(false);
			upgradesUI.SetActive(true);
		} else {
			gameUI.SetActive(true);
			upgradesUI.SetActive(false);
		}
	}

	private void IncreasePlayerCoins() {
		if (hasStarted) {
			timer += Time.deltaTime;
			if (timer >= 1.0f) {
				timer = 0.0f;
				coins += coinsPerSecond;
			}
		}
	}

	/// <summary>
	/// Check if the player has ran out of health or stamina and if yes reset the level.
	/// </summary>
	private void CheckPlayerStats() {
		if (playerHealthScript.GetDeathState()) {
			StartCoroutine("ResetCountdown");
		}
	}

	/// <summary>
	/// Checks if player has won the game and if they have it executes the necessary functions to let the player know they have won.
	/// </summary>
	private void CheckIfPlayerHasWon() {
		if (CastleScript.GetWinState()) {
			//Stop the player from moving.
			MovementScript.SetIsMoving(false);

			//Complete player victory pose.

			//Return to the main menu.
			StartCoroutine("StartMainMenuCountdown");
		}
	}

	private IEnumerator StartMainMenuCountdown() {
		playerObjectReference.GetComponent<VictoryAnimationScript>().PlayAnimation();
		yield return new WaitForSeconds(howLongTillReturnToMenu);
		UpdatePlayerCoins();
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}

	private IEnumerator ResetCountdown() {
		MovementScript.SetIsMoving(false);
		yield return new WaitForSeconds(howLongTillReturnToMenu);
		ResetLevel();
	}

	/// <summary>
	/// Gets the player coins ammount from the unity player pref.
	/// </summary>
	/// <returns></returns>
	private int GetPlayerCoins() {
		int value = 0;
		if (!PlayerPrefs.HasKey("playerCoins")) {
			PlayerPrefs.SetInt("playerCoins", value);
		} else {
			value = PlayerPrefs.GetInt("playerCoins");
		}

		return value;
	}

	/// <summary>
	/// Updates the coins player pref to match the current value.
	/// </summary>
	private void UpdatePlayerCoins() {
		PlayerPrefs.SetInt("playerCoins", coins);
	}
	#endregion

	#region Public Access Functions (Getters and Setters).
	/// <summary>
	/// Increases the max health if the player has enough coins.
	/// </summary>
	public void IncreaseMaxHealth() {
		if (coins >= coinCost) {
			playerHealthScript.IncreaseMaxHealth(healthButtonIncrease);
			coins -= coinCost;
		}
	}

	public void IncreaseMaxStamina() {
		if (coins >= coinCost) {
			playerStaminaScript.IncreaseMaxStamina(staminaButtonIncrease);
			coins -= coinCost;
		}
	}

	public int GetCoins() {
		return coins;
	}

	public void ResetCoinCount() {
		coins = 0;
		UpdatePlayerCoins();
	}

	public void ReturnToMainMenu() {
		UpdatePlayerCoins();
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}
	#endregion
}
