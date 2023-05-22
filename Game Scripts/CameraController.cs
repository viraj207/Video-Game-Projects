using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]private Transform player;


    private void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
            //Setting the Camer to follow the player
            //Done in update method as called every frame, so camer is contantly following player
    }
}
