using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TopKontrol : MonoBehaviour
{


    //topun hizini aliyorum
    [SerializeField] float topunHizi;
    //topun donusecegi renkleri aliyorum
    [SerializeField] Color turkuaz;
    [SerializeField] Color sari;
    [SerializeField] Color pembe;
    [SerializeField] Color mor;

    //skorun gosterildigi texti aliyorum
    [SerializeField] Text skorText;
    //top ilerledikce ilerisinde olucasak olan cemberleri aliyorum
    [SerializeField] GameObject[] cemberler;

    //ilerde olusacak olan renk tekerini aliyorum
    [SerializeField] GameObject renkTekeri;

    //topa bir hız vermek için vicudunu aliyorum
    private Rigidbody2D topunVicudu;
    //topun rengini değiştirmek için topun spriteRenderer objesini alıyorum
    private SpriteRenderer mySpriteRenderer;

    //topun o an hangi renge sahip olması için kullandığım değişken
    private string mevcutRenk;
    //puanı tutan değişken
    private int puan = 0;

    


    private void Start()
    {
        //başta skoru sıfırlıyorum
        skorText.text = puan.ToString();
        //objelerimi alıyorum
        mySpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        topunVicudu = gameObject.GetComponent<Rigidbody2D>();
        //oyunun başlangıcında topa rastgele bir renk atıyorum
        RastgeleRenkAta();
    }


    // Update is called once per frame
    void Update()
    {
        //eğer mouse tıklanırsa topa yukarı doğru hız veriyorum  
        if (Input.GetMouseButtonDown(0)) {
            topunVicudu.velocity = Vector2.up * topunHizi;
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //eğer top bir objeyle etkilişime girerse bu obje tetiklenecek

        //eğer puan objesiyle etkileşime girerse burası tetiklenecek
        if (collision.CompareTag("puan")) {
            //puanı attırıp textimi güncelliyorum
            puan += 50;
            skorText.text = puan.ToString();
            //puan objemi siliyorum böylece oyuncu aynı noktada durmadan puan kazanamiyacak
            Destroy(collision.gameObject);

            //bu çemeri geçtiğine göre ilerisinde tekrar bir çember oluşturmam lazım böylece oyun sonsuza kadar gidecek
            //hangi çember oluşacak? random oluşmasını sağlıyorum
            int randomCember = Random.Range(0,cemberler.Length);

            //12f kadar yukarısında oluşturuyorum
            Instantiate(cemberler[randomCember], new Vector3(transform.position.x, transform.position.y + 12f, transform.position.z), Quaternion.identity);

            //aşağısını artık kontrol etmesine gerek yok bu yüzden işlemi bitiriyorum
            return;
        }

        //eğer renk tekeriyle etkilişime girerse rengini değiştiriyorum
        if (collision.CompareTag("renkTekeri")) {
            RastgeleRenkAta();
            //bi daha aynı konumda rengi değişmesin diye renk tekeri objesini yok ediyorum
            Destroy(collision.gameObject);
            //12f yukarısında renk topunu tekrar oluşturuyoruö
            Instantiate(renkTekeri,new Vector3(transform.position.x,transform.position.y+12f,transform.position.z),Quaternion.identity);

            //aşağısını artık kontrol etmesine gerek yok bu yüzden işlemi bitiriyorum
            return;
        }

        //eğer mevcut rengimiz uyusmuyorsa ve etkilişime girdiği obje puan değilse objeyi yok ediyorum
        if(!collision.CompareTag(mevcutRenk) && !collision.CompareTag("puan")) {
            //sahneyi tekrar yüklüyorum böylece her şey tekrardan başlamış oluyor
            //Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            gameObject.SetActive(false);

            //aşağısını artık kontrol etmesine gerek yok bu yüzden işlemi bitiriyorum
            return;
        }
        //eğer top aşağı düşerse top aşağıdaki bir alana çarpıyor böylece oyun yeniden başlıyor
        if (collision.CompareTag("olmeAlani")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            gameObject.SetActive(false);
        }

    }


    private void RastgeleRenkAta() {

        //0 -> turkuaz
        //1 -> sari
        //2 -> pembe
        //3 -> mor
        //oluşan rastgele sayıya göre topumun rengini değiştiriyorum
        int randomSayi = Random.Range(0,4);
        Color topunYeniRengi = new Color();

        if(randomSayi == 0) {

           topunYeniRengi = turkuaz;
            mevcutRenk = "turkuaz";

        }
        else if (randomSayi == 1) {

          topunYeniRengi =sari;
            mevcutRenk = "sari";

        }
        else if (randomSayi == 2){
            
            topunYeniRengi =pembe;
            mevcutRenk = "pembe";
        
        }
        else if (randomSayi == 3){

            topunYeniRengi = mor;
            mevcutRenk = "mor";

        }

        //topumun rengini değiştiriyorum
        mySpriteRenderer.color = topunYeniRengi;

    }


}
