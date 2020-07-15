using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IpKesme : MonoBehaviour
{

    public Camera kamera;

    // Start is called before the first frame update
    void Start()
    {
        //kamera = gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0)) {
            
            RaycastHit2D carptigiNesne = Physics2D.Raycast(kamera.ScreenToWorldPoint(Input.mousePosition),Vector2.zero);

            if(carptigiNesne.collider != null) {
               
                if (carptigiNesne.collider.CompareTag("ip")) {
                    
                    Destroy(carptigiNesne.collider.gameObject);

                }

            }

        }
     
        
    }
}
