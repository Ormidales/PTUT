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



    public Player player;

    [field:SerializeField]
    public int Cooldown {get;set;}

    int cooldown = 10;


    public virtual bool Fire(Vector3 direction) {


        if(cooldown == 0) {
            Instantiate(Projectile, player.gameObject.transform.position + direction, Quaternion.AngleAxis(90,new Vector3(0,0,1))).GetComponent<Projectile>().Direction = direction;





            cooldown = Cooldown;
        }

        return true;
    }


    [field:SerializeField]
    public GameObject Projectile {get;set;}

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if(cooldown >= 1) {
            cooldown--;
        }
    }
}