using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGeneration : MonoBehaviour
{
    [SerializeField] int width, height;
    [SerializeField] GameObject dirt, grass;

    void Start()
    {
        Generation();
    }

    // Instantiate tiles 
    private void Generation()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                spawnObject(dirt, x, y);
            }
            spawnObject(grass, x, height);
        }
    }

    void spawnObject(GameObject obj, int x, int y)
    {
        obj = Instantiate(obj, new Vector2(x, y), Quaternion.identity);
        obj.transform.parent = this.transform;
    }
}
