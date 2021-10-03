using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalrusEnemy : MonoBehaviour
{
    public GameObject[] Goals;
    public float Speed;
    private Rigidbody rigidbody;
    private int currentGoal;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.LookAt(Goals[currentGoal].transform);
        Vector3 velocity = transform.forward;
        velocity.y = 0;
        velocity = velocity.normalized * Speed;
        velocity.y = rigidbody.velocity.y;
        rigidbody.velocity = velocity;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == Goals[currentGoal].name)
        {
            currentGoal++;
            currentGoal %= Goals.Length;
        }
    }
}
