using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource sourceController;
    private Rigidbody2D arrowBody;
    [SerializeField] GameObject effect;
    [SerializeField] AudioClip enemyDieMusic;

    void Start(){
        //sesleri kontrol etmek için SoundController nesnesini alıyorum
        sourceController = GameObject.Find("SoundController").GetComponent<AudioSource>();

        //okun vicudunu getiriyorum
        arrowBody = GetComponent<Rigidbody2D>();

    }
    

    //ok bir şeyle temas ettiğinde bu fonskiyon tetikleniyor
    private void OnTriggerEnter2D(Collider2D other){
        //eğer ok düşmana çarparsa çarptığı objeyi yani düşmanı yok ediyor ayrıca kendisini de yok ederek ok da yok oluyor
        if(other.gameObject.CompareTag("enemy")){

            //düşman ölüğünde öldürme müziği çalıyorum
            sourceController.PlayOneShot(enemyDieMusic,1f);

            //efekt yapma islemi
            //ilk parametre hangi efeği yapcağını
            //2. parametre nerde başlayacağını
            //3. parametreyi bende bilmiyorum
            Instantiate(effect,other.gameObject.transform.position,Quaternion.identity);

            Destroy(gameObject);
            Destroy(other.gameObject);
        }//eğer ok kullanıcı dışında bir nesneye çarparsa okun konumu donuyor böylece
        //ok orda saplanmış gibi duruyor
        else if(!other.gameObject.CompareTag("player")){
            arrowBody.constraints = RigidbodyConstraints2D.FreezePosition;
        }

    }

    //ok kamera açısından çıktığında yok ediliyor böylece sistemde gereksiz yere yer kaplamıyor
    //performans açısından önemli bir fonksiyon
    private void OnBecameInvisible() {
        Destroy(gameObject);
    }
    
}
