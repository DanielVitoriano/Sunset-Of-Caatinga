using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int damage;
    private float life = 10f;
    private Vector2 init_pos;
    private Light bullet_light;
    void Start(){
        init_pos = transform.position;
        bullet_light = GetComponent<Light>();
        bullet_light.enabled = true;
        transform.position += new Vector3(0f, 0f, -0.5f);
    }
    void Update()
    {
        if(Vector2.Distance(init_pos, transform.position) >= life){
            Destroy(gameObject);
        }
        bullet_light.intensity = Random.Range(0.2f, 1f);
    }
    void FixedUpdate() {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.layer == 8){
            other.GetComponent<Enemy>().Damage(damage);
            Destroy(gameObject);
        }
        else if(other.gameObject.layer == 6){}
        else{
            Destroy(gameObject);
        }

    }

}