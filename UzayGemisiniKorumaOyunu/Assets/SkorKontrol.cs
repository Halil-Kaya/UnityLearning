using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkorKontrol : MonoBehaviour
{

    private int skor = 0;
    private Text SkorText;

    void Start()
    {
        SkorText = GetComponent<Text>();
        skoruSifirla();
    }

    public void skorAttir(int puan){

        skor += puan;
        SkorText.text = skor.ToString();

    }

    public void skoruSifirla() {
        skor = 0;
        SkorText.text = "0";
    }

}
