using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_live : MonoBehaviour
{
    public int lifes;
    private Animator anim;
    private Player_move player_move;
    private Player_shoot player_shoot;
    private CapsuleCollider2D player_coll;
    void Start()
    {
        anim = GetComponent<Animator>();
        player_coll = GetComponent<CapsuleCollider2D>();
        player_move = GetComponent<Player_move>();
        player_shoot = GetComponent<Player_shoot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void damage(){
        lifes --;
        if(lifes <= 0){
            player_coll.enabled = false;
            player_shoot.enabled = false;
            player_move.enabled = false;
        }
        else{
            anim.Play("hit");
        }
    }

}
