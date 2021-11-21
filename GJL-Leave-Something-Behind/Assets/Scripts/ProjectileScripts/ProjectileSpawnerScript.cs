/////////////////////////////////////////////////////////////////////////////////////
/// Filename:         ProjectileSpawnerScript.cs
/// Author:           JackKellett
/// Date Created:     20/11/2021
/// Brief:            To spawn a projectile and shoot it at a target area.
/////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawnerScript : MonoBehaviour {
	#region Variables to assign via the unity inspector (SerializeFields).
	[SerializeField]
	private GameObject projectilePrefab = null;

	[SerializeField]
	[Range(10, 100)]
	int projectilePool = 10;

	[SerializeField]
	private float timeToReachTarget = 2.0f;

	[SerializeField]
	private float spawnRate = 2.0f;
	#endregion

	#region Private Variable Declarations.
	private Vector4 bounds;
	private Vector3 targetPosition = Vector3.zero;

	private AudioManagerScript audioManager = null;

	//Object Pool.
	private Queue<GameObject> projectileQueue = new Queue<GameObject>();

	//Boolean to tell when a new projectile can spawn.
	private bool canFire = true;

	//Boolean to tell when it's the first frame.
	private bool firstFrame = true;
	#endregion

	#region Private Functions.
	// Start is called before the first frame update
	void Start() {
		//Get the audio manager.
		audioManager = GameObject.FindGameObjectsWithTag("AudioManager")[0].GetComponent<AudioManagerScript>();

		//Populate the projectile pool.
		for (int i = 0; i < projectilePool; i++) {
			GameObject tempProjectile = Instantiate(projectilePrefab);
			tempProjectile.SetActive(false);
			projectileQueue.Enqueue(tempProjectile);
		}
	}

	// Update is called once per frame
	void Update() {
		//Anything we only want to do in the first frame to ensure it's run after the start function is run.
		if (firstFrame) {
			firstFrame = false;
			bounds = DodgeScript.GetSquareBounds();
			RandomiseTargetPosition();
		}

		//Fire projectile Updates.
		if (canFire && MovementScript.GetIsMoving()) {
			canFire = false;
			FireProjectile(targetPosition);
			StartCoroutine("ProjectileCooldown");
		}
	}

	private void RandomiseTargetPosition() {
		Vector3 tempTarget = new Vector3(Random.Range(bounds.x, bounds.y), gameObject.transform.position.y, Random.Range(bounds.z, bounds.w));
		targetPosition = tempTarget;
	}

	private IEnumerator ProjectileCooldown() {
		yield return new WaitForSeconds(1 / spawnRate);
		RandomiseTargetPosition();
		canFire = true;
	}

	private Vector3 CalculateVelocityVector(Vector3 target) {
		//Initialise velocity vector.
		Vector3 velocityVector3 = Vector3.zero;

		//Z axisVelocity.
		//Get the distance to the target on the z axis.
		float distance = target.z - gameObject.transform.position.z;
		//Calculate z velocity.
		float uZ = distance / timeToReachTarget;

		//Y axis velocity.
		float uY = 0.0f - ((-9.81f) * (timeToReachTarget / 2.0f));

		//Update velocity vector.
		velocityVector3.y = uY;
		velocityVector3.z = uZ;

		return velocityVector3;
	}

	private void FireProjectile(Vector3 target) {
		Vector3 velocity = CalculateVelocityVector(target);
		//Check if velocity is valid.
		if (velocity == Vector3.zero) {
			Debug.Log("ERROR::Velocity is zero!!");
		} else {
			audioManager.PlayArrowSwooshSound();
			SpawnProjectile(gameObject.transform.position, gameObject.transform.rotation, velocity);
		}
	}

	/// <summary>
	/// Takes the next projectile in the object pool and puts it at a set position and rotation.
	/// </summary>
	/// <param name="pos"></param>
	/// <param name="rotation"></param>
	private void SpawnProjectile(Vector3 pos, Quaternion rotation, Vector3 velocity) {
		//Get the next projectile in the queue.
		GameObject tempProjectile = projectileQueue.Dequeue();

		//Set it's position and rotation and velocity.
		tempProjectile.transform.position = pos;
		tempProjectile.transform.rotation = rotation;
		tempProjectile.GetComponent<Rigidbody>().velocity = velocity;

		//Activate it.
		tempProjectile.SetActive(true);

		//Add it to the end of the queue.
		projectileQueue.Enqueue(tempProjectile);
	}
	#endregion

	#region Public Access Functions (Getters and Setters).

	#endregion
}
