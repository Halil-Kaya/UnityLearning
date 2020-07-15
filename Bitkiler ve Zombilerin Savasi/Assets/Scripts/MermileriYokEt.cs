using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MermileriYokEt : MonoBehaviour
{
    //mermileri yok eden bölgenini sahip olduğu script<program>
    //mermiler sahnenin dışına çıktığında mermileri yok etmem lazım
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //mermiler sahnenin dışında bulunan Mermileri yok eden bölge objesinin colliderına girerse bu fonksiyon çalışacak böylece
        //mermiyi yok etmiş olucam
        Destroy(collision.gameObject);

    }

}
