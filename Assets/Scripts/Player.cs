using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  Rigidbody2D _Rigid;
  [SerializeField] float _MoveSpeed;
  [SerializeField] float _Acceleration;


  private void Awake()
  {
    _Rigid = GetComponent<Rigidbody2D>();
  }
  private void FixedUpdate()
  {
    ApplyMovement();
  }


  private void ApplyMovement()
  {
    Vector2 input = GetInput().normalized;
    Vector2 targetVelocity = input * _MoveSpeed;
    Vector2 velocityChange = targetVelocity - _Rigid.velocity;
    float acceleration = _Acceleration * Time.deltaTime;
    velocityChange.x = Mathf.Clamp(velocityChange.x, -acceleration, acceleration);
    velocityChange.y = Mathf.Clamp(velocityChange.y, -acceleration, acceleration);
    _Rigid.velocity += velocityChange;
  }



  Vector2 GetInput()
  {
    Vector2 input = Vector2.zero;
    if (Input.GetKey(KeyCode.W))
    {
      input.y++;
    }
    if (Input.GetKey(KeyCode.A))
    {
      input.x--;
    }
    if (Input.GetKey(KeyCode.S))
    {
      input.y--;
    }
    if (Input.GetKey(KeyCode.D))
    {
      input.x++;
    }
    return input;
  }

}
