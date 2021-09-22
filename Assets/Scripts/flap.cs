using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flap : MonoBehaviour
{

    public CapsuleCollider2D player_coll;
    public BoxCollider2D flap1, flap2;

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreCollision(flap1, player_coll, true); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
