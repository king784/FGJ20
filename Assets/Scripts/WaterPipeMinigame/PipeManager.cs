using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PipeManager : MonoBehaviour
{
    [SerializeField]
    int width;
    [SerializeField]
    int height;
    [SerializeField]
    GameObject gridObj;
    [SerializeField]
    GridLayoutGroup grid;

    [ContextMenu("Test")]
    void SpawnGrid()
    {
        grid.constraintCount = height;
        for(int i = 0; i < width; i++)
        {
            for(int j = 0; j < height; j++)
            {
                Instantiate(gridObj, grid.transform);
            }
        }
        Vector2 topLeft;
    }
}
