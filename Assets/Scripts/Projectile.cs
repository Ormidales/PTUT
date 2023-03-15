using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{



    [field:SerializeField]
    public float Speed {get;set;}= 1.0f;

    Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D collision) {
        Destroy(transform.GetChild(0).gameObject);
        Destroy(this.gameObject);
        collision.gameObject.GetComponent<Entity>().Damage(5,null);
    }

    // Update is called once per frame
    void Update()
    {

        var vec = Quaternion.Euler(0,0,gameObject.transform.rotation.z) * new Vector2(0,Speed);
        print(gameObject.transform.rotation.z);
        body.MovePosition(body.position + new Vector2(vec.x,vec.y));
    }
}
