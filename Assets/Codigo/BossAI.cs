using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAI : MonoBehaviour
{

    public Transform followTransform;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        followTransform = GameObject.FindGameObjectWithTag("Player").transform;

        agent.SetDestination(followTransform.position);
    }
}
