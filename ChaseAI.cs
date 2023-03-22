using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseAI : MonoBehaviour
{
    public GameObject target;

    public float speed;

    private float distance;

    public static ChaseAI instance;
    private bool chaseActive=true;

    public void setChaseActive(bool boolean)
    {
        chaseActive=boolean;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (chaseActive)
        {
            distance = Vector2.Distance(transform.position, target.transform.position);

            var direction = target.transform.position - transform.position;

            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
        
    }


}
