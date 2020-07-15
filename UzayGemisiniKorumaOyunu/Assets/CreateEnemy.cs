using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{

    [SerializeField] GameObject enemyPrefabi;

    [SerializeField] float dikUzunluk;
    [SerializeField] float yatayUzunluk;
    [SerializeField] float speed;
    [SerializeField] float dusmanOlusmaSuresi = 1f;

    public bool sagaHaraket = true;

    private float xmax;
    private float xmin;


    // Start is called before the first frame update
    void Start(){

        //kameranin kordinatlarini aliyorum
        //kamera ile obje arasinda ki mesafe (z Ekseni)
        float objeIleKameraZFarki = transform.position.z - Camera.main.transform.position.z;
        //kameranin sol tarafinin kordinati
        Vector3 kameraninSolTarafi = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, objeIleKameraZFarki));
        //kameranin sag tarafinin kordinati
        Vector3 kameraninSagTarafi = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, objeIleKameraZFarki));

        //artik kameranin sinirlarini aldim en sol ve en sag kisimdaki kordinati biliyorum
        //en sag benim max gitmem gereken en sol benim minimum gitmem gereken yer yani benim sınırlarım
        xmax = kameraninSagTarafi.x;
        xmin = kameraninSolTarafi.x;

        DusmanlariTekTekOlustur();
        
    }

    private void DusmanOlustur() {

        //bu objenin altında objeler var o objeler bana dusmanların nerde dogacağını gösteriyor
        //benim o objelerin içinde düşmanımın objesini koymam gerekiyor bu yüzden öncelikle
        //bu objenin altındaki objeleri gezmem gerek
        //EnemyBase in altinda ki poziyonlara gore dusman olusturuyorum
        //NOT:bunu yapmamın sebebi dosyaların daha düzenli olması ayrıca kontrolü daha güçlü
        foreach (Transform child in transform)
        {


            //dusman olusturuyorum
            GameObject enemy = Instantiate(enemyPrefabi, child.transform.position, Quaternion.identity);
            //dusman objesini bu nesnenin altında olusturmasını soyluyorum
            enemy.transform.parent = child;

        }

    }


    //dusmanlar ayni anda olusmasin teker teker olusmasini saglayan fonksiyon
    private void DusmanlariTekTekOlustur() {

        //hangi pozisyonda dusman yok onu buluyor
        Transform uygunPozisyon = SonrakiUygunPozisyon();
        if (uygunPozisyon) {
            //dusman olusturuyorum
            GameObject enemy = Instantiate(enemyPrefabi, uygunPozisyon.transform.position, Quaternion.identity);
            //dusman objesini bu nesnenin altında olusturmasını soyluyorum
            enemy.transform.parent = uygunPozisyon;
        }

        //eğer oluşmamış başka düşmanlar varsa otomatik kendisi teker teker olusturacak
        if (SonrakiUygunPozisyon()) {

            Invoke("DusmanlariTekTekOlustur", dusmanOlusmaSuresi);

        }

    }


    //bu objenin sınırını çiziyorum böylece bu sınıra göre sağ ve sola haraket ettircem
    private void OnDrawGizmos(){
        Gizmos.DrawWireCube(transform.position, new Vector3(yatayUzunluk, dikUzunluk, 0));
    }

    // Update is called once per frame
    void Update(){
        //eğer sağa gidebiliyorsa sağa gidecek
        if (sagaHaraket) {

            transform.position += Vector3.right * Time.deltaTime * speed;

        }else{//sağa gidemiyorsa sınırı aşmışsa sola gidecek

            transform.position += Vector3.left * Time.deltaTime * speed;

        }

        //icine cizdigim kutunun sag ve sol sinirini buluyorum
        //pozisyon bana merkez noktasını verir eğer sınırın uzunluğunun yarısını eklersem
        //bu bana sağ sınırı verir
        float sagSinir = transform.position.x - yatayUzunluk / 2;
        float solSinir = transform.position.x + yatayUzunluk / 2;

        //eger siniri asarlarsa yonlerini degistiriyorum
        if (sagSinir > xmax) {

            sagaHaraket = false;
        
        }else if(solSinir < xmin) {

            sagaHaraket = true;        
        
        }

        if (ButunDusmanlarOlduMu()) {
            DusmanlariTekTekOlustur();
        }

    }

    Transform SonrakiUygunPozisyon() { 
        //objenin içini dönüyorum
        foreach(Transform cocuklarinPozisyonu in transform) { 
            //eğer pozisyonda düşman yoksa onun objesini dönüyorum
            if(cocuklarinPozisyonu.childCount == 0) {
                return cocuklarinPozisyonu;
            }

        }
        //eğer bütün oyunda bütün düşmanlar varsa null dönüyorum
        return null;

    }


    bool ButunDusmanlarOlduMu() { 
        
        foreach(Transform pozisyonlar in transform){ 

            if(pozisyonlar.childCount > 0) {

                return false;

            }

        }

        return true;
    }


}
