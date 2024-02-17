using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGeneration : MonoBehaviour
{
    [SerializeField] int width, height;
    [SerializeField] int minStoneHeight, maxStoneHeight;
    [SerializeField] GameObject dirt, grass, stone;

    void Start()
    {
        Generation();
    }

    // Instantiate tiles 
    private void Generation()
    {
        for (int x = 0; x < width; x++)
        {
            // Generamos aleatoriedad en la altura de cada columna
            int minHeight = height - 1;
            int maxHeight = height + 2;
            height = Random.Range(minHeight, maxHeight);

            // Insertamos grass o dirt dependiendo del valor que surja
            int minStoneSpawnDistance = height - minStoneHeight;
            int maxStoneSpawnDistance = height + maxStoneHeight;
            int totalStoneSpawnDistance = Random.Range(minStoneSpawnDistance, maxStoneSpawnDistance);

            for (int y = 0; y < height; y++)
            {
                if (y < totalStoneSpawnDistance)
                {
                    spawnObject(stone, x, y);
                }
                else
                {
                    spawnObject(dirt, x, y);
                }

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
