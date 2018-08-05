using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMenu : MonoBehaviour
{
    public int spawnAmount;
    public Transform parent;
    public GameObject[] slotPrefabs;

    public Vector2 pos;
    public Vector2 offset;
    public int horizontalGridSize;
    public int verticalGridSize;
    public float gridGap;

    public int emptySlot;
    public List<int> list;

    public bool canPlace;
    public int a;
    public int b;
    public int c;

    public bool[] boolList;

    // Use this for initialization
    void Start()
    {
        if (parent == null)
            parent = transform;
        list = new List<int>();
        //   boolList = new bool[horizontalGridSize * verticalGridSize];
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Spawn();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            for (int k = 0; k < spawnAmount; k++)
                Spawn();
        }
    }


    public void Spawn()
    {
        GridSlot slot = Instantiate(slotPrefabs[Random.Range(0, slotPrefabs.Length)], parent).GetComponent<GridSlot>();
        emptySlot = 0;

        for (int j = 0; j < boolList.Length; j++)
        {
            emptySlot = j;
            if (!boolList[emptySlot])
            {
                list.Clear();
                canPlace = true;

                if (slot.toggle11)
                {
                    if (!boolList[emptySlot])
                        list.Add(emptySlot);
                    else
                        continue;
                }
                if (slot.toggle21)
                {
                    a = emptySlot;
                    b = emptySlot + 1;
                    if (((Mathf.CeilToInt((a) / horizontalGridSize) * horizontalGridSize)) ==
                         ((Mathf.CeilToInt((b) / horizontalGridSize) * horizontalGridSize)))
                    {
                        if (!boolList[b])
                            list.Add(b);
                        else
                            continue;
                    }
                    else
                        continue;
                }
                if (slot.toggle31)
                {
                    a = emptySlot;
                    b = emptySlot + 2;
                    if (((Mathf.CeilToInt((a) / horizontalGridSize) * horizontalGridSize)) ==
                         ((Mathf.CeilToInt((b) / horizontalGridSize) * horizontalGridSize)))
                    {
                        if (!boolList[b])
                            list.Add(b);
                        else
                            continue;
                    }
                    else
                        continue;
                }
                if (slot.toggle12)
                {
                    a = emptySlot;
                    b = emptySlot + (1 * horizontalGridSize);
                    Debug.Log("12");
                    if (!boolList[b])
                        list.Add(b);
                    else
                        continue;
                }
                if (slot.toggle22)
                {
                    a = emptySlot + (1 * horizontalGridSize);
                    b = emptySlot + 1 + (1 * horizontalGridSize);
                    if (((Mathf.CeilToInt((a ) / horizontalGridSize) * horizontalGridSize)) ==
                         ((Mathf.CeilToInt((b) / horizontalGridSize) * horizontalGridSize)))
                    {
                        if (!boolList[b])
                        {
                            list.Add(b);
                        }
                        else
                            continue;
                    }
                    else
                        continue;
                }
                if (slot.toggle32)
                {
                    a = emptySlot + (1 * horizontalGridSize);
                    b = emptySlot + 2 + (1 * horizontalGridSize);
                    if (((Mathf.CeilToInt((a) / horizontalGridSize) * horizontalGridSize)) ==
                         ((Mathf.CeilToInt((b) / horizontalGridSize) * horizontalGridSize)))
                    {
                        if (!boolList[b])
                            list.Add(b);
                        else
                            continue;
                    }
                    else
                        continue;
                }
                if (slot.toggle13)
                {
                    if (!boolList[emptySlot + (2 * horizontalGridSize)])
                        list.Add(emptySlot + (2 * horizontalGridSize));
                    else
                        continue;
                }
                if (slot.toggle23)
                {
                    a = emptySlot + (2 * horizontalGridSize);
                    b = emptySlot + 1 + (2 * horizontalGridSize);
                    if (((Mathf.CeilToInt((a) / horizontalGridSize) * horizontalGridSize)) ==
                         ((Mathf.CeilToInt((b) / horizontalGridSize) * horizontalGridSize)))
                    {
                        if (!boolList[b])
                            list.Add(b);
                        else
                            continue;
                    }
                    else
                        continue;
                }
                if (slot.toggle33)
                {
                    a = emptySlot + (2 * horizontalGridSize);
                    b = emptySlot + 2 + (2 * horizontalGridSize);
                    if (((Mathf.CeilToInt((a) / horizontalGridSize) * horizontalGridSize)) ==
                         ((Mathf.CeilToInt((b) / horizontalGridSize) * horizontalGridSize)))
                    {
                        if (!boolList[b])
                            list.Add(b);
                        else
                            continue;
                    }
                    else
                        continue;
                }


                for (int i = 0; i < list.Count; i++)
                {
                    boolList[list[i]] = true;
                }

                slot.GetComponentInChildren<UnityEngine.UI.Text>().text = list[0].ToString();

                pos.y = (int)(Mathf.Ceil(emptySlot / horizontalGridSize)) * -gridGap;
                pos.x = (int)(emptySlot - ((int)(Mathf.Ceil(emptySlot / horizontalGridSize)) * horizontalGridSize)) * gridGap;

                slot.GetComponent<RectTransform>().localPosition = pos + offset;
                slot.name = slot.name + " " + pos;
                break;
            }
        }
    }
}




//  if (emptySlot + slot.horizontal < horizontalGridSize)
//  {
//      for (int i = 0; i < slot.horizontal; i++)
//      {
//          int num = emptySlot + i;
//          list.Add(num);
//          if (boolList[num])
//              canPlace = false;
//      }
//  }
//  for (int i = 0; i < slot.vertical; i++)
//  {
//      int num = emptySlot + (i * horizontalGridSize);
//      list.Add(num);
//      if (boolList[num])
//          canPlace = false;
//  }