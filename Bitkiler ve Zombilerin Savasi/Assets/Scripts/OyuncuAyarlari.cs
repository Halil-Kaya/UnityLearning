using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OyuncuAyarlari : MonoBehaviour
{

    /*Bu programın amacı kullanıcının sisteme girdiği kalıcı ayarları değişiklikleri tutmak içindir*/
    
    //anahtar kelimelerini ayarlıyorum
    const string ANA_SES_ANAHTARI = "ana_ses";
    const string SEVIYE_ANAHTARI = "seviye_acik_";
    const string ZORLUK_ANAHTARI = "zorluk";

    //girdiği seviyeye göre sesini ayarlıyorum
    public static void AnaSesiAyarla(float ses) { 
        
        if(ses >= 0 && ses <= 1f) {
            //PlayerPrefs objesi sayesinde oyunum kapatılsa bile bilgilerini kendinde saklıyor böylece level sistemini ses ayarını zorluk seviyesini saklıyabiliyorum
            PlayerPrefs.SetFloat(ANA_SES_ANAHTARI,ses);

        }else {

            Debug.LogError("Geçersiz ses seviyesi!!");

        }

    }

    //Ses seviyesinin nolduğunu döndürüyorum
    public static float getAnaSes() {
        return PlayerPrefs.GetFloat(ANA_SES_ANAHTARI);
    }

    //bir levelin kilidini açmak için bu fonksiyonu çalıştırıyorum
    public static void SeviyeninKilidi(int seviye) { 

        //girilen seviye benim sahne sayımdan küçükse if bloğa giriyor bunu yapmamın sebebi kontrol bir hata olursa bunu engellemek
        if(seviye < SceneManager.sceneCountInBuildSettings) {

            //SEVİYE_ANAHTARI+seviye sayesinde hangi bölümün kilitli veya açık olduğunu bulabliyorum ör:
            //seviye_acik_1 yerine 1 atadım yani 1. seviye açık
            //seviye_acik_2 yerine de 1 atadım diyelim yani 2.seviye açık eğer kullanıcı
            //seviye_acik_3 yerine ulaşmaya çalışırsa orasına bir atama yapılmadığı için default olarak 0 döndürcek bunun anlamı da
            //sevüye kitli
            PlayerPrefs.SetInt(SEVIYE_ANAHTARI+seviye.ToString(),1);

        }
        else {

            Debug.LogError("oyunda olmayan sahneyi açıyorsun hata!");

        }

    }


    //seviyenin açık olup olmadığını kontrol ediyorum
    public static bool SeviyeAcikMi(int seviye) {

        //burda bir kontrol yapıyorum eğer benim 4 tane sahnem varsa ve benden 7. sahneyi isterse hata döndürüyor
        if(seviye >= SceneManager.sceneCountInBuildSettings) {
            Debug.LogError("HATA Geçersiz seviye!!");
            return false;
        }

        //seviye degerini alıyorum eğer seviye açık ise 1 değilse 0 dönüyor
        int seviyeDegeri = PlayerPrefs.GetInt(SEVIYE_ANAHTARI+seviye.ToString());

        
        //eğer seviye değeri 1 ise true değilse false dönüyor
        return (seviyeDegeri == 1);

    }

    //ses ayarla mantığıyla zorluğu ayarlıyorum tek fark ses 0f-1f arasında değer alırken zorluk değerini kendime göre ayarlamam
    public static void ZorluguAyarla(float zorluk) { 
        
        if(zorluk >= 1f && zorluk <= 5f) {

            PlayerPrefs.SetFloat(ZORLUK_ANAHTARI,zorluk);

        }
        else {
            Debug.LogError("Zorluk seviyesi hatalı girildi");
        }
    }

    //zorluğun değerini dönüyor
    public static float ZorluguAl() {
        return PlayerPrefs.GetFloat(ZORLUK_ANAHTARI);
    }

}
