using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
  SpriteRenderer _Renderer;
  [SerializeField] float _RotateSpeed;
  private void Update()
  {
    Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    targetPosition.z = transform.position.z;
    transform.position = targetPosition;
    transform.Rotate(new Vector3(0, 0, _RotateSpeed * Time.deltaTime));
  }
}
