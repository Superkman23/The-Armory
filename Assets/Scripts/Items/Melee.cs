using UnityEngine;

public class Melee : Item
{
  public float _SwingForce;
  public float _DegreeOffset;
  public bool _Left;
  public override void Use()
  {
    _Equipper.SetForce((_Equipper._Crosshair.transform.position - _Equipper.transform.position).normalized * _SwingForce);
    _Left = !_Left;
  }

  protected override Vector2 EquippedPosition()
  {
    Vector3 direction = (_Equipper._Crosshair.transform.position - _Equipper.transform.position).normalized;


    transform.right = direction;
    if (_Left)
    {
      transform.Rotate(new Vector3(0, 0, _DegreeOffset));
    }
    else
    {
      transform.Rotate(new Vector3(0, 0, -_DegreeOffset));
    }

    float distance = Vector2.Distance(_Equipper.transform.position, _Equipper._Crosshair.transform.position);
    distance = Mathf.Clamp(distance, 0, _MaxDistance);

    return transform.right * distance;
  }

}
