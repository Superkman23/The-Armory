using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
  [SerializeField] Transform _TargetPosition;
  [SerializeField] Transform _CrosshairPosition;
  [SerializeField] [Range(0, 1)] float _LerpSpeed;
  [SerializeField] [Range(0, 0.5f)] float _CrosshairRatio;
  private void FixedUpdate()
  {
    Vector3 targetPos = Vector3.Lerp(_TargetPosition.position, _CrosshairPosition.position, _CrosshairRatio);
    Vector3 newPos = Vector3.Lerp(transform.position, targetPos, _LerpSpeed);
    newPos.z = transform.position.z;
    transform.position = newPos;
  }


}
