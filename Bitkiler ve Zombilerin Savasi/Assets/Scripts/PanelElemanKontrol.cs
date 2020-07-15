using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelElemanKontrol : MonoBehaviour
{



    //SecmePaneli objemin içinde bulunan oyunun içinde oluşturacağım savunan objelerim bulunuyor
    //bu programın amacı panelde bulunan objeleri ekranda tıkladığım yerde oluşmasına yardım etmek

    //bu program SecmePanelinde değil onun içindeği objelerde bulunuyor

    //hangi elemanı oluşturcak kaktüse tıkladığında kaktüsü cüceye tıkladığında cüceyi oluşturması lazım bu yüzden
    //onun prefabini veriyorum yani bu scripti cüce kullanıyorsa ona cücenin prefabini veriyorum kaktüs kullanıyorsa ona kaktüsün prefabini veriyorum
    [SerializeField] GameObject elemanPreFab;

    //secmePaneli objemin içinde bulunan objeleri tutmak için bir dizi oluşturuyorum
    private PanelElemanKontrol[] panelinElemanları;
    
    //hangi eleman seçildi? bunu satitick olarak belirliyorum eğern en son taşa tıklandıysa taş oluşcak
    //bu nesneye ait değil sınıfa ait bir özellik hangisi seçildiğini bölyece bulabliyorum
    public static GameObject secilenEleman;

    // Start is called before the first frame update
    void Start()
    {
        //başlangıçta panelin elemanlarını buluyorum
        panelinElemanları = GameObject.FindObjectsOfType<PanelElemanKontrol>();
        //paneldeki bütün objelerin rengini siyah yapıyorum sadece tıklanan obje gözükecek
        butunNesneleriSiyahYap();
    }


    //mouse ile collider ile oluşturduğum bölgeye tıklarsam bu bölge çalışcak
    private void OnMouseDown()
    {
        //tiklanilan objeyi secilen elemana eşitliyorum böylece başka bir programda objeyi oluştururken ne oluşması gerektiğini söyliyebilecem
        secilenEleman = elemanPreFab;
        //paneldeki bütün objeleri siyah yapıyorum
        butunNesneleriSiyahYap();
        //sadece seçilenin rengini normale döndürüyorum(şuan seçilen objedeyiz)
        GetComponent<SpriteRenderer>().color = Color.white;

    }

    private void butunNesneleriSiyahYap() { 
        
        //for döngüsünde panelin içindeki objeleri dönüp onların rengini siyah yapıyorum
        foreach(PanelElemanKontrol eleman in panelinElemanları) {
            eleman.GetComponent<SpriteRenderer>().color = Color.black;
        }

    }

}
