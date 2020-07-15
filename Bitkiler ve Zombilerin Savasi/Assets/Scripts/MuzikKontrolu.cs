using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MuzikKontrolu : MonoBehaviour
{

    //bu programın amacı her sahnede müzik devam etmesi içindir

    //müziği çalacak olan objem sadece 1 kere oluşması lazım o yüzden onu statik olarak belirliyoru
    private static MuzikKontrolu muzikKontrolu; 

    //awake fonksiyonun farkı start tan öncede çalışmasıdır
    private void Awake()
    {
        //eğer muzikKontrolu objemiz null değilse zaten müzik çalıyordur o yüzden oluşacak olan yeni MuzikKontrol objesini siliyorum
        if(muzikKontrolu != null) {
            Destroy(gameObject);
        }
        else{
            //eğer muzikKontrolu objemiz null ise ona atama yapıyorum
            muzikKontrolu = this;
            //ayrıca sahne değişiminde obje silinmemesini gerektiğini söylüyorum bu fonksiyon sayesinde sonraki sahneye geçtiğimde
            //bu obje silinmeyim sonraki sahneye kendini ekleyecek
            DontDestroyOnLoad(muzikKontrolu);

        }
        
    }

    //ses düzeyini ayarlıyorum
    public void SesiAyarla(float sesAyari) {
        GetComponent<AudioSource>().volume = sesAyari;
    }

    
    void Start()
    {
        //başlangıçta ses düzeyini ayarlıyorum OyuncuAyarlari kisminda oyuncumun girdiği ayar seviyesine göre sesim ayarlanıyor
        GetComponent<AudioSource>().volume = OyuncuAyarlari.getAnaSes();
    }

}
