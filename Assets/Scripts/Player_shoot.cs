using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_shoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform pos_bullet_spawn;
    private bool shoot = false;
    private Animator anim;
    private Vector2 direction;
    private Player_move move_Script;

    // Start is called before the first frame update
    void Start()
    {
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
        shoot = true;
        move_Script.enabled = false;
        direction = move_Script.getMoviment();
        Instantiate(bullet, pos_bullet_spawn.position, transform.rotation);
        StartCoroutine(anim_end(0.6f));

    }

    IEnumerator anim_end(float time){
        yield return new WaitForSeconds(time);
        move_Script.enabled = true;
        shoot = false;
    }
}
