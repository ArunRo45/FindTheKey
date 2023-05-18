using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{

    //find which collider that we pass through
    //teleport the player to the to opposite collider wall's spawn position
    public bool isLeftCollider = false;
    public Transform l_spawnPosition;
    public Transform r_spwanPosition;



    private void OnTriggerEnter2D(Collider2D other)
    {
         if(other.tag == HelperScript.PLAYER_TAG) 
         {
            if(isLeftCollider)
                TelePort(other.gameObject,r_spwanPosition);
            if (!isLeftCollider)
                TelePort(other.gameObject, l_spawnPosition);
         }

    }


    private void TelePort(GameObject player,Transform spwanPoint)
    {
        //resetposition
        player.transform.position = spwanPoint.position;
    }
}
