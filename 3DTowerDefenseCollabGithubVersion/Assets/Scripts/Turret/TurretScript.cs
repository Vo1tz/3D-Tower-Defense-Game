using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurretScript : MonoBehaviour
{
	private Transform target;
	private Enemy targetEnemy;

	[Header("Transform")]
	public Transform customPivot;
	public Transform partToRotate;

	[Header("Variables")]
	public float range = 15f;
	public Transform firePoint;
	public float turnSpeed = 10f;
	public string enemyTag = "Enemy";

	[Header("Shooting (Bullets)")]
	public float fireRate = 1f;
	private float fireCountdown = 0f;
	[SerializeField]
	public static float turretDamage;
	[SerializeField]
	public float DamagePerBullet;

	public GameObject bullet;

	public AudioClip[] BulletShootingNoises;

	[Header("Shooting (Fire)")]
	public LineRenderer linerendfire;
	public ParticleSystem fireFX;
	[SerializeField]
	public float FireDamageOverTime;

	public AudioClip[] FireShootingNoises;

	[Header("Shooting (Lightning)")]
	public LineRenderer linerendlightning;
	public ParticleSystem lightningFX;
	public float LightningDamageOverTime;

	public AudioClip[] LightningShootingNoises;

	[Header("TurretID")]
	public int ID;
	
	void Start()
    {
		InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

	void UpdateTarget()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
			float distanceToEnemy = Vector3.Distance(customPivot.transform.position, enemy.transform.position);
			if (distanceToEnemy < shortestDistance)
            {
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
            }
        }

		if (nearestEnemy != null && shortestDistance <= range)
        {
			target = nearestEnemy.transform;
			targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
			target = null;
        }
    }

	void Update()
    {
		if (target == null)
        {
			if (ID == 2)
			{
				if (linerendfire.enabled)
				{
					linerendfire.enabled = false;
					fireFX.Stop();
				}
			}

			if (ID == 3)
            {
				if (linerendlightning.enabled)
                {
					linerendlightning.enabled = false;
					lightningFX.Stop();
				}
            }

			return;
        }
			
		LockOnTarget();

		if (ID == 1)
        {
		    turretDamage = 30f;

			if (fireCountdown <= 0f)
			{
				Shoot();
				fireCountdown = 1f / fireRate;
			}
		}
		if (ID == 2)
		{ 
			ShootFire();
		}
		if (ID == 3)
		{
		    ShootLightning();
		}
		if (ID == 4)
        {
			turretDamage = 5f;

			if (fireCountdown <= 0f)
			{
				Shoot();
				fireCountdown = 1f / fireRate;
			}
        }
        if (ID == 5)
        {
            turretDamage = 50f;

            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }
        }

        fireCountdown -= Time.deltaTime;

	}

	void LockOnTarget()
    {
		Vector3 dir = target.position - partToRotate.position;
		Quaternion lookRotation = Quaternion.LookRotation(dir);
		Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
		partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
	}

	public void Shoot()
	{
		GameObject bulletg = (GameObject)Instantiate(bullet, firePoint.position, firePoint.rotation);
		BulletScript bulletscript = bulletg.GetComponent<BulletScript>();

		if (bullet != null)
		{
			bulletscript.Config(target);
		}

		AudioManager.Instance.PlayRandomAudio(BulletShootingNoises);
	}

	public void ShootFire()
    {
		targetEnemy.TakeDamage(FireDamageOverTime * Time.deltaTime);

		if (!linerendfire.enabled)
		{
			linerendfire.enabled = true;
			fireFX.Play();
		}

		linerendfire.SetPosition(0, firePoint.position);
		linerendfire.SetPosition(1, target.position);
	}

	public void ShootLightning()
	{
		targetEnemy.TakeDamage(LightningDamageOverTime * Time.deltaTime);

		if (!linerendlightning.enabled)
		{
			linerendlightning.enabled = true;
			lightningFX.Play();
		}

		linerendlightning.SetPosition(0, firePoint.position);
		linerendlightning.SetPosition(1, target.position);
	}

	void OnDrawGizmosSelected()
    {
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(customPivot.transform.position, range);
    } 
}

