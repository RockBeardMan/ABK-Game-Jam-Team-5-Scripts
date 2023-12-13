// IThrowable.cs
using UnityEngine;

public interface IThrowable
{
    void SetDamage(int damage);
    void Throw(Vector3 direction, float force);
}