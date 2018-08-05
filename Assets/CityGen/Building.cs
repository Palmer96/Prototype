using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{

    public int size;
    public int style;

    // Use this for initialization
    void Start()
    {

        //  SpawnSingle();
        SpawnFloors();
    }

    // U




    void SpawnFloors()
    {
        GameObject[] grounds = null;
        GameObject[] floors = null;
        GameObject[] roofs = null;
        switch (size)
        {
            case 1:
                grounds = Resources.LoadAll<GameObject>("Prefabs/Pieces/Ground Small");
                floors = Resources.LoadAll<GameObject>("Prefabs/Pieces/Floor Small");
                roofs = Resources.LoadAll<GameObject>("Prefabs/Pieces/Roof Small");
                break;
            case 2:
                grounds = Resources.LoadAll<GameObject>("Prefabs/Pieces/Ground Medium");
                floors = Resources.LoadAll<GameObject>("Prefabs/Pieces/Floor Medium");
                roofs = Resources.LoadAll<GameObject>("Prefabs/Pieces/Roof Medium");
                break;
            case 3:
                grounds = Resources.LoadAll<GameObject>("Prefabs/Pieces/Ground Large");
                floors = Resources.LoadAll<GameObject>("Prefabs/Pieces/Floor Large");
                roofs = Resources.LoadAll<GameObject>("Prefabs/Pieces/Roof Large");
                break;
        }
        style = Random.Range(0, grounds.Length);

        int floorCount = Random.Range(1, 8);

        for (int i = 0; i < floorCount; i++)
        {
            if (i == 0)
                Instantiate(grounds[style], transform.position + Vector3.up * i, transform.rotation, transform.parent).name = "Size: " + size + " Style: " + style;
            else if (i >= floorCount - 1)
                Instantiate(roofs[style], transform.position + Vector3.up * i, transform.rotation, transform.parent).name = "Size: " + size + " Style: " + style;
            else
                Instantiate(floors[style], transform.position + Vector3.up * i, transform.rotation, transform.parent).name = "Size: " + size + " Style: " + style;
        }

        Destroy(gameObject);
    }



    void SpawnSingle()
    {
        GameObject[] pieces = null;
        switch (size)
        {
            case 1:
                pieces = Resources.LoadAll<GameObject>("Prefabs/Small");
                break;
            case 2:
                pieces = Resources.LoadAll<GameObject>("Prefabs/Medium");
                break;
            case 3:
                pieces = Resources.LoadAll<GameObject>("Prefabs/Large");
                break;
        }
        style = Random.Range(0, pieces.Length);

        Instantiate(pieces[style], transform.position, transform.rotation, transform.parent).name = "Size: " + size + " Style: " + style;
        Destroy(gameObject);
    }
}
