using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saldiranlar : MonoBehaviour
{

    //saldiranin hizini belirliyorum
    //[Range(0f, 2f)] parametresi sayesinde hızını 0 ile 2f arasında ayarlıyabliyourm bunun amacı test aşamsında kontrol etmek
    [Range(0f, 2f)]

    //saldıranın hızı
    [SerializeField] float suAnKiHiz;
    //saldıranın dogmasuresi
    public float dogmaSuresi;

    //saldıranın saldırdığı hedef(obje)
    private GameObject mevcutHedef;

    //saldıranın animasyonlarını kontrol etmek için gereken animator nesnesi
    private Animator objeninAnimasyonu;

    // Start is called before the first frame update
    void Start()
    {
        //animator nesnesini alıyorum
        objeninAnimasyonu = GetComponent<Animator>();
        //vicudunu alıyorum
        Rigidbody2D body = gameObject.AddComponent<Rigidbody2D>();
        //yer çekimi gibi özelliklere maruz kalmasın diye vicudun özelliğini kitematik yapıyorum 
        //kinematiğin amacı bu vicudun hızını özelliklerini kendim belirttiğimdir 
        body.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        //saldıran sola doğru belirlediğim hızda ilerliyor
        transform.Translate(Vector3.left * suAnKiHiz * Time.deltaTime);
        //eğer mevcut bir hedef yok ise harakete geçmesi için saldiriyorMu değişkenini false yapıyorum
        if (!mevcutHedef) {
            objeninAnimasyonu.SetBool("saldiriyorMu", false);
        }

    }

    //hizini ayarkıyorum bunun sebebi tilki taşın üstünden geçerken hızlanması için
    public void hiziAyarla(float hiz) {

        suAnKiHiz = hiz;

    }
    
    //eğer saldıran objenin bir hedefi var ise girilen zararMiktarı kadar zarar veriyor
    //bu fonksiyon animasyonun içinde çağrılıyor
    public void ZararVer(float zararMiktari) {

        if (mevcutHedef) {

            Saglik saglik = mevcutHedef.GetComponent<Saglik>();

            if (saglik) {
                saglik.ZaralAl(zararMiktari);
            }

        }



    }

    //hedefi beliriyorum
    public void HedefiBelirle(GameObject hedefimiz) {

        mevcutHedef = hedefimiz;

    }


}
