using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SahneKontrolu : MonoBehaviour
{

    public void sonrakiSahne(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void sahneyeGit(string sahneAdi) {
        SceneManager.LoadScene(sahneAdi);
   }

    public void oyunSahnesineGit(){
        SceneManager.LoadScene("Level_01");
    }

    public void oyundanCik() {
        Application.Quit();
    }


    public void menuyeDon(){
        SceneManager.LoadScene(0);
    }

}
