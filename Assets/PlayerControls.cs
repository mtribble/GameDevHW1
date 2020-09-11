using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float jumpVel = 10f;
    private PolygonCollider2D pc;
    public LayerMask platformMask;
    public float speed = 5f;
    private Vector3 respawnPt;

    private int jumpCount;
    public static float health = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pc = GetComponent<PolygonCollider2D>();
        respawnPt = transform.position;
        jumpCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        //Debug.Log(horizontalInput.ToString());
        //float verticalInput = Input.GetAxis("Vertical");

        //hprizontal move
        transform.position = transform.position + new Vector3(horizontalInput* speed * Time.deltaTime, 0, 0);

        //Jump
        if(Input.GetKeyDown(KeyCode.Space)){
            //Debug.Log("Jump");  
            if(isOnGround()){
                rb.velocity = Vector2.up * jumpVel;
                jumpCount = 0;
            }
            else{
                //double jump
                if(jumpCount < 1){
                    rb.velocity = Vector2.up * jumpVel;
                    jumpCount++;
                }
            }
            
        }
    }
    private bool isOnGround(){
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(pc.bounds.center, pc.bounds.size, 0f, Vector2.down, 0.1f, platformMask);
        return raycastHit2d.collider != null;
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if("Enemy".Equals(collision.gameObject.tag)){
            health = health - 0.5f;
        }

        if("Mask".Equals(collision.gameObject.tag)){
            health = health + 0.5f;
        }

        if("Respawn".Equals(collision.gameObject.tag) || health < 0.01f){
            Debug.Log("Respawn");
            transform.position = respawnPt;
            health = 1f;
        }
    }
}
