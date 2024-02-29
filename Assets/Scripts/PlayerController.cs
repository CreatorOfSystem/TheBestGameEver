using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float gravity = 9.8f;
    public float jumpForce;
    public float speed;

    private CharacterController _characterController;
    private float _fallVelocity = 0;
    private Vector3 _moveVector;
    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }
    void Update()
    {   //move
        _moveVector = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
        }

        if (_moveVector != Vector3.zero)
        {
            animator.SetBool("isRun", true);
        }
        else
        {
            animator.SetBool("isRun", false);
        }





        //jump
        if (Input.GetKeyDown(KeyCode.Space)&&(_characterController.isGrounded))
        {
            _fallVelocity=-jumpForce;
            animator.SetBool("isGrounded", false);
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {//move
        _characterController.Move(_moveVector * speed * Time.deltaTime);

        //fall
        _fallVelocity += gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _fallVelocity * Time.deltaTime);
        if (_characterController.isGrounded)
        {
            _fallVelocity = 0;
            animator.SetBool("isGrounded", true);
        }
    }
   
}