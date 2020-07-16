using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerControl : MonoBehaviour
{


    [SerializeField] GameObject player;


    private void OnTriggerEnter2D(Collider2D other) {

        player.GetComponent<PlayerController>().onGround = true;

    }

    private void OnTriggerExit2D(Collider2D other) {

        player.GetComponent<PlayerController>().onGround = false;

    }

}
