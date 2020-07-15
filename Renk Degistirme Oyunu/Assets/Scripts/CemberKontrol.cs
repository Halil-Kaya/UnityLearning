using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CemberKontrol : MonoBehaviour
{

    //bu program cemberin donmesini sagliyor

    //donme hizini aliyorum
    [SerializeField] float donmeHizi;
    //hangi yonde doncegini belirtiyorum
    [SerializeField] bool solaDon;

    void Update()
    {
        //eğer sola don değişkeni true ise sola doğru döndürüyorum
        if (solaDon) { 

            transform.Rotate(0f,0f,donmeHizi*Time.deltaTime);

        }else {//eğer sola don değişkeni false ise saga döndürüyorum
        
            transform.Rotate(0f, 0f, -donmeHizi * Time.deltaTime);

        }


    }
}
