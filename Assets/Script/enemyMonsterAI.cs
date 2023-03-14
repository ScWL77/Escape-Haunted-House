using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine.AI;
using UnityEngine;
using Random = UnityEngine.Random;


public class enemyMonsterAI : MonoBehaviour
{
    public NavMeshAgent ai; // the monster AI's NavMeshAgent
    public Animator aiAnim; // the AI animator
    int randNum; // determines the AI's next random location
    public Transform playerTrans, aiTrans, randDest1, randDest2, randDest3, randDest4, randDest5, randDest6, randDest7, randDest8;// the player's transform, 8 random destinations the AI can go
    public bool walking, chasing, idle; //determins if AI is patrolling or chasing or idle
    Vector3 dest; // the AI destination
    public float chaseTime; //how long the AI chase the player
    public float idleTime; //how long the AI stays idle

    void Start() //at the start of the scene, walking will equal to true and a random destination will be chosen for the AI to walk to
    {
        walking = true;
        randNum = Random.Range(0, 8);
        aiAnim.SetTrigger("walk");
        if(randNum == 0)
        {
            dest = randDest1.position;
        }
        if (randNum == 1)
        {
            dest = randDest2.position;
        }
        if (randNum == 2)
        {
            dest = randDest3.position;
        }
        if (randNum == 3)
        {
            dest = randDest4.position;
        }
        if (randNum == 4)
        {
            dest = randDest5.position;
        }
        if (randNum == 5)
        {
            dest = randDest6.position;
        }
        if (randNum == 6)
        {
            dest = randDest7.position;
        }
        if (randNum == 7)
        {
            dest = randDest8.position;
        }
    }

    void Update() 
    {
        if (walking == true) //when walking is true, the AI's dest will be equal to dest, which will be equal to one of the random destination
        {
            ai.destination = dest;
            ai.speed = 3;
        }
        if(chasing == true) //when chasing is true, dest will equal to player's position and ai will chase, speed will also be set higher
        {
            dest = playerTrans.position;
            ai.destination = dest;
            ai.speed = 6;
        }
        if(idle == true) //when idle is true, the ai speed will be set to 0
        {
            ai.speed = 0;
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player")) //if the AI detects the player, they will begin chasing them.
                                        //A coroutine starts as well which will chase the player and end after a certain amount of time if they lose sight of player
        {
            chasing = true;
            walking = false;
            idle = false;
            aiAnim.ResetTrigger("idle");
            aiAnim.ResetTrigger("walk");
            aiAnim.SetTrigger("run");
            StopCoroutine("nextDest");
            StopCoroutine("chase");
            StartCoroutine("chase");
        }

        if (other.CompareTag("destination")) //if enemy enters destination's trigger, the enemy will idle and coroutine will start to make them patrol again in a set amount of seconds
        {
            if (chasing == false)
            {
                idle = true;
                walking = false;
                aiAnim.ResetTrigger("walk");
                aiAnim.SetTrigger("idle");
                StartCoroutine("nextDest");
            }
        }
    }

    IEnumerator nextDest() //after a set amount of seconds, the enemy will start walking to a random destination again
    {
        yield return new WaitForSeconds(idleTime);
        idle = false;
        walking = true;
        aiAnim.ResetTrigger("idle");
        aiAnim.SetTrigger("walk");
        randNum = Random.Range(0, 8);
        if (randNum == 0)
        {
            dest = randDest1.position;
        }
        if (randNum == 1)
        {
            dest = randDest2.position;
        }
        if (randNum == 2)
        {
            dest = randDest3.position;
        }
        if (randNum == 3)
        {
            dest = randDest4.position;
        }
        if (randNum == 4)
        {
            dest = randDest5.position;
        }
        if (randNum == 5)
        {
            dest = randDest6.position;
        }
        if (randNum == 6)
        {
            dest = randDest7.position;
        }
        if (randNum == 7)
        {
            dest = randDest8.position;
        }
    }

    IEnumerator chase() //after the amount of seconds set in the chaseTime, the AI will stop chasing and patrol again
    {
        yield return new WaitForSeconds(chaseTime);
        chasing = false;
        walking = true;
        aiAnim.ResetTrigger("idle");
        aiAnim.ResetTrigger("run");
        aiAnim.SetTrigger("walk");
        randNum = Random.Range(0, 8);
        if (randNum == 0)
        {
            dest = randDest1.position;
        }
        if (randNum == 1)
        {
            dest = randDest2.position;
        }
        if (randNum == 2)
        {
            dest = randDest3.position;
        }
        if (randNum == 3)
        {
            dest = randDest4.position;
        }
        if (randNum == 4)
        {
            dest = randDest5.position;
        }
        if (randNum == 5)
        {
            dest = randDest6.position;
        }
        if (randNum == 6)
        {
            dest = randDest7.position;
        }
        if (randNum == 7)
        {
            dest = randDest8.position;
        }
    }

}
