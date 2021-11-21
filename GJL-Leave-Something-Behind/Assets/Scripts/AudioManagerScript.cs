//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Filename:      AudioManagerScript.cs
/// Author:        Jack Kellett
/// Date Created:  21/11/2021
/// Brief:         To store and give any other script the ability to play sounds.
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour {
	#region Variables to assign via the unity inspector (SerializeFields).
	[SerializeField]
	private GameObject backgroundMusic = null;

	[SerializeField]
	private GameObject powerupSound = null;

	[SerializeField]
	private GameObject playerHitSound = null;

	[SerializeField]
	private GameObject arrowSwooshSound = null;
	#endregion

	#region Private Variable Declarations.

	#endregion

	#region Private Functions.
	// Start is called before the first frame update
	void Start() {
		PlayBackgroundMusic();
	}

	// Update is called once per frame
	void Update() {

	}
	#endregion

	#region Public Access Functions (Getters and Setters).
	public void PlayPowerupSound() {
		powerupSound.SetActive(false);
		powerupSound.SetActive(true);
	}

	public void PlayBackgroundMusic() {
		backgroundMusic.SetActive(false);
		backgroundMusic.SetActive(true);
	}

	public void PlayPlayerHitSound() {
		playerHitSound.SetActive(false);
		playerHitSound.SetActive(true);
	}

	public void PlayArrowSwooshSound() {
		arrowSwooshSound.SetActive(false);
		arrowSwooshSound.SetActive(true);
	}
	#endregion
}
