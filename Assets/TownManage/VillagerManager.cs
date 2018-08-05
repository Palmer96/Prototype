using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VillagerManager : MonoBehaviour
{

    GameObject[] villagers;

    public Slider[] sliders;


    public int resourcesAvaliable = 100;
    public float resousecesUsed;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FindJobs()
    {
        villagers = GameObject.FindGameObjectsWithTag("Villager");


        Villager currentVillager;

        for (int i = 0; i < villagers.Length; i++)
        {
            currentVillager = villagers[i].GetComponent<Villager>();

            if (currentVillager != null)
            {
                GiveTask(currentVillager);
            }
        }
    }


    void GiveTask(Villager villager)
    {

    }


    public void ChangeValue(int resource)
    {
        resousecesUsed = 0;
        for (int i = 0; i < sliders.Length; i++)
        {
            resousecesUsed += sliders[i].value;
        }

        if (resousecesUsed >= resourcesAvaliable)
        {
            for (int i = 0; i < sliders.Length; i++)
            {
                sliders[i].value = Mathf.Min(sliders[i].value, resourcesAvaliable - resousecesUsed);
            }
        }
    }
}
