using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  Rigidbody2D _Rigid;
  [Header("Movement")]
  [SerializeField] float _WalkSpeed;
  [SerializeField] float _WalkAcceleration;
  [SerializeField] float _SprintAcceleration;
  [SerializeField] float _SprintSpeed;

  [Header("Items")]
  public Crosshair _Crosshair;
  public Item _EquippedItem;

  private void Awake()
  {
    //TODO: move to the function where an item is actually picked up
    _EquippedItem.Equip(this);

    _Rigid = GetComponent<Rigidbody2D>();
  }

  private void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
      _EquippedItem.Use();
    }
  }


  private void FixedUpdate()
  {
    ApplyMovement();
  }

  private void ApplyMovement()
  {
    Vector2 input = GetInput().normalized;
    input *= Input.GetKey(KeyCode.LeftShift) ? _SprintSpeed : _WalkSpeed;
    input -= _Rigid.velocity;
    float acceleration = Input.GetKey(KeyCode.LeftShift) ? _SprintAcceleration * Time.deltaTime : _WalkAcceleration * Time.deltaTime;
    input.x = Mathf.Clamp(input.x, -acceleration, acceleration);
    input.y = Mathf.Clamp(input.y, -acceleration, acceleration);
    _Rigid.velocity += input;
  }

  public void AddForce(Vector2 force)
  {
    _Rigid.velocity += force;
  }
  public void SetForce(Vector2 force)
  {
    _Rigid.velocity = force;
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
