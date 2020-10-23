using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
  Camera _Camera;

  [SerializeField] Transform _TargetPosition;
  [SerializeField] [Range(0, 1)] float _LerpSpeed;

  private void Awake()
  {
    _Camera = GetComponent<Camera>();
  }
  private void FixedUpdate()
  {
    Vector3 targetPos = Vector3.Lerp(transform.position, _TargetPosition.position, _LerpSpeed);
    targetPos.z = transform.position.z;
    transform.position = targetPos;
  }


}
