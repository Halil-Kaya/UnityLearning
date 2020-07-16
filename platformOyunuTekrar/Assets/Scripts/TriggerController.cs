using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject player;



    //yere temas ettiginde tetiklenen fonksiyon
    private void OnTriggerEnter2D(Collider2D other) {
        player.GetComponent<Animator>().SetTrigger("yereDustu");
        player.GetComponent<PlayerController>().yereTemasEttiMi = true;

    }

    //temsatan ciktiginda tetiklenen fonksiyon
    private void OnTriggerExit2D(Collider2D other) {
        player.GetComponent<PlayerController>().yereTemasEttiMi = false;

    }

}
