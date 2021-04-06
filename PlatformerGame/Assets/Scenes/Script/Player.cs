using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform GroundChecker;
    public float groundredui = 0.2f;
    public LayerMask groundLayer;
    private float moveSpeed=5.0f;
    private float jumpPower = 10.0f;

    private Animator anim;



    private Rigidbody2D rigid;
    bool isGround = true;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            anim.SetBool("IsAttack",true);
            SoundManager.instance.AttackSound();

            Collider2D col = Physics2D.OverlapCircle(transform.position, 5, (1 << LayerMask.NameToLayer("Enemy")));

            if (col != null)
            {
                col.GetComponent<Enemy>().Die();
            }

        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            anim.SetBool("IsAttack", false);
        }
        isGround = Physics2D.OverlapCircle(GroundChecker.position, groundredui, groundLayer);
       
    }
    void FixedUpdate()
    {
        Move();
        Jump();
    }
    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.W)&&isGround){
            rigid.AddForce(Vector2.up*jumpPower,ForceMode2D.Impulse);
            isGround=false;
        }
    }
    void Move(){
        float posX = Input.GetAxis("Horizontal");
        if (posX != 0)
        {
            if (posX >= 0)
                transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        transform.Translate(Mathf.Abs(posX) * Vector3.right * moveSpeed * Time.deltaTime);
    }

}
