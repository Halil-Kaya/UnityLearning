using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField] LayerMask engel;
    [SerializeField] float speed;
    private Rigidbody2D enemyBody;
    private float width;
    private bool yerleTemasHalindeMi;

    // Start is called before the first frame update
    void Start(){
        //dusmanin vicudunu aliyorum
        enemyBody = GetComponent<Rigidbody2D>();

        //dusmanin x eksenindeki uzunlugunu aliyorum
        width = GetComponent<SpriteRenderer>().bounds.extents.x;
    }

    // Update is called once per frame
    void Update(){
        // burda bir seye carpilmasi icin bir nesne olusturdum
        //peki bu ne işe yarıyor? bu nesne görünmez bir çizgi çekmemizi sağlıyor
        //bu çizgi bir şeyle temas ettiğinde de haberimiz oluyor
        //ilk iki parametre çizgi nerden nereye çekilecek
        //burda merkezimizin orta merkezinin yarısı kadar sagında başlamısını söylüyoruz
        //ör: cismin uzunlugu 10 olsun
        //tranform.psition cismin merkezini gosterdigi icin uzunlugun yarısını işaret eder yani 5.
        //5 in yarısı kadar SAĞA ekelemesini soyluyoruz yani 7.5 yerde cizgi basliyacak
        //transform.right koymamızın sebebi çizginin nesneyle beraber dönmesi yani eğer nesneyi 180 derece dönderirsek bu sefer çizgi
        //sol kısımda bulunacak böylece çizgi dinamik olarak değişecek sağ ve sola oyniyacak.
        //transform.position + (transform.right * width / 2)
        //ikinci parametre nereye kadar cizilecek olması biz aşağı doğru olmasını söylüyoruz
        //3. parametre çizginin kalınlığı ne kadar olsun biz 2f kalınlığında olmasını söylüyoruz
        //4. parametre NEYLE TEMAS etmesini kontrol emtemiz için gönderdiğimiz bir parametre oraya engel parametresini gönderdik
        //engel bizim zeminimiz onla temaz edip etmediğini böylece anlamış olucaz.
        //engel bir layerdır!!
        RaycastHit2D hit = Physics2D.Raycast(transform.position + (transform.right * width / 2),Vector2.down,2f,engel);

        //eger engelle temas ediyorsa collider nesnesi boş olamaz o zaman canavarımız zeminle temaz ediyor
        if(hit.collider != null){
            yerleTemasHalindeMi = true;
        }//eğer collider nesnei boşsa çizgi bir şeyle temas etmiyor anlamına gelmektedir
        else{
            yerleTemasHalindeMi = false;
        }

        //eğer düşman yerle temas etmiyorsa düşmanın yönünü değiştirecek ayrıca hızını güncelliyecek
        Flip();

    }

    private void Flip(){

        if(!yerleTemasHalindeMi){
            transform.eulerAngles += new Vector3(0f, 180f, 0f);
        }

        //sağa doğru x ekseninde haraket etmesini söylüyoruz burda dikkat edilmesi gereken
        //eğer nesne 180 derece döndürülürse artık nesnenin sağı sol tarafı olcağından bu sefer sola doğru haraket eder
        //NOT eğer bu işlemi start fonkisyonunda yazarsak düşman sağa doğru gidecek engeli aştığında yönü değişçek ama hız olarak
        //sağa gitmeye devam edicek bunun sebebi bu işlem o an nereye gitmesiyle alakalıdır!!!
        enemyBody.velocity = new Vector2(transform.right.x * speed, 0f);

    }


    //geliştirme aşamasında çizgiyi görmemiz için yazdığımız fonksiyon bu fonksiyon oyun sırasında çalışmaz
    //geliştirilme aşamasında çalışır!
    private void OnDrawGizmos()
    {
        width = GetComponent<SpriteRenderer>().bounds.extents.x;
        Gizmos.color = Color.red;
        Vector3 playerRealPozisition = transform.position + (transform.right * width / 2);
        Gizmos.DrawLine(playerRealPozisition, playerRealPozisition + new Vector3(0, -2f, 0));
    }

}
