using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeController : MonoBehaviour
{


    [SerializeField] Text timeValue;
    [SerializeField] float time;

    private bool karakterYasiyorMu;
    // Start is called before the first frame update
    void Start()
    {
        timeValue.text = time.ToString();
        karakterYasiyorMu = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(karakterYasiyorMu){

            time -= Time.deltaTime;
            timeValue.text = ((int)time).ToString();

            if(time < 0){
                GetComponent<PlayerController>().die();
                karakterYasiyorMu = false;
            } 

        }

    }
}
