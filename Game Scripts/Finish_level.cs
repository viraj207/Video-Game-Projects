using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish_level : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource finishSound;
    private bool levelComplete = false; //Boolean to check if player has completed the level
    private void Start()
    {
        finishSound = GetComponent<AudioSource>();


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Checking if the finish object has collided with the player
        if (collision.gameObject.name == "Player" && ! levelComplete)
        {
            finishSound.Play();
            levelComplete = true;
            Invoke("CompleteLevel", 2f); //If the player has completed the level, then load the next level by calling the command for it
            
         //   CompleteLevel();
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // loads the next scene in the scene array.

    }

}
