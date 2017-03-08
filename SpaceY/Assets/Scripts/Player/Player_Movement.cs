using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {

	private Player_Master playerMaster;
	private Rigidbody myRig;
	private float movementVelocitySqr;
	[SerializeField]
	private float movementVelocity = 10;
	[SerializeField]
	private float tiltByMovement = 2;

	void OnEnable() {
		InitializeReferences ();
		playerMaster.EventInput += PlayerMove;
	}
	
	void OnDisable() {
		playerMaster.EventInput -= PlayerMove;
	}

	private void FixedUpdate() {
		if (myRig.velocity.x != 0)
			myRig.rotation = Quaternion.Euler(0.0f, 0.0f, myRig.velocity.x * -tiltByMovement);
	}

	private void PlayerMove() {
		if (myRig.velocity.x < 0)
			myRig.velocity = Vector3.right * movementVelocity;
		else if (myRig.velocity.x > 0)
			myRig.velocity = Vector3.left * movementVelocity;
		else
			myRig.velocity = Vector3.right * movementVelocity;
	}

	private void InitializeReferences() {
		playerMaster = GetComponent<Player_Master> ();
		myRig = GetComponent<Rigidbody> ();
		movementVelocitySqr = movementVelocity * movementVelocitySqr;
	}
}
