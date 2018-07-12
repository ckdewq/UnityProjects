using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]

public class Enemy : Charater
{

    UnityEngine.AI.NavMeshAgent pathfinder;
    Transform target;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        pathfinder = GetComponent<UnityEngine.AI.NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

        StartCoroutine(UpdatePath());
    }
	
	// Update is called once per frame
	void Update () {
        pathfinder.SetDestination(target.position);
	}

    IEnumerator UpdatePath()
    {
        float refreshRate = 0.5f;

        while(target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x, 0, target.position.z);
            if (!dead)
            {
                pathfinder.SetDestination(targetPosition);
            }
            yield return new WaitForSeconds(refreshRate);
        }
    }
}
