using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    [SerializeField] float health = 50;
    [SerializeField] GameObject[] segments;
    int count = 0;
    float starthealth;

    void Start()
    {
        starthealth = health;
    }

    public void BuildUp()
    {
        count++;
        count = Mathf.Clamp(count,0,segments.Length);
        segments[count].SetActive(true);
        health = starthealth;
    }

    public void BreakDown()
    {
        segments[count].SetActive(false);
        count--;
        if (count < 0)
        {
            Destroy(gameObject);
        }
    }

    void healthDown(float dmg)
    {
        health -= dmg;

        if (health <= 0)
        {
            BreakDown();
        }
    }
}
