using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UzayGemisiKontrol : MonoBehaviour
{

    //aracin hizi
    [SerializeField] float speed = 1f;
    [SerializeField] GameObject mermi;
    [SerializeField] float mermininHizi = 1f;
    [SerializeField] float mermiOlusmaHizi = 1f;
    [SerializeField] float gemininCani = 200f;

    //kamera ayarlari icin uzay aracinin gidecegi max sag ve min sol yonu
    private float xmin;
    private float xmax;

    //tam solda veya tam sagda durmasın araya padding ekliyorum
    private float inceAyar = 0.7f;
    // Start is called before the first frame update
    void Start(){
        //uzay aracıyla kameranın arasındaki z ekseninin uzunlugunu buluyorum
        float uzaklik = transform.position.z - Camera.main.transform.position.z;

        //burda kameranin en solunun kordinatini buluyorum
        Vector3 solUc = Camera.main.ViewportToWorldPoint(new Vector3(0,0,uzaklik));
        //kameranin en saginin kordinatini buluyorum
        Vector3 sagUc = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, uzaklik));

        //sinirlarimi belirlemek icin max ve min degiskenlerime esitliyorum
        //burda inceAyar degiskeni padding vermek icin
        xmin = solUc.x + inceAyar;
        xmax = sagUc.x - inceAyar;

    }


    void AtesEt() {
        //mermiyi olusturuyorum
        GameObject olusanMermi = Instantiate(mermi,transform.position,Quaternion.identity) as GameObject;
        //mermiye oldugu konumdan yukarıya doğru bir hız vriyorum böylece mermim yukarıya doğru haraket edecek
        olusanMermi.GetComponent<Rigidbody2D>().velocity = new Vector3(0,mermininHizi,0);

    }

    void HaraketEt() {

        //kameranın ekseninden çıkmasın diye bir kontrol yapıyorum
        float yeniXEkseni = Mathf.Clamp(transform.position.x, xmin, xmax);
        //gemimin poziyonunu tekrardan ayarlıyorum eğer eksenden çıkmışsa otomatik tekrar
        //eksenin içine alıcak
        transform.position = new Vector3(yeniXEkseni, transform.position.y, transform.position.z);


        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            //sola gidecekse suanki konuma hiz çarpı frameler arasındaki salise farkı kadar yer değiştiriyorum
            transform.position += Vector3.left * speed * Time.deltaTime;

        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            //saga gidecekse suanki konuma hiz çarpı frameler arasındaki salise farkı kadar yer değiştiriyorum
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

    }

    // Update is called once per frame
    void Update(){

        //eğer boşluğa basarsam otomatik olarak mermi oluşacak
        if (Input.GetKeyDown(KeyCode.Space)) {
            //burda AtesEt fonksiyonunu 0.01 saniye sonra mermiOlusmaHizi saniyesinde bir oluşmasını söylüyorum
            InvokeRepeating("AtesEt",0.01f,mermiOlusmaHizi);

        }else if (Input.GetKeyUp(KeyCode.Space)) {
            //elimi boşluktan çektiğimde bu döngüyü siliyorum
            CancelInvoke("AtesEt");
        }

        HaraketEt();

    }

    private void OnTriggerEnter2D(Collider2D collision){

        if (collision.gameObject.CompareTag("dusmaninMermisi"))
        {

            //mermimi bir objeye atiyorum
            MermiKontrol mermi = collision.gameObject.GetComponent<MermiKontrol>();

            //geminin canini azaltiyorum
            gemininCani -= mermi.ZararVer();
            //gemiye carptiktan sonra mermiyi yok ediyorum
            mermi.YokOl();

            //eger geminin cani 0 dan az ise dusman gemisini yok ediyorum
            if (gemininCani <= 0)
            {

                Destroy(gameObject);

            }
        }


    }

}
