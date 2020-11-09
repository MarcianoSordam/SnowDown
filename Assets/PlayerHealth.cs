using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] double health = 10;
    [SerializeField] TextMeshProUGUI healthText;
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        healthText.text = health.ToString();
    }

    public void TakeDamage(double Damage)
    {
        health -= Damage;

        if (health <= 0)
        {
            //Destroy(gameObject);
            gm.GameOver();
        }
        healthText.text = health.ToString();
    }

}
