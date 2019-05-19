using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class TriggerForwarder : MonoBehaviour
{
    public event Action<Collider2D> OnTriggerEvent;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        OnTriggerEvent?.Invoke(collision);
    }
}
