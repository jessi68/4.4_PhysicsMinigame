using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    private InputActions inputActions;
    private Rigidbody rigidBody;

    private int totalScore = 0;
    [SerializeField] private float speed = 1000f;

    // Start is called before the first frame update
    void Awake()
    {
        inputActions = new InputActions();
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      
        Vector2 moveInput = inputActions.Newactionmap.Movement.ReadValue<Vector2>();
        Debug.Log(moveInput);
        rigidBody.velocity = moveInput * speed;

    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<CollidableBall>() != null)
        {
            Debug.Log("player collide with collidable ball");
            totalScore += collision.gameObject.GetComponent<CollidableBall>().getScore();
            Destroy(collision.gameObject);
        }

    }
}
