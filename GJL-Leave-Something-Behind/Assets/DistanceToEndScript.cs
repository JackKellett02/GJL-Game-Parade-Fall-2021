////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Filename:       DistanceToEndScript.cs
/// Author:         Jack Kellett
/// Date Created:   13/02/2022
/// Brief:          Calculates how far the player is from the start and displays that on a slider to the player.
//////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceToEndScript : MonoBehaviour {
	#region Variable to assign via the unity inspector (SerializeFields).
	[SerializeField]
	private Transform playerTransform = null;

	[SerializeField]
	private Transform startPosTransform = null;

	[SerializeField]
	private Transform endPosTransform = null;
	#endregion

	#region Private Variables.
	private float playerDistanceToEnd = 0.0f;
	private float distanceToEnd = 0.0f;

	private Slider distanceSlider = null;
	#endregion

	#region Private Functions.
	// Start is called before the first frame update
	void Start() {
		//Get the distance slider.
		distanceSlider = gameObject.GetComponent<Slider>();

		//Calculate the distance the player has to travel.
		distanceToEnd = (endPosTransform.position - startPosTransform.position).magnitude;

		//Update the max distance of the slider to the calculated value and update the slider to 0.
		distanceSlider.maxValue = distanceToEnd;
		distanceSlider.minValue = 0.0f;
		distanceSlider.value = 0.0f;
	}

	// Update is called once per frame
	void Update() {
		CalculatePlayerDistance();
		UpdateSlider();
	}

	private void CalculatePlayerDistance() {
		playerDistanceToEnd = (endPosTransform.position - playerTransform.position).magnitude;
	}

	private void UpdateSlider() {
		distanceSlider.value = distanceToEnd - playerDistanceToEnd;
	}
	#endregion

	#region Public Access Functions (Getters and Setters).

	#endregion
}
