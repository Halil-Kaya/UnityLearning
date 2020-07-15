using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kaybetme : MonoBehaviour
{

    //eğer unity de oluşturduğum Kaybetme alanına bir obje<Düşman> girerse bu fonksiyon tetiklenecek
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //buraya obje<düşman> girdiyse oyunu kaybetmişizdir bu yüzden oyuncuyu kaybetme ekranına gönderiyorum
        SceneManager.LoadScene("KaybetmeEkrani");
    }

}
