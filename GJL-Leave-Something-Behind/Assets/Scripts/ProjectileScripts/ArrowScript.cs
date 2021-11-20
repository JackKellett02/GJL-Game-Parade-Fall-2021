///////////////////////////////////////////////////////////////////////////////////////////
/// Filename:       ArrowScript.cs
/// Author:         Jack Kellett
/// Date Created:   20/11/2021
/// Brief:          To check when an arrow as hit a player and then damage them by result.
///////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class ArrowScript : MonoBehaviour {
	#region Variables to assign via the unity inspector (SerializeFields).
	[SerializeField]
	private GameObject arrowSpriteObject = null;

	[SerializeField]
	private int damageValue = 10;
	#endregion

	#region Private Variable Declarations.

	private bool firstFrame = true;
	private Rigidbody arrowRigidbody;
	private Vector3 velocity = Vector3.zero;
	#endregion

	#region Private Functions.

	void Start() {
	}

	void Update() {
		if (firstFrame) {
			firstFrame = false;
			arrowRigidbody = gameObject.GetComponent<Rigidbody>();
		}
		PointArrowInCorrectDirection();
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			other.gameObject.GetComponent<HeathScript>().DamageByInt(damageValue);
			gameObject.SetActive(false);
		}
	}

	private Vector3 CalculateDirectionVector() {
		Vector3 directionVectorTemp = arrowRigidbody.velocity;
		if (directionVectorTemp == Vector3.zero) {
			return Vector3.forward;
		} else {
			directionVectorTemp.Normalize();
			return directionVectorTemp;
		}
	}

	private void PointArrowInCorrectDirection() {
		Vector3 direction = CalculateDirectionVector();
		Vector2 directionVector2 = new Vector2(direction.z, direction.y);
		float angle = 0.0f;
		//if (directionVector2.y > 0.0f && directionVector2.x > 0.0f) {
		//	angle = Mathf.Sin(directionVector2.y / 1.0f);
		//} else if (directionVector2.y < 0.0f && directionVector2.x > 0.0f) {
		//	angle = Mathf.Cos(directionVector2.x / 1.0f);
		//} else if (directionVector2.y > 0.0f && directionVector2.x < 0.0f) {
		//	angle = Mathf.Sin(directionVector2.y / 1.0f);
		//}
		angle = Mathf.Sin(directionVector2.y / 1.0f);
		angle = angle * Mathf.Rad2Deg;
		Vector3 arrowAngles = arrowSpriteObject.transform.rotation.eulerAngles;
		arrowAngles.z = angle;
		Debug.Log(arrowAngles);
		arrowSpriteObject.transform.rotation = Quaternion.Euler(arrowAngles);
	}

	#endregion

	#region Public Access Functions (Getters and Setters).

	#endregion
}
