using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;


public class SaveTrigger : MonoBehaviour
{
    PlayerController playerController;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerController = other.gameObject.GetComponent<PlayerController>();
            playerController.saveTrigger = true;
            
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerController = other.gameObject.GetComponent<PlayerController>();
            playerController.saveTrigger = false;
        }
    }

}