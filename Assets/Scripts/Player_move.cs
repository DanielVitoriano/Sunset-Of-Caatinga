using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour
{

    private Animator anim;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);

        anim.SetFloat("x", movement.x);
        anim.SetFloat("y", movement.y);
        anim.SetFloat("speed", movement.magnitude);

        transform.position += movement * Time.deltaTime * speed;
        
        if(movement.x < 0){
            transform.eulerAngles = new Vector3(0, -180, 0);
        }
        else{
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        //baixo
        if(movement.x == 0 && movement.y == -1){
            anim.SetInteger("side", 0);
        }
        //cima
        else if(movement.x == 0 && movement.y == 1){
            anim.SetInteger("side", 1);
        }

        //angulo 1
        else if(movement.x == 1 || movement.x == -1 && movement.y == -1){
            anim.SetInteger("side", 2);
        }
        //ang 2
        else if(movement.x == 1 || movement.x == -1 && movement.y == 1){
            anim.SetInteger("side", 3);
        }

        //direita ou esquerda
        else if(movement.x == 1 || movement.x == -1 && movement.y == 0){
            anim.SetInteger("side", 4);
        }
    }
}
