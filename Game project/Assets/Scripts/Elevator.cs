using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Transform DestinationSpot;
    public Transform OriginSpot;
    public float speed;
    public bool Switch = false;
    public Player player;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        if (transform.position == DestinationSpot.position)
        {
            Switch = true;
        }
        if (transform.position == OriginSpot.position)
        {
            Switch = false;
        }

        if (Switch)
        {
            yield return new WaitForSeconds(3.0f);
            transform.position = Vector3.MoveTowards(transform.position, OriginSpot.position, speed * Time.deltaTime);
        }
        else
        {
            yield return new WaitForSeconds(3.0f);
            transform.position = Vector3.MoveTowards(transform.position, DestinationSpot.position, speed * Time.deltaTime);
        }
    }

    /*
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.transform.SetParent(other.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.transform.SetParent(null);
        }
    }
    */
}

