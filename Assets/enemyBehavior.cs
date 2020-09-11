using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehavior : MonoBehaviour
{
    public bool isLookingRight;
    public float speed;
    public Transform groundCheck;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, 2f);
        if(hit.collider == null){
            speed *= -1;
            // Vector3 angles = transform.rotation.eulerAngles;
            // if(isLookingRight)
            //     angles.y = 180;
            // else
            //     angles.y = 0;
            // transform.eulerAngles = angles;
            // isLookingRight = !isLookingRight;

            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }

        transform.position = transform.position + new Vector3(speed* Time.deltaTime,0,0);
    }

    void OnTriggerEnter2D(Collider2D collider){
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag.Equals("Player")){
            Debug.Log("enemy died");
            Destroy(this.gameObject);
        }
    }
}
