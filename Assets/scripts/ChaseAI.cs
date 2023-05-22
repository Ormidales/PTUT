using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseAI : MonoBehaviour
{
    public GameObject target;

    public float speed;

    public Enemy enemy;

    private float distance;



    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
  
        distance = Vector2.Distance(transform.position, target.transform.position);

        var direction = target.transform.position - transform.position;

        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        
        
        var sc = transform.localScale;

        var flip = direction.x < 0;

        if (flip != enemy.Flipped)
        {

            transform.localScale = new Vector3(sc.x * -1, sc.y, sc.z);

            enemy.Flipped = flip;

        }
        
    }


}
