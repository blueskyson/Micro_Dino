using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class fox_move : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    public float speed = 5f;
    public float jumpforce = 500;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {

        _rigidbody = GetComponent<Rigidbody2D>();
        animator.SetInteger("status", 1);

    }

    // Update is called once per frame
    void Update()
    {
        if (_rigidbody.velocity.y > 0)
        {
            animator.SetInteger("status", 3);
        }
        else if(_rigidbody.velocity.y < 0)
        {
            animator.SetInteger("status", 5);
        }
        else
        {
            animator.SetInteger("status", 1);
        }
        var movement = Input.GetAxis("Horizontal");
        //transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * speed;
        ////down in the air
        if (Input.GetKey(KeyCode.S) && Mathf.Abs(_rigidbody.velocity.y) > 0)
        {
            animator.SetInteger("status", 5);
            transform.position += new Vector3(0, 1, 0) * Time.deltaTime * -speed;
        }
        //down on the land
        else if (Input.GetKey(KeyCode.S))
        {
            animator.SetInteger("status", 2);
            transform.localScale = new Vector3(13.6f, 8.6f, 1);
            transform.position += new Vector3(0, 1, 0) * Time.deltaTime * -speed;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            transform.localScale = new Vector3(13.6f, 13.6f, 1);
        }
        //left
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetInteger("status", 1);
            transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * speed;
        }
        ////right
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetInteger("status", 1);
            transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * speed;
        }
        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W)) && _rigidbody.velocity.y == 0)
        {
            Debug.Log("jmp");
            _rigidbody.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
        }
        
        //if (Input.GetKey(KeyCode.S))
        //{
        //    animator.SetInteger("status", 2);
        //    _rigidbody.AddForce(new Vector2(0, -jumpforce / 3), ForceMode2D.Impulse);
        //}

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "obstacle")
        {
            Debug.Log("collitoin");
        }
    }
}
