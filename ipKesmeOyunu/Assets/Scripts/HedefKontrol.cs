using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HedefKontrol : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("1");
        if(collision.tag == "kurabiye") {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }

    }

}
