using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour
{

    private SpriteRenderer sprite;
    public Camera cam;
    private Animator anim;
    private Rigidbody2D playerRb;
    private Vector2 moviment,mousePos;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody2D>();
    }
    void Update(){
        moviment.x = Input.GetAxisRaw("Horizontal");
        moviment.y = Input.GetAxisRaw("Vertical");

        anim.SetFloat("x", moviment.x);
        anim.SetFloat("y", moviment.y);
        anim.SetFloat("speed", moviment.sqrMagnitude);

        if(moviment != Vector2.zero){
            anim.SetFloat("horizontal_idle", moviment.x);
            anim.SetFloat("vertical_idle", moviment.y);
        }
        //inverter
        if(moviment.x <= -0.1f) {
            sprite.flipX = true;
        }
        else if(moviment.x >= 0.1f){
            sprite.flipX = false;
        }
        //print(enabled);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + moviment.normalized * speed * Time.fixedDeltaTime);
    }

}
