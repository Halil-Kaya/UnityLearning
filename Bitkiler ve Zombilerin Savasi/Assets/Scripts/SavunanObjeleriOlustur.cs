using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavunanObjeleriOlustur : MonoBehaviour
{

    //bu programın amacı savunan objeleri oluşturmak

    //sahne alanını belirli bir kordinata göre bölmek için kameramızı almam gerekiyor
    [SerializeField] Camera bizimKameramiz;

    //toplam paramıza ulaşmak için ParayiTopla objesine ulaşıyorum
    private ParayiTopla toplamPara;
    //savunan objeler belirli bir objenin altında sıralanmasını istiyorum bu yüzden bir obje oluşturdum Mermiler programında kullandığım mantık
    private GameObject savunanObjeParent;

    // Start is called before the first frame update
    void Start()
    {
        //bütün programların arasından ParayiTopla programını buluyorum
        toplamPara = GameObject.FindObjectOfType<ParayiTopla>();

        //Savunanlar objesini buluyorum
        savunanObjeParent = GameObject.Find("Savunanlar");
        //eğer savunanlar objesi yok ise bu isimde bir obje oluşturuyorum böylece bu objeden 1 kez oluşacak
        if (!savunanObjeParent) {
            savunanObjeParent = new GameObject("Savunanlar");
        }
        
    }

    private void OnMouseDown()
    {
        //oyun alanıma tıklandığında bu fonksiyon tetiklenecek

        //PanelElemanKontrolda statik olarak tutulan secilen elemanı alıyorum bu oluşacak olan objedir
        GameObject olusacakSavunanObjesi = PanelElemanKontrol.secilenEleman;

        //maliyetini alıyorum
        int savunanObjeninMaliyeti =olusacakSavunanObjesi.GetComponent<Savunanlar>().maliyet;
        
        //parayı azaltıyorum eğer işlem başarılı ise objeyi oluşturuyorum para yetesiz ise bir işlem yapmıyor
        if(toplamPara.ParayiKullan(savunanObjeninMaliyeti) == ParayiTopla.ObjeOlusturmaDurumu.BASARILI) {
            
            //girilen parametrele göre istenilen konumda objeyi oluşturuyorum
            //konumuGetir() fonksiyonu bana (1,1) (2,2) (3,1) (2,4) gibi bir kordinat veriyor
            objeyiOlustur(olusacakSavunanObjesi,konumuGetir());

        }
        else{
            Debug.Log("bakiye yok");
        }


    }

    
    private void objeyiOlustur(GameObject olusacakOlanSavunmaObjesi,Vector2 olusacagiKonum) {
        //objeyi oluşturuyorum
        GameObject olusanObje = Instantiate(olusacakOlanSavunmaObjesi, olusacagiKonum, Quaternion.identity);
        //olusan objenin bir objenin (Savunanlar) altında oluşmasını sağlıyorum böylece oyun sırasında dosyalarım düzenli gözükecek
        olusanObje.transform.parent = savunanObjeParent.transform;

    }

    //konumu getiriyorum
    Vector2 konumuGetir() {
        return pozisyonuYuvarla(farePozisyonunuGercekDunyayaAktar());
    }


    //(0.2,5.3) olan kordinatımı yukarı yuvarlayım (1,6) gibi bir değere yuvarlıyorum
    Vector2 pozisyonuYuvarla(Vector2 yuvarlanacakPozisyon) {

        float yuvarlaX = Mathf.CeilToInt(yuvarlanacakPozisyon.x);
        float yuvarlaY = Mathf.CeilToInt(yuvarlanacakPozisyon.y);
        return new Vector2(yuvarlaX,yuvarlaY);

    }

    Vector2 farePozisyonunuGercekDunyayaAktar() {
        //gerçek dünyadaki konumunu alıyorum

        float fareX = Input.mousePosition.x;
        float fareY = Input.mousePosition.y;
        float kameraUzakligi = 15f;

        Vector3 mousePosizyonu = new Vector3(fareX,fareY,kameraUzakligi);
        Vector2 gercekDunyadakiPozisyon = bizimKameramiz.ScreenToWorldPoint(mousePosizyonu);


        return gercekDunyadakiPozisyon;

    }


}
