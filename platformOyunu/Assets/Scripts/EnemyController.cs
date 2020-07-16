using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField] bool onGround;
    private float width;
    private Rigidbody2D myBody;
    [SerializeField] LayerMask engel;
    [SerializeField] float speed;

    private static int totalEnemyNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        totalEnemyNumber++; 
        width = GetComponent<SpriteRenderer>().bounds.extents.x;
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + (transform.right * width / 2), Vector2.down, 2f, engel);

        if (hit.collider != null)
        {
            onGround = true;
        }
        else
        {
            onGround = false;
        }

        Flip();

    }

    private void Flip()
    {
        if (!onGround)
        {
            transform.eulerAngles += new Vector3(0f, 180f, 0f);
        }

        myBody.velocity = new Vector2(transform.right.x * speed, 0f);

    }

    private void OnDrawGizmos()
    {
        width = GetComponent<SpriteRenderer>().bounds.extents.x;
        Gizmos.color = Color.red;
        Vector3 playerRealPozisition = transform.position + (transform.right * width / 2);
        Gizmos.DrawLine(playerRealPozisition, playerRealPozisition + new Vector3(0, -2f, 0));
    }

}
