using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlindnessDebuff : MonoBehaviour
{
    private GameObject myImage;
    private Image img;
    // Start is called before the first frame update
    void Start()
    {
       img.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>() != null)
        {
            Destroy(gameObject);
            img.gameObject.SetActive(true);
        }
    }
}
