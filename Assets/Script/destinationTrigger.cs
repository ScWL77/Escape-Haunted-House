using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destinationTrigger : MonoBehaviour
{
    public Collider collision; // the destination's collider

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("monster"))
        {
            StartCoroutine(reEnable());
            collision.enabled = false;
        }
    }
    IEnumerator reEnable() //after a couple of seconds, the destination's trigger will re-enable, so that enemy doesnt constantly triggers the destination trigger
    {
        yield return new WaitForSeconds(6.0f);
        collision.enabled = true;
    }
}
