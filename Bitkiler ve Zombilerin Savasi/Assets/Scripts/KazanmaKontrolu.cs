using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KazanmaKontrolu : MonoBehaviour
{
    //Slider objesini zaman çizelgesi olarak kullandım
    private Slider timeSlider;

    private void Start()
    {
        //Bu objemizin içerisinde bu programı<scripti> kullanıyorum bu yüzden GetComponent ile bu objemizin içerisinde bulunan
        //slider özelliğini alıp eşitliyorum
        timeSlider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        //her frame gösterildiğinde bu fonksiyon çalışıyor bu yüzden her frame gösterildiğinde süreyi azaltıyorum
        timeSlider.value -= 0.0025f;
        
        //eğer süre bittiyse oyuncuyu kazanma ekranına gönderiyorum
        if(timeSlider.value <= 0) {

            SceneManager.LoadScene("KazanmaEkrani");

        }
        
    }
}
