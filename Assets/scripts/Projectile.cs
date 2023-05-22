using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Projectile : MonoBehaviour
{



    [field:SerializeField]
    public float Speed {get;set;}= 0.2f;





    [field:SerializeField]
    public bool Bell {get;set;} = false;
    



    


    const int FRAME = 12;

    [field:SerializeField]
    public int Frames {get;set;} = 200;


    [field:SerializeField]
    public int Damage {get;set;} = 25;




    [field:SerializeField]
    public Vector3 Direction {get;set;}= Vector3.left;


    Rigidbody2D body;





    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D collision) {

        

        var et = collision.gameObject.GetComponent<Entity>();
        if(et != null) {
            et.Damage(Damage,null);
        }
        else if(!collision.isTrigger) {

        }
        else {
            return;
            //Debug.LogWarning("Not an entity " + collision.gameObject);
        }
        Destroy(transform.GetChild(0).gameObject);
        Destroy(this.gameObject);
    }



    // Update is called once per frame
    void Update()
    {

        //var vec = Quaternion.Euler(0,0,gameObject.transform.rotation.z) * new Vector2(0,Speed);
        //print(gameObject.transform.rotation.z);
        
        Frames -= 1;


        

        if(Frames < 0) {
            Destroy(this.gameObject);
        }

        
        else {
        


            print(Frames + "f");


            //body.MovePosition(body.position + new Vector2(Direction.x,Direction.y+ Mathf.Cos((1-Frames/FRAME)*Mathf.PI)*2)*Speed);


            if(Bell) {

                body.MovePosition(body.position + new Vector2(Direction.x,Mathf.Cos((1-Frames/FRAME)*Mathf.PI)*2)*Speed);
            }
            else {


                body.MovePosition(body.position + new Vector2(Direction.x,Direction.y+ Mathf.Cos((1-Frames/FRAME)*Mathf.PI)*2)*Speed);


            }
        }
    }
}