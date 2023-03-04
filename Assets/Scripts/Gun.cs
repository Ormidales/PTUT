using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }


    [field:SerializeField]
    public int Cooldown {get;set;}

    int cooldown = 0;


    public virtual bool Fire(Vector2 direction) {


        if(cooldown == 0) {
            Instantiate(Projectile,transform.position,Quaternion.identity);

            cooldown = Cooldown;
        }

        return true;
    }

    public Projectile Projectile {get;set;}

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if(cooldown >= 1) {
            cooldown--;
        }
    }
}
