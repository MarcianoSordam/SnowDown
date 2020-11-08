using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class EnemyController : MonoBehaviour
{
    //public Camera cam;
    public NavMeshAgent agent;
    public Transform player;
    public TextMeshPro healthStatus;
    public double health = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        agent.SetDestination(player.position);
    }

    public void TakeDamage(double Damage) {
        health -= Damage;

        if (health <= 0) {
             Destroy(gameObject);
        }

        healthStatus.text = health.ToString();
    }
}
