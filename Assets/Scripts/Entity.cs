using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Entity : MonoBehaviour
{


    public int HurtTime {get;set;}

    public bool Flipped {get;set;}

    public GameObject Object {get;private set;}



    [field:SerializeField]
    public int HealthTop {get;set;} = 100;

    private int health = 1;

    public int Health {get {
        return health;
    }
    
    set {
        health = Math.Min(value,HealthTop);
    }}

    


    public virtual void Damage(int value,Entity from) {
        health -= value;
        if(health <= 0) {
            Die();
        }
    }


        public virtual void Die() {

            Destroy(this.gameObject);
            

        }


    public virtual void Tick() {

    }


    


    // Start is called before the first frame update
   protected virtual void Start()
    {
        Health = HealthTop;
        Object = gameObject;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Tick();
    }
}
