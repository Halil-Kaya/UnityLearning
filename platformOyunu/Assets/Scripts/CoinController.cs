using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinController : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] Text scoreValueText;
    [SerializeField] float cointRotateSpeed;
    // Update is called once per frame
    void Update()
    {
     transform.Rotate(new Vector3(0f,cointRotateSpeed,0f));   
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            int currentScor = int.Parse(scoreValueText.text);
            currentScor += 50;
            scoreValueText.text = currentScor.ToString();
            Destroy(gameObject);
        }

    }

}
