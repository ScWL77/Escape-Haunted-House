using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class randomizeSwitch : MonoBehaviour
{
    public GameObject switch1, switch2, switch3; //things 1-3 the 3 switch that the script will choose from
    int randNum; //the number that will decide which switch will spawn

    void Start()
    {
        randNum = Random.Range(0, 3);
        if (randNum == 0)
        {
            switch1.SetActive(true);
        }
        if (randNum == 1)
        {
            switch2.SetActive(true);
        }
        if (randNum == 2)
        {
            switch3.SetActive(true);
        }
    }
}
