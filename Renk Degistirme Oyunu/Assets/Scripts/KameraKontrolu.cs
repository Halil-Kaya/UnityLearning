using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraKontrolu : MonoBehaviour
{
    //bu programın amacı kameranın top ile haraket etmesi

    //topun objesini alıyorum böylece pozisyonunu takip edebilecem
    [SerializeField] Transform topunTransformu;


    // Update is called once per frame
    void Update()
    {
        //eğer topun y ekseni kameranın y ekseninden büyükse kameranın eksenini topun eksenine eşitliyorum böylece kamera
        //topla beraber haraket etmiş olucak
        if(topunTransformu.position.y > transform.position.y) {

            transform.position = new Vector3(transform.position.x,topunTransformu.position.y,transform.position.z);

        }

    }
}
