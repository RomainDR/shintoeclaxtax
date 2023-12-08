using UnityEngine;

public class ActivableObject : MonoBehaviour
{
    [SerializeField] protected bool useDebug = false;
    public virtual bool IsEnabled => IsEnabled;
    public virtual void Enable() { }
    public virtual void Disable() { } 
}
