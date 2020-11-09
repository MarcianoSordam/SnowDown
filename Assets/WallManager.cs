using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    [SerializeField] double health = 50;
    [SerializeField] GameObject[] segments;
    [SerializeField] int count = 0;
    double starthealth;

    void Start()
    {
        starthealth = health;
    }

    public void BuildUp()
    {
        count++;
        count = Mathf.Clamp(count, 0, segments.Length - 1);
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
        health = starthealth;
    }

    public void DmgWall(double dmg)
    {
        health -= dmg;

        if (health <= 0)
        {
            BreakDown();
        }
    }
}
