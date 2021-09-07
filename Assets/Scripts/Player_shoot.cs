using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_shoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform pos_bullet_spawn;
    private bool shoot = false;
    private Animator anim;
    private SpriteRenderer sprite;
    private Vector2 direction;
    private Player_move move_Script;
    private Vector3 angle;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        move_Script = GetComponent<Player_move>();
        //pos_bullet_spawn = GetComponentInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            shooting();
        }
        anim.SetBool("shoot", shoot);
    }

    public void shooting(){
        set_angle();
        shoot = true;
        move_Script.enabled = false;
        direction = move_Script.getMoviment();
        Instantiate(bullet, pos_bullet_spawn.position, pos_bullet_spawn.rotation);
        StartCoroutine(anim_end(0.6f));

    }

    IEnumerator anim_end(float time){
        yield return new WaitForSeconds(time);
        move_Script.enabled = true;
        shoot = false;
    }

    private void set_angle(){
        float x = anim.GetFloat("horizontal_idle");
        float y = anim.GetFloat("vertical_idle");
        //direita
        if(x == 1 && y == 0){
            angle = new Vector3(0f, 0f, 90f);
            pos_bullet_spawn.position += new Vector3(0.069f, 0, 0);
        }
        //esquerda
        else if(x == 1 && y == 0 && sprite.flipX == true){
            angle = new Vector3(0f, 0f, 270f);
            pos_bullet_spawn.position -= new Vector3(0.069f, 0, 0);
        }
        //baixo
        else if(x == 0 && y == -1){
            angle = new Vector3(0f, 0f, 0f);
        }
        //cima
        else if(x == 0 && y == 1){
            angle = new Vector3(0f, 0f, 180f);
        }
        //diagonal 1
        else if(x == 1 && y == -1){
            angle = new Vector3(0f, 0f, 45f);
        }
        //diagonal 2
        else if(x == 1 && y == 1){
            angle = new Vector3(0f, 0f, 125f);
        }
         //diagonal 1 invertida
        else if(x == 1 && y == -1 && sprite.flipX == true){
            angle = new Vector3(0f, 0f, 315f);
        }
        //diagonal 2 invertida
        else if(x == 1 && y == 1 && sprite.flipX == true){
            angle = new Vector3(0f, 0f, 225f);
        }
        else{
            print("tem coisa errada ia irmão");
        }
        pos_bullet_spawn.eulerAngles = angle;
    }

}
