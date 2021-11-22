using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningAnimationScript : MonoBehaviour {
	#region Variables to assign via the unity inspector (SerializeFields).
	[SerializeField]
	private GameObject spriteOne = null;

	[SerializeField]
	private GameObject spriteTwo = null;

	[SerializeField]
	private GameObject spriteThree = null;

	[SerializeField]
	private GameObject spriteFour = null;

	[SerializeField]
	private float timeBetweenFrames = 0.25f;

	[SerializeField]
	private int numberOfFrames = 4;
	#endregion

	#region Private Variable Declarations.

	private bool playingAnimation = false;
	private bool increase = true;
	private float timer = 0.0f;
	private int index = 0;
	#endregion

	#region Private Functions.
	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {
		if (playingAnimation) {
			//Timer and index.
			timer += Time.deltaTime;
			if (timer >= timeBetweenFrames) {
				timer = 0.0f;
				if (increase)
				{
					if (index == numberOfFrames - 1) {
						increase = false;
					} else {
						index++;
					}
				}
				else
				{
					if (index == 0) {
						increase = true;
					} else {
						index--;
					}
				}

			}

			//Frame switching.
			switch (index) {
				case 0: {
						spriteOne.SetActive(true);
						spriteTwo.SetActive(false);
						spriteThree.SetActive(false);
						spriteFour.SetActive(false);
						break;
					}
				case 1: {
						spriteOne.SetActive(false);
						spriteTwo.SetActive(true);
						spriteThree.SetActive(false);
						spriteFour.SetActive(false);
						break;
					}
				case 2: {
						spriteOne.SetActive(false);
						spriteTwo.SetActive(false);
						spriteThree.SetActive(true);
						spriteFour.SetActive(false);
						break;
					}
				case 3: {
						spriteOne.SetActive(false);
						spriteTwo.SetActive(false);
						spriteThree.SetActive(false);
						spriteFour.SetActive(true);
						break;
					}
				default: {
						break;
					}
			}
		} else {
			spriteOne.SetActive(false);
			spriteTwo.SetActive(false);
			spriteThree.SetActive(false);
			spriteFour.SetActive(false);
		}
	}
	#endregion

	#region Public Access Functions (Getters and Setters).

	public void PlayAnimation() {
		playingAnimation = true;
	}

	public void StopAnimation() {
		playingAnimation = false;
	}
	#endregion
}
