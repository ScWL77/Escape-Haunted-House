using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class summon : MonoBehaviour
{
    public GameObject chaser, block1, block2, block3; // the chaser object, blocks that will be enabled (1&2), blocks that will be disabled (3)
    public Collider collision; // the trigger's collider
    public bool blocks; //if true the blocks will be enabled or disabled

    void OnTriggerEnter(Collider other) // when the player enters the trigger, the chaser will spawn, 2 of the blocks will be enabled and one will be disabled if blocks = true
    {
        if (other.CompareTag("Player"))
        {
            chaser.SetActive(true);
            if (blocks == true)
            {
                block1.SetActive(true);
                block2.SetActive(true);
                block3.SetActive(false);
            }
            collision.enabled = false;
        }
    }
}
