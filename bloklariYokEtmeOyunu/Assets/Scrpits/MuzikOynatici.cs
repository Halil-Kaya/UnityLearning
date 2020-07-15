using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzikOynatici : MonoBehaviour
{

    static MuzikOynatici muzikOynatici = null;

    // Start is called before the first frame update
    void Start(){
        
        if(muzikOynatici != null){
            Destroy(gameObject);
        }else{

            muzikOynatici = this;
            GameObject.DontDestroyOnLoad(gameObject);

        }
        

    }


}
