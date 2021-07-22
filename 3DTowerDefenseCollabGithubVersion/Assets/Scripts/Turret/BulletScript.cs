using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Transform target;

    public float speed = 50f;

    public void Config(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            Hit();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void Hit()
    {
        Enemy enemy = target.GetComponent<Enemy>();
        enemy.TakeDamage(50f);
        Destroy(gameObject);
    }
}
