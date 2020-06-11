using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public Transform startPosition;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            new WaitForSeconds(1);
            other.gameObject.transform.position = new Vector2(-12.5f, 4.5f);
        }
    }
}
