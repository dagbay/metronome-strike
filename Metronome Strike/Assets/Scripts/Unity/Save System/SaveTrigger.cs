using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;


public class SaveTrigger : MonoBehaviour
{
    PlayerMovement PlayerMovement;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerMovement = other.gameObject.GetComponent<PlayerMovement>();
            PlayerMovement.saveTrigger = true;
            
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerMovement = other.gameObject.GetComponent<PlayerMovement>();
            PlayerMovement.saveTrigger = false;
        }
    }

}