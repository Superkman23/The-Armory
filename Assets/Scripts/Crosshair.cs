using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
  SpriteRenderer _Renderer;

  private void Awake()
  {
    
  }

  private void Update()
  {
    Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    targetPosition.z = transform.position.z;
    transform.position = targetPosition;
  }
}
