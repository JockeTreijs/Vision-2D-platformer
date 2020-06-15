using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 2.0f;
    [SerializeField]
    private Vector2 jumpHeight;
    public bool isGrounded;
    public int scriptPart;
    public Player player;

    public Vector3 Vector3 { get; private set; }
    private Vector3 characterScale;
    public GameObject character;
    private SpriteRenderer characterExample;

    // Start is called before the first frame update
    void Start()
    {
        isGrounded = false;
        character = GameObject.Find("Character");
        characterExample = character.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (scriptPart == 1)
        {
            CalculateMovement();
            Jump();
        }
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 direction = new Vector2(horizontalInput, 0);
        transform.Translate(direction * Time.deltaTime * speed);
        
        //transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0);

        Vector3 = characterScale = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0)
        {
            characterExample.flipX = true;
        }
        Vector3 = characterScale = transform.localScale;
        if (Input.GetAxis("Horizontal") > 0)
        {
            characterExample.flipX = false;
        }
        transform.localScale = characterScale;
        
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9 && scriptPart == 2)
        {
            player.isGrounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9 && scriptPart == 2)
        {
            player.isGrounded = false;
        }
    }
}