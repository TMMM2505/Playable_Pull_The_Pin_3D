using UnityEngine;

public interface IBomb
{
    public void ChangePhysicTo3D();
    public void AddForce(Collider hit, float Force);
    public void SpecialInteraction();
}
