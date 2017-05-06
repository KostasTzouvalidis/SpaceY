using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootingType : MonoBehaviour {

	private int numberOfProjectiles;
	private GameObject projectile;

	protected abstract void UpgradeShooting ();
	protected abstract void DowngradeShooting ();
	protected abstract void Shoot ();
}
