using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ArrowController : MonoBehaviour
{
    // Start is called before the first frame update
    
    private Rigidbody2D myBody;
    [SerializeField] GameObject effect;
    [SerializeField] Text scoreValueText;
   
    void Start() {
        scoreValueText = GameObject.Find("SkorValue").GetComponent<Text>();
        myBody = GetComponent<Rigidbody2D>();    
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy"){
            
            Instantiate(effect,other.gameObject.transform.position,Quaternion.identity);

             int currentScor = int.Parse(scoreValueText.text);
            currentScor += 100;
            scoreValueText.text = currentScor.ToString();

            Destroy(gameObject);
            Destroy(other.gameObject);

        }else if(other.gameObject.CompareTag("Coin")){

        }else if(other.gameObject.tag != "Player"){
            myBody.constraints = RigidbodyConstraints2D.FreezePosition;
        }
    }


    private void OnBecameInvisible() {
        Destroy(gameObject);
    }

}
