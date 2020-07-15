using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kertenkele : MonoBehaviour
{
    /*2 tane saldıran objem var biri kertenkele biri tilki. Kertenkele normal bir şekilde saldırırken tilki objem taşın üstünde zıplayabiliyor*/

    //kertenkele objemin animasyonlarını hareketlerini kontrol etmek için animator objesini oluşturuyorum
    private Animator kertenkeleAnimator;
    //zarar verme işlemleri saldiranObje sınıfında kontrol ediyorum bu yüzden bundan bir obje oluşturuyorum
    private Saldiranlar saldiranObje;

    // Start is called before the first frame update
    void Start()
    {
        //kertenkelenin animator objesini alıyorum
        kertenkeleAnimator = GetComponent<Animator>();
        //saldiran objeinin Saldiranlar scriptini alıyorum
        saldiranObje = GetComponent<Saldiranlar>();    
    }


    private void OnTriggerEnter2D(Collider2D collision){
        //kertenkelemiz bir nesneyle etkileşime girdiğinde bu fonksiyon tetikleniyor

        //kerten kelemizin etkilisime girdiği objeyi tutuyorum
        GameObject kertenkeleninEtkilisimeGirdigiObje = collision.gameObject;

        //eğer kertenkelemizin etkilişime girdiği obje savunanlar objesine sahip değilse(yani savunan obje değilse tilki mermi yada başka bir kertenkeleyse)
        //bir işlem yapma ve fonksiyondan çıkmasını söylüyoruz
        if (!kertenkeleninEtkilisimeGirdigiObje.GetComponent<Savunanlar>()) {

            return;

        }else {
            //eğer kertenkelenin etkilişie girdiği obje savunanlar objesine sahipse yani Savunan bir objeyse ona saldırması lazım
            //kertenkelemezizin animatorunun saldiriyorMu değişkkenini true yapıyoruz böylece kertenkelemimiz saldirmaya başlıyor
            //saldırma sırasında da Saldıranlar scriptindeki ZararVer fonksiyonu çalışıyor böylece kertenkelemiz saldırmaya başlıyor
            kertenkeleAnimator.SetBool("saldiriyorMu",true);

            //kertenkelemiz neye saldırıyor? bunu belirtmemiz lazım bu yüzden Saldiranlar scriptine bunu söylüyoruz ona hedefi veriyoruz
            //neye saldırcağını söylemiş oluyoruz
            saldiranObje.HedefiBelirle(kertenkeleninEtkilisimeGirdigiObje);

        }



    }

}
