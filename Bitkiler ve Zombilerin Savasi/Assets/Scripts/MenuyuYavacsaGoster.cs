using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuyuYavacsaGoster : MonoBehaviour
{

    //Bu programın<scriptin> amacı menuyu yavaşça göstermek ekran siyahtan aydınlağa geçerek bir efekt etkisi yaratıyor
    //peki bunu nasıl yapıyorm?
    //menumun sahnesinde ekranı kaplayan bir panelim var bunun rengini başta siyah yapıyorum ve belirlediğim süre zarfında 
    //bu panelin rengini yavaşça açıyorum en sonda ise paneli yok ediyorum


    //kaç saniyede ekranı göstersin
    [SerializeField] float yavacsaGostermeSuresi;

    //ekranın başlangıçtaki rengi siyah
    private Color guncelRenk = Color.black;



    void Update()
    {
        //belirledigim sure arasinda ekran siyahtan saydamliga gidiyor
        if(Time.timeSinceLevelLoad < yavacsaGostermeSuresi) {

            //alfaDegisimi miktarı kadar renk geçişi yapıyor
            float alfaDegisimi = Time.deltaTime / yavacsaGostermeSuresi;
            guncelRenk.a -= alfaDegisimi;
            //panelin image nesnesinin rengini güncelliyorum
            GetComponent<Image>().color = guncelRenk;

        }
        else
        {

            //artık panelim ile işim kalmadığı bu yüzden paneli yok ediyorum
            Destroy(gameObject);

        }

    }
}
