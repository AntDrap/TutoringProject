using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerBehavior : MonoBehaviour
{
    public UnityEvent onEnter;
    public UnityEvent onStayInput;
    public UnityEvent onExit;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerBehavior p))
        {
            onEnter?.Invoke();

            if (onStayInput != null)
            {
                p.SetCurrentTrigger(this);
            }
            else
            {
                p.SetCurrentTrigger(null);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerBehavior p))
        {
            onExit?.Invoke();
            p.SetCurrentTrigger(null);
        }
    }
}