using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int points_of_life;
    //public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(points_of_life <= 0){
            Destroy(gameObject);
        }
    }

    public void Damage(int damage){
        print("dano");
        points_of_life -= damage;
    }
}
