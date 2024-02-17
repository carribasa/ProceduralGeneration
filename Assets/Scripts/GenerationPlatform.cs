using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationPlatform : MonoBehaviour
{
    [SerializeField] int width, height;
    [SerializeField] int minHeight, maxHeight;
    [SerializeField] int repeatNum;
    [SerializeField] int spikeSpawnHeight;
    [SerializeField] GameObject dirt, grass, spike;

    void Start()
    {
        Generation();
    }

    // Instantiate tiles 
    private void Generation()
    {
        int repeatValue = 0;
        for (int x = 0; x < width; x++)
        {
            if (repeatValue == 0)
            {
                height = Random.Range(minHeight, maxHeight);
                GeneratePlatform(x);
                repeatValue = repeatNum - 1;
            }
            else
            {
                GeneratePlatform(x);
                repeatValue--;
            }
        }
    }

    private void GeneratePlatform(int x)
    {
        for (int y = 0; y < height; y++)
        {
            spawnObject(dirt, x, y);
        }

        if (height < spikeSpawnHeight)
        {
            spawnObject(grass, x, height);
            spawnObject(spike, x, height + 1);
        }
        else
        {
            spawnObject(grass, x, height);
        }
    }

    void spawnObject(GameObject obj, int x, int y)
    {
        obj = Instantiate(obj, new Vector2(x, y), Quaternion.identity);
        obj.transform.parent = this.transform;
    }
}
