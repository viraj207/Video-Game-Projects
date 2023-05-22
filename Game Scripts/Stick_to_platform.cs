using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick_to_platform : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Checking if the object collides with the object name "player, which is the playable character
        //if player has made contact with plaform, then setting the player to move with the platform by setting it as a child of the game object.
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(transform);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
