using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobLocation : MonoBehaviour
{

    public enum Job
    {
        NONE,
        Rock,
        Wood,
        Food,
        Research
    }

    public Job job;
    public int rate;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
