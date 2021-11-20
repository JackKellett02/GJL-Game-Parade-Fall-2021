///////////////////////////////////////////////////////////////////////////////////////
/// Filename:         DodgeScript.cs
/// Author:           Jack Kellett
/// Date Created:     16/11/2021
/// Brief:            To allow the user to move left/right and up/down in a set square.
///////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeScript : MonoBehaviour {
	#region Variables to assign via the unity inspector (SerializeFields).
	[SerializeField]
	private Transform centerOfBounds = null;

	[SerializeField]
	private Vector2 boundsXZ = new Vector2(5.0f, 5.0f);

	[SerializeField]
	private float dodgeSpeed = 1.0f;
	#endregion

	#region Private Variable Declarations.
	//Player Bounds variables.
	private bool atLeftEdge = false;
	private bool atRightEdge = false;
	private bool atFrontEdge = false;
	private bool atBackEdge = false;
	private float leftBound = 0.0f;
	private float rightBound = 0.0f;
	private float backBound = 0.0f;
	private float frontBound = 0.0f;

	//Static Bound Variable for retrieving from other classes.
	private static Vector4 bounds = new Vector4();

	//Movement Variables.
	private Vector2 xAxisSpeed = new Vector2();
	private Vector2 zAxisSpeed = new Vector2();
	#endregion

	#region Private Functions.
	// Start is called before the first frame update
	void Start() {
		//Move player to center of bounds.
		gameObject.transform.position = centerOfBounds.position;

		//Set up bounds in XZ directions.
		leftBound = centerOfBounds.position.x - (boundsXZ.x / 2);
		rightBound = centerOfBounds.position.x + (boundsXZ.x / 2);
		backBound = centerOfBounds.position.z - (boundsXZ.y / 2);
		frontBound = centerOfBounds.position.z + (boundsXZ.y / 2);
		bounds = new Vector4(leftBound, rightBound, backBound, frontBound);

		//Set up movement variables.
		xAxisSpeed = new Vector2(-dodgeSpeed, dodgeSpeed);
		zAxisSpeed = new Vector2(-dodgeSpeed, dodgeSpeed);
	}

	// Update is called once per frame
	void Update() {
		CheckPlayerBounds();
		PlayerMovement();
	}

	/// <summary>
	/// Function to check whether or not the player is within the designated dodge square and changes how they can move accordingly.
	/// </summary>
	private void CheckPlayerBounds() {
		//Check X Axis.
		if (gameObject.transform.position.x <= leftBound) {
			xAxisSpeed = new Vector2(0.0f, dodgeSpeed);
		} else if (gameObject.transform.position.x >= rightBound) {
			xAxisSpeed = new Vector2(-dodgeSpeed, 0.0f);
		} else {
			xAxisSpeed = new Vector2(-dodgeSpeed, dodgeSpeed);
		}

		//Check Z Axis.
		if (gameObject.transform.position.z <= backBound) {
			zAxisSpeed = new Vector2(0.0f, dodgeSpeed);
		} else if (gameObject.transform.position.z >= frontBound) {
			zAxisSpeed = new Vector2(-dodgeSpeed, 0.0f);
		} else {
			zAxisSpeed = new Vector2(-dodgeSpeed, dodgeSpeed);
		}
	}

	private void PlayerMovement() {
		Vector3 movement = Vector3.zero;
		//X Axis Movement.
		//if (Input.GetKey(KeyCode.W)) {
		//	movement.x += xAxisSpeed.x * Time.deltaTime;
		//}
		//if (Input.GetKey(KeyCode.S)) {
		//	movement.x += xAxisSpeed.y * Time.deltaTime;
		//}
		//Z Axis Movement.
		if (Input.GetKey(KeyCode.A)) {
			movement.z += zAxisSpeed.x * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.D)) {
			movement.z += zAxisSpeed.y * Time.deltaTime;
		}

		//Move the player.
		gameObject.transform.Translate(movement);
	}
	#endregion

	#region Public Access Functions (Getters and Setters).
	/// <summary>
	/// X component = left bound.
	/// Y component = right bound.
	/// Z component = back bound.
	/// W component = front bound.
	/// </summary>
	/// <returns></returns>
	public static Vector4 GetSquareBounds() {
		return bounds;
	}
	#endregion
}