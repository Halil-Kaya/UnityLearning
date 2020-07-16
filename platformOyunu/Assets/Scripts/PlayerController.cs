using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update


    //hızım
    private float mySpeedX;
    //vicudum
    private Rigidbody2D myBody;
    //unity den verdigim hızım
    [SerializeField] float speed = 1;
    [SerializeField] float jumpPower;
    [SerializeField] GameObject arrow;
    [SerializeField] float arrowSpeed = 5;
    [SerializeField] float currentAttackTimer;
    [SerializeField] float defaultAttackTimer;
    [SerializeField] int okSayisi;
    [SerializeField] AudioClip dieMusic;
    [SerializeField] Text arrowCount;
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject losePanel;

    public bool onGround;
    private bool canDoubleJump;
    private Vector3 defaultLocalScale;
    private bool attacked;
    private Animator myAnimator;


    void Start()
    {
        arrowCount.text = okSayisi.ToString();
        myAnimator =GetComponent<Animator>(); 
        myBody = GetComponent<Rigidbody2D>();
        defaultLocalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.GetAxis("Horizontal"));
        mySpeedX = Input.GetAxis("Horizontal");

        myAnimator.SetFloat("speed",Mathf.Abs(mySpeedX));

        #region sag sola haraket etme
        myBody.velocity = new Vector2(mySpeedX * speed, myBody.velocity.y);
        if (mySpeedX > 0)
        {
            transform.localScale = new Vector3(defaultLocalScale.x, defaultLocalScale.y, defaultLocalScale.z);
        }
        else if (mySpeedX < 0)
        {
            transform.localScale = new Vector3(-defaultLocalScale.x, defaultLocalScale.y, defaultLocalScale.z);
        }
        #endregion


        #region ziplama
        if(Input.GetKeyDown(KeyCode.Space)){
            if(onGround){
            myBody.velocity = new Vector2(myBody.velocity.x,jumpPower);
            canDoubleJump = true;   
            myAnimator.SetTrigger("jump");
            }else{
                if(canDoubleJump){
                    myBody.velocity = new Vector2(myBody.velocity.x,jumpPower);
                    canDoubleJump = false;
                }
            }
        }
        #endregion



        #region ok atma kontrolu

        if(Input.GetMouseButtonDown(0)){
            
            if(attacked == false && okSayisi > 0){
                myAnimator.SetTrigger("attack");
                Invoke("okAt",0.5f);
                attacked = true;

            }


        }
        
        if(attacked){
            currentAttackTimer -= Time.deltaTime;
        }else{
            currentAttackTimer = defaultAttackTimer;
        }

        if(currentAttackTimer<=0){
            attacked = false;
        }

        #endregion

    }

    private void okAt(){

            GameObject myArrow = Instantiate(arrow,transform.position,Quaternion.identity);
            myArrow.transform.parent = GameObject.Find("Arrows").transform;

            if(transform.localScale.x > 0){
                myArrow.GetComponent<Rigidbody2D>().velocity = new Vector2(arrowSpeed,0f);
            }else{
                myArrow.transform.localScale = new Vector3(-myArrow.transform.localScale.x,myArrow.transform.localScale.y,myArrow.transform.localScale.z);
               myArrow.GetComponent<Rigidbody2D>().velocity = new Vector2(-arrowSpeed,0f);
            }
        
        okSayisi--;
        arrowCount.text = okSayisi.ToString();
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        
        if(other.gameObject.tag == "Enemy"){
            GetComponent<TimeController>().enabled = false;
            die();
        }else if(other.gameObject.tag == "FinishCoin"){
            Destroy(other.gameObject);
            StartCoroutine(Wait(true,0.2f));
        }

    }

    public void die(){

        GameObject.Find("SoundController").GetComponent<AudioSource>().clip = null;
        GameObject.Find("SoundController").GetComponent<AudioSource>().PlayOneShot(dieMusic);
        myAnimator.SetFloat("speed",0);
        myAnimator.SetTrigger("die");
        myBody.constraints = RigidbodyConstraints2D.FreezeAll;
        enabled = false;
        StartCoroutine(Wait(false,2));
    }

    IEnumerator Wait(bool win,float beklemeSuresi){

        yield return new WaitForSecondsRealtime(beklemeSuresi);
        
        if(win){
            winPanel.SetActive(true);
        }else{
            Time.timeScale = 0;
            losePanel.SetActive(true);
        }


    }

}
