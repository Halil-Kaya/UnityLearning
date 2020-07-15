using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParayiTopla : MonoBehaviour
{
    //başlangıçtaki toplam paramızı dışardan verebilmek için public yapıyorum
    public int toplamPara;

    //para miktarını gösteren text objesi
    private Text paraMiktariText;

    //bir obje oluştururken parası yetiyorsa objeyi oluşturması lazım parası yetiyor mu yetmiyor mu bunu kontrol etmek için
    //enum kullandım enum kullanmamın özel bir sebebi yok sadece kullanmak istedim
    public enum ObjeOlusturmaDurumu {BASARILI,BASARISIZ};


    private void Start()
    {
        //text objesini alıyorum
        paraMiktariText = GetComponent<Text>();
        //texti başlangıçta güncelliyorum
        parayiGosterenTextiGuncelle();
    }


    //para ekliyip yazıyı güncelliyorum
    public void ParayiEkle(int miktar) {
        toplamPara += miktar;
        parayiGosterenTextiGuncelle();
    }

    //parayı azaltıyorum eğer işlem başarılı ise BASARILI değilse BASARISIZ dönüyorum
    public ObjeOlusturmaDurumu ParayiKullan(int miktar) {
            
        if(toplamPara >= miktar) {
            toplamPara -= miktar;
            parayiGosterenTextiGuncelle();
            return ObjeOlusturmaDurumu.BASARILI;
        }
        else {

            return ObjeOlusturmaDurumu.BASARISIZ;

        }
    
    }

    //parayi gosteren texti guncelliyorum
    private void parayiGosterenTextiGuncelle() {
        paraMiktariText.text = toplamPara.ToString();
    }

}
