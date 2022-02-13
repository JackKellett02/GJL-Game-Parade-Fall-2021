////////////////////////////////////////////////////////////////////////////////////////////////
/// Filename:          MovementScript.cs
/// Author:            Jack Kellett
/// Date Created:      21/11/2021
/// Brief:             To move the background to show the player that they are "moving".
////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour {
	#region Variables to assign via the unity inspector (SerializeFields).
	[SerializeField]
	private float movementSpeed = 10.0f;

	[SerializeField]
	private GameObject mainGround = null;

	[SerializeField]
	private GameObject backgroundClose = null;

	[SerializeField]
	private GameObject backgroundMid = null;

	[SerializeField]
	private GameObject backgroundFar = null;
	#endregion

	#region Private Variable Declarations.

	private GameObject playerGameObject = null;
	private static bool isMoving = true;
	#endregion

	#region Private Functions.
	// Start is called before the first frame update
	void Start()
	{
		playerGameObject = GameObject.FindGameObjectsWithTag("Player")[0];
		SetIsMoving(false);
	}

	// Update is called once per frame
	void Update() {
		if (isMoving) {
			playerGameObject.GetComponent<RunningAnimationScript>().PlayAnimation();
			playerGameObject.GetComponent<StandingAnimationScript>().StopAnimation();
			playerGameObject.GetComponent<VictoryAnimationScript>().StopAnimation();
			playerGameObject.GetComponent<DeathAnimationScript>().StopAnimation();
			Move();
		} else if (CastleScript.GetWinState()) {
			playerGameObject.GetComponent<RunningAnimationScript>().StopAnimation();
			playerGameObject.GetComponent<StandingAnimationScript>().StopAnimation();
			playerGameObject.GetComponent<VictoryAnimationScript>().PlayAnimation();
			playerGameObject.GetComponent<DeathAnimationScript>().StopAnimation();
		} else if (playerGameObject.GetComponent<HeathScript>().GetDeathState()) {
			playerGameObject.GetComponent<RunningAnimationScript>().StopAnimation();
			playerGameObject.GetComponent<StandingAnimationScript>().StopAnimation();
			playerGameObject.GetComponent<VictoryAnimationScript>().StopAnimation();
			playerGameObject.GetComponent<DeathAnimationScript>().PlayAnimation();
		} else {
			playerGameObject.GetComponent<RunningAnimationScript>().StopAnimation();
			playerGameObject.GetComponent<StandingAnimationScript>().PlayAnimation();
			playerGameObject.GetComponent<VictoryAnimationScript>().StopAnimation();
			playerGameObject.GetComponent<DeathAnimationScript>().StopAnimation();
		}
	}

	private void Move() {
		Vector3 directionToMove = new Vector3(0.0f, 0.0f, -1.0f);
		directionToMove.Normalize();

		//Move the main Ground.
		mainGround.transform.position += ((directionToMove * movementSpeed) * Time.deltaTime);

		//Move the close background
		backgroundClose.transform.position += ((directionToMove * (movementSpeed / 2)) * Time.deltaTime);

		//Move the mid background.
		backgroundMid.transform.position += ((directionToMove * (movementSpeed / 4)) * Time.deltaTime);

		//Move the far background.
		backgroundFar.transform.position += ((directionToMove * (movementSpeed / 8)) * Time.deltaTime);
	}
	#endregion

	#region Public Access Functions (Getters and Setters).

	public float GetMovingSpeed() {
		return movementSpeed;
	}

	public static void SetIsMoving(bool moveState) {
		isMoving = moveState;
	}

	public static bool GetIsMoving() {
		return isMoving;
	}
	#endregion
}
