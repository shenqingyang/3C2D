using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed;
    public float jumpHeight;
    private Vector3 moveDir;
    Rigidbody2D rb;
    bool jumpPressed;
    public int jumpNum=2;
    public static bool isDefault;
    public GameObject key_forward;
    public GameObject key_back;
    public GameObject key_jump;
    Animator anim;
    public GameObject test;

    public GameObject cam;
    public float x;
    public float y;
    // Start is called before the first frame update
    void Awake()
    {
       test = new GameObject("test");
        Sprite spr = Resources.Load<Sprite>("test");
        test.AddComponent<SpriteRenderer>().sprite = spr;
         rb = transform.GetComponent<Rigidbody2D>();
        anim = transform.GetComponent<Animator>();
        isDefault=true;
        test.GetComponent<SpriteRenderer>().sortingLayerName = "map";
        cam.GetComponent<camera>().ChangScale(test.GetComponent<SpriteRenderer>(),x,y);
    }
    // Update is called once per frame
    void Update()
    {
        if (isDefault)
            move_default();
        else
            move_defined();

        switchAnim();
    }

    void move_default()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            jumpPressed = true;
        }
        if (jumpPressed&&jumpNum>0) {
            rb.velocity = new Vector3(rb.velocity.x,jumpHeight);
            jumpNum--;
        }
        jumpPressed = false;
        moveDir = new Vector3(horizontal *speed, rb.velocity.y);
        rb.velocity = moveDir;
        if (horizontal != 0)
        {
            transform.localScale = new Vector3(horizontal,1,1);
        }
    }

    void move_defined()
    {
        float horizontal=0;
        if (Input.GetKeyDown(key_jump.GetComponent<key>().Key)){
            jumpPressed = true;
        }

        if (Input.GetKey(key_forward.GetComponent<key>().Key)){
            horizontal = 1;
        }
        if (Input.GetKey(key_back.GetComponent<key>().Key)){
            horizontal = -1;
        }

        if (jumpPressed && jumpNum > 0)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpHeight);
            jumpNum--;
        }
        jumpPressed = false;

        moveDir = new Vector3(horizontal * speed, rb.velocity.y);
        rb.velocity = moveDir;

        if (horizontal != 0)
        {
            transform.localScale = new Vector3(horizontal, 1, 1);
        }
    }

    void switchAnim()
    {
        if (rb.velocity.y==0)
        {
            anim.SetBool("jump", false);
            anim.SetBool("fall", false);
            anim.SetFloat("run",Mathf.Abs(rb.velocity.x));
        }else if (rb.velocity.y < 0)
        {
            anim.SetFloat("run", 0);
            anim.SetBool("jump", false);
            anim.SetBool("fall", true);
        }else if (rb.velocity.y > 0)
        {
            anim.SetFloat("run", 0);
            anim.SetBool("jump", true);
            anim.SetBool("fall", false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("0");
        if (collision.transform.tag == "ground")
        {
            jumpNum = 2;
            Debug.Log("2");
        }
    }
}
