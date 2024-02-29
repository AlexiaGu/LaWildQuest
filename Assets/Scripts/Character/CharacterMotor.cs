using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMotor : MonoBehaviour
{
 private PlayerInput inputs;

private InputAction moveAction;
private GameManager manager;

private Vector2 velocity = Vector2.zero;
[SerializeField] private float speed = 5f;

    void Start()
    {
       manager = GameManager.GetInstance(); 
       inputs = manager.GetInputs();

       moveAction = inputs.actions.FindAction("Move");
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
         Vector2 _moveValue = moveAction.ReadValue<Vector2>();
         velocity = _moveValue * speed;

        transform.position += new Vector3(velocity.x * Time.fixedDeltaTime, velocity.y * Time.fixedDeltaTime, 0);
    }
}
