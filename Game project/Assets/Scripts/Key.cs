using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public bool gotKey;
    public GameObject invisiblePlatform;

    // Start is called before the first frame update
    void Start()
    {
        invisiblePlatform.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.gameObject.transform.position = new Vector2(-12, -7);
            invisiblePlatform.gameObject.SetActive(true);
            gotKey = true;
        }
    }
}
