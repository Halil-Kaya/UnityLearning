using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SahneKontrolu : MonoBehaviour
{

    //bu programın amacı sahneler arası geçişi kontrol etmek

    //sonraki sahneye gitme sürem
    [SerializeField] float sonrakiSahneyeGitmeSuresi;

    private void Start()
    {
        //eğer ilk açılan ekran AcilisEkrani ise belirlediğim süre kadar bekleyip sonrakiSahne fonksiyonunu çalıştırıyor böylece sonraki
        //sahneye gidiyorum
        if(SceneManager.GetActiveScene().name == "AcilisEkrani") {
            Invoke("SonrakiSahne", sonrakiSahneyeGitmeSuresi);
        }

    }

    //sonraki sahneye gönderiyor
    public void SonrakiSahne() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //adiyla sonraki sahneye gidiyorum
    public void AdiylaSahneyeGit(string sahneAdi) {
        SceneManager.LoadScene(sahneAdi);
    }

    //verilen indexe göre sonraki sahneye gidiyorum
    public void IndexleSahneyeGit(int index) {
        SceneManager.LoadScene(index);
    }

    //oyundan çıkıyorum
    public void OyundanCik() {
        Application.Quit();
    }

}
