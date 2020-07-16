using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    
    [SerializeField] float speed;
    [SerializeField] float jumpPower;
    [SerializeField] GameObject arrow;
    [SerializeField] float okunHizi;
    [SerializeField] float okunDusmeHizi;
    [SerializeField] float currentAttackTimer;
    [SerializeField] float defaultAttackTimer;
    [SerializeField] AudioClip playerDieMusic;
    [SerializeField] AudioClip soundOfArrow;

    private float mySpeedx;
    private Rigidbody2D myBody;
    private Vector3 defaultLocalScale;
    private AudioSource sourceController;
    public bool yereTemasEttiMi;
    public Animator myAnimator;
    public bool okAtabilsin;


    private bool canDoubleJump;

    // Start is called before the first frame upd   ate
    void Start()
    {   
        //sesleri kontrol etmek için SoundController nesnesini alıyorum
        sourceController = GameObject.Find("SoundController").GetComponent<AudioSource>();


        //player objesinin icindeki objelerden rigidbody objesini aliyorum
        myBody = GetComponent<Rigidbody2D>();

        //baslangictaki konumunu tutuyorum boylece saga sola dondururken buna gore dondurcem
        defaultLocalScale = transform.localScale;

        //player objesinin icindeki objelerden animator objesini aliyorum
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //-1 ile 1 arasında bir deger donuyor bu yatay haraket icin kullaniliyor
        //gecisler hizli oluyor oyuncu birden haraket etmektense yavaşça hızlınıyor
        mySpeedx = Input.GetAxis("Horizontal");

        //aldigim hiz bilgisine gore animasyon durumuma bakiyorum eger hizim 0.1 den büyükse
        //koşma animasyonuna geçiyor eğer 0.1 den küçükse(yani 0 a yakınsa) durma animasyonum calisacak
        //animasyon objemde speed diye bir degiskenim var onun degerine mySpeedx i koyuyorum
        //NOT hızın yönü önemli değil hızın varlığı önemli bu yüzden hızın mutlak değerini alıyorum
        myAnimator.SetFloat("speed",Mathf.Abs(mySpeedx));


        #region sag sola haraket etme

        //kullaniciyi haraket ettiriyorum birinci parametre x ekesni icin
        //ikinci parametre y ekesni icin 
        //sag sola haraket ettigi icin y ekseni sabit bu yuzden var olan degeri koyuyorum
        //mySpeedx i speed isimli bir degiskenle carpiyorum bu karakterin hizi icin
        myBody.velocity = new Vector2(mySpeedx*speed,myBody.velocity.y);

        //if mySpeedx 0 dan küçükse sola gidiyor büyükse sağa gidiyor demektir.
        //0 ise haraket etmiyor demektir
        //buna gore karakteri sag veya sola dondurmeliyiz.
        //transform denen obje unitydeki transform objesidir
        if(mySpeedx > 0){

            transform.localScale = new Vector3(defaultLocalScale.x,defaultLocalScale.y,defaultLocalScale.z);

        }else if(mySpeedx < 0){

            transform.localScale = new Vector3(-defaultLocalScale.x,defaultLocalScale.y,defaultLocalScale.z);

        }


        #endregion


        #region ziplama

        //bosluga bastigimda zipliyor
        if(Input.GetKeyDown(KeyCode.Space)){
            
           zipla();


        }

        #endregion

        #region ok atma

        //mousuma tiklanirsa ok atilacak
        //NOT Unity ayarlarindan rigid body objesinin body type kısmını kinetic yapılması gerekiyor
        //boylece o hızda sabit bir şekilde ilerliyecek
        if(Input.GetMouseButtonDown(0)){
            
            //durmadan ok atmasını engelliyorum belli bir sure araliginda ok atabilecek
            if(okAtabilsin){
            myAnimator.SetTrigger("attack");
            Invoke("okAt",0.5f);
            okAtabilsin = false;
            }
        }

        if(okAtabilsin==false){
            currentAttackTimer -=Time.deltaTime;
        }else{
            currentAttackTimer = defaultAttackTimer;
        }

        if(currentAttackTimer <= 0){
            okAtabilsin = true;
        }

        #endregion


    }

     private void OnCollisionEnter2D(Collision2D other) {
       
       if(other.gameObject.tag == "enemy"){
           die();
       }

    }

    public void sagaGit(){
        mySpeedx = 1;
        myBody.velocity = new Vector2(mySpeedx*speed,myBody.velocity.y);

        //if mySpeedx 0 dan küçükse sola gidiyor büyükse sağa gidiyor demektir.
        //0 ise haraket etmiyor demektir
        //buna gore karakteri sag veya sola dondurmeliyiz.
        //transform denen obje unitydeki transform objesidir
        transform.localScale = new Vector3(defaultLocalScale.x,defaultLocalScale.y,defaultLocalScale.z);
    }

    public void solaGit(){
        mySpeedx = -1;
        myBody.velocity = new Vector2(mySpeedx*speed,myBody.velocity.y);

        //if mySpeedx 0 dan küçükse sola gidiyor büyükse sağa gidiyor demektir.
        //0 ise haraket etmiyor demektir
        //buna gore karakteri sag veya sola dondurmeliyiz.
        //transform denen obje unitydeki transform objesidir
        
        transform.localScale = new Vector3(-defaultLocalScale.x,defaultLocalScale.y,defaultLocalScale.z);

    }

    public void zipla(){
         //sadece 2 kez üst üste zıplayabilsin diye bir kontrol yapıyorum
            if(yereTemasEttiMi){
                //ziplamasini saglayan kod
                myBody.velocity = new Vector2(myBody.velocity.x,jumpPower);
                canDoubleJump = true;
                //ziplama animasyonunu ekliyorum
                myAnimator.SetTrigger("jump");

            }else{
                if(canDoubleJump){            
                    //ikinci ziplama birincine gore daha az olmasını saglıyorum
                    myBody.velocity = new Vector2(myBody.velocity.x,(jumpPower/2+jumpPower/3));
                    canDoubleJump = false;

                    //ziplama animasyonunu ekliyorum
                    myAnimator.SetTrigger("jump");
                }
            }
    }

    public void okAtilmaFonksiyonu(){
         if(okAtabilsin){
            myAnimator.SetTrigger("attack");
            Invoke("okAt",0.5f);
            okAtabilsin = false;
            }
    }

    public void okAt(){
          //burda bir ok nesnesi olusturuyorum bu benim atacagim ok
        //bu arada okumun gidebilmesi icin, bi yerlere carpa bilsin diye rigid body ozelligi kazandirdim
        /*
        Vector3 okunPozisyonu = new Vector3(transform.position.x+0.5f,transform.position.y,transform.position.z);
        GameObject atilanOk = Instantiate(arrow,okunPozisyonu,Quaternion.identity);
        */
        //oku atoyorum okun ne kadar hızla gidecegini x ve y parametreiyle giriyorum
        //-0.5 hızında yere dusun
        
        //oyuncu saga bakiyorsa okun yonu saga sola bakiyorsa okun yonu sola baksin
        sourceController.PlayOneShot(soundOfArrow,0.9f);
        if(transform.localScale.x > 0){
       
        Vector3 okunPozisyonu = new Vector3(transform.position.x+0.5f,transform.position.y,transform.position.z);
        GameObject atilanOk = Instantiate(arrow,okunPozisyonu,Quaternion.identity);
        atilanOk.GetComponent<Rigidbody2D>().velocity = new Vector2(okunHizi,okunDusmeHizi);
        
        }else if(transform.localScale.x < 0){

        Vector3 okunPozisyonu = new Vector3(transform.position.x-0.5f,transform.position.y,transform.position.z);
        GameObject atilanOk = Instantiate(arrow,okunPozisyonu,Quaternion.identity);
            
        //okun yonunu degistiriyorum
        Vector3 okunYonu = atilanOk.transform.localScale;
        atilanOk.transform.localScale = new Vector3(-okunYonu.x,okunYonu.y,okunYonu.z);
        atilanOk.GetComponent<Rigidbody2D>().velocity = new Vector2(-okunHizi,okunDusmeHizi);

        }
    }

    private void die(){
        
        //arka plan müziğini kapatıyorum
        sourceController.clip = null;
        //oyuncunun ölme sesini çalıyorum
        sourceController.PlayOneShot(playerDieMusic,1f);

        //başka bir animasyona gecmesin diye hızını sıfırlıyorum
        myAnimator.SetFloat("speed",0);

        //ölme animasyonunu oynatıyorum
        myAnimator.SetTrigger("die");

        //kullanıcıyı hareket yeteneklerini iptal ediyorum artık haraket edemez
        myBody.constraints = RigidbodyConstraints2D.FreezeAll;

        //bu sınıfı aktiflikten pasife geçiyorum artık proje için böyle bir sınıf yok
        enabled = false;

    }


   
}
