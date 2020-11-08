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
    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        agent.SetDestination(player.position);
    }

    public void TakeDamage(double Damage)
    {
        health -= Damage;

        if (health <= 0)
        {
            gm.ScoreUp();
            Destroy(gameObject);
        }

        healthStatus.text = health.ToString();
    }
}
