using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    public float countDownTime = 5;
    public GameObject go ;
    // Update is called once per frame
   public void Update()
    {
        if(countDownTime < 0)
        {
            countDownTime = 0;
        }

       if( go.GetComponent<PlayerMovement>().moveSpeed != 7f && countDownTime > 0)
        {
            countDownTime -= 1 * Time.deltaTime;
        }

       if(countDownTime == 0)
        {
            go.GetComponent<PlayerMovement>().moveSpeed = 7f;
            countDownTime = 5;
        }
        
    }
}