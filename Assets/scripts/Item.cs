using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    // Start is called before the first frame update
    protected virtual void Start()
    {
    }


    public Player Player {get;set;} = null;
    
    protected virtual void OnUse(Player player) {

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

}