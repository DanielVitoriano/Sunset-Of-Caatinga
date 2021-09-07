using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_shoot : MonoBehaviour
{
    public GameObject bullet;
    public Light light_shoot;
    public Transform bullet_spawn;
    private bool shoot = false;
    private Animator anim;
    private SpriteRenderer sprite;
    private Player_move move_Script;
    private Vector3 angle, position;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        move_Script = GetComponent<Player_move>();
        light_shoot.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && !shoot){
            shooting();
        }
        anim.SetBool("shoot", shoot);
    }

    public void shooting(){
        set_angle();
        shoot = true;
        move_Script.enabled = false;
        StartCoroutine(syncronize_trigger(0.15f));
        StartCoroutine(anim_end(0.6f));
    }

    IEnumerator anim_end(float time){
        yield return new WaitForSeconds(time);
        move_Script.enabled = true;
        shoot = false;
    }
    IEnumerator Light_shoot(float time){
        yield return new WaitForSeconds(time);
        light_shoot.enabled = false;
    }
    IEnumerator syncronize_trigger(float time){
        yield return new WaitForSeconds(time);
        light_shoot.enabled = true;
        Instantiate(bullet, bullet_spawn.position, bullet_spawn.rotation);
        StartCoroutine(Light_shoot(0.1f));
    }

    private void set_angle(){
        float x = anim.GetFloat("horizontal_idle");
        float y = anim.GetFloat("vertical_idle");
        bullet_spawn.position = transform.position;
        //direita
        if(x == 1 && y == 0){
            angle = new Vector3(0f, 0f, 90f);
            position = new Vector3(0.435f, -0.095f, -0.7f);
            sprite.flipX = false;
        }
        //esquerda
        else if(x == -1 && y == 0){
            angle = new Vector3(0f, 0f, 270f);
            position = new Vector3(-0.435f, -0.095f, -0.7f);   
            sprite.flipX = true;    
        }
        //front
        else if(x == 0 && y == -1){
            angle = new Vector3(0f, 0f, 0f);
            position = new Vector3(-0.191f, -0.363f, -0.7f);
            sprite.flipX = false;
        }
        //back
        else if(x == 0 && y == 1){
            angle = new Vector3(0f, 0f, 180f);
            position = new Vector3(0.159f, 0.307f, -0.7f);  
            sprite.flipX = false;    
        }
        //diagonal 1
        else if(x == 1 && y == -1){
            angle = new Vector3(0f, 0f, 45f);
            position = new Vector3(0.141f, -0.343f, -0.7f);  
            sprite.flipX = false;    
        }
        //diagonal 2
        else if(x == 1 && y == 1){
            angle = new Vector3(0f, 0f, 125f);
            position = new Vector3(0.352f, 0.142f, -0.7f);
            sprite.flipX = false;
        }
         //diagonal 1 invertida
        else if(x == -1 && y == -1){
            angle = new Vector3(0f, 0f, 315f);
            position = new Vector3(-0.13f, -0.33f, -0.7f);  
            sprite.flipX = true;    
        }
        //diagonal 2 invertida
        else if(x == -1 && y == 1 ){
            angle = new Vector3(0f, 0f, 225f);
            position = new Vector3(-0.362f, 0.142f, -0.7f); 
            sprite.flipX = true;        
        }
        else{
            //default front
            angle = new Vector3(0f, 0f, 0f);
            position = new Vector3(-0.191f, -0.363f, -0.7f);
            sprite.flipX = false;
        }
        bullet_spawn.eulerAngles = angle;
        bullet_spawn.position += position;
    }

}
