using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildWall : MonoBehaviour
{
    [SerializeField] WallManager wallManager;

    public void BuildLayer()
    {
        wallManager.BuildUp();
    }

}
