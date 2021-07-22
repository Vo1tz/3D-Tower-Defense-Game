using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Enemy : MonoBehaviour 
{
	[Header("WaypointMobility")]
	private Transform target;
    private int wavepointIndex = 0;
    public float speed = 5f;

	public GameObject frontEnd;

    [Header("StatsTracking")]
	public static bool GameOver;
	public static bool GameWon;
	public int Value;

	private int one = 1;

	[Header("Health")]
	public float startHealth = 100;
	public float health;
	public bool isDead = false;

	[Header("ID")]
	public static int ID;

	void Start ()
	{ 
		GameOver = false;
		GameWon = false;

		target = EnemyWaypoints.points[0];
	}

	void Awake ()
    {
		health = startHealth;
    }

	void Update ()
	{
		if (health <= 0 && !isDead)
		{
			Die();
		}

		
		Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

		if (Vector3.Distance(transform.position, target.position) <= 0.4f)
		{
			GetNextWaypoint();
		}
	}

	void GetNextWaypoint ()
	{
		if (wavepointIndex >= EnemyWaypoints.points.Length - 1)
		{
			EnemySpawner.currentEntered += 1;
            Destroy(gameObject);
			return;
		}

		frontEnd.transform.LookAt(target);

		wavepointIndex++;
		target = EnemyWaypoints.points[wavepointIndex];
	}

	public void TakeDamage(float amount)
	{
		health -= amount;

		if (health <= 0 && !isDead)
		{
			Die();
		}
	}

	void Die()
	{
		CurrencyManager.currency += Value;
		MainMenuInteractions.MoneyEarnedCount += Value;
		MainMenuInteractions.EnemiesKilledCount2 += one;
		isDead = true;
		Destroy(gameObject);
	}
}
