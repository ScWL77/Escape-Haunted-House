using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class chaser : MonoBehaviour
{
    public NavMeshAgent ai; // chaser ai
    public Transform player; // the player's transform
    Vector3 dest; // the AI's destination and position

    void Update() //the chaser can chase the player
    {
        dest = player.position; // put the destination of the AI to where the player is at
        ai.destination = dest; // move the destination of the AI to where the player is at
    }
}
