using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
  public bool _IsEquipped = false;
  //TODO: make equipper not a player but a generic object that player inherits from
  public Player _Equipper = null;
  public float _MaxDistance = 2;
  public void Use()
  {

  }

  public void FixedUpdate()
  {
    if (_IsEquipped)
    {
      transform.right = (_Equipper._Crosshair.transform.position - _Equipper.transform.position).normalized;
      float distance = Vector2.Distance(_Equipper.transform.position,_Equipper._Crosshair.transform.position);
      distance = Mathf.Clamp(distance, 0, _MaxDistance);
      transform.localPosition = transform.right * distance;
    }
  }


  public void Equip(Player equipper)
  {
    _Equipper = equipper;
    _IsEquipped = true;
    transform.parent = _Equipper.transform;
    transform.localPosition = Vector3.zero;
  }
}
