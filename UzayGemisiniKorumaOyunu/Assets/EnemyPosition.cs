using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPosition : MonoBehaviour
{
    // Start is called before the first frame update

    //oyun başladığında düşmanın nerde oluşacağını görmek için çiziyorum
    private void OnDrawGizmos(){

        Gizmos.DrawWireSphere(transform.position,1);

    }

}
