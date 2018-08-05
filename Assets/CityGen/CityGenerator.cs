using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityGenerator : MonoBehaviour
{

    public int gridSize;
    public float gridGap;

    int style;

    // Use this for initialization
    void Start()
    {

        GameObject[] pieces = Resources.LoadAll<GameObject>("Prefabs/Blocks");

        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                style = Random.Range(0, pieces.Length);
                Instantiate(pieces[style], new Vector3(i * gridGap, 0, j * gridGap), transform.rotation, transform).name = "Style: " + style;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
