
using UnityEngine;

public class PlanObject : MonoBehaviour
{
    public Transform layer;
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sortingOrder=0-(int)(transform.position.y*10)+100;
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.sortingOrder=0-(int)(layer.position.y*10)+100;
    }
}
