using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sun : MonoBehaviour
{
    public float speed;
    private Animator the_sun;
    void Start()
    {
        the_sun = GetComponent<Animator>();
        the_sun.speed = speed;
        the_sun.Play("sun");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
