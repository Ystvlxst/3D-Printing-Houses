using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCraneRotation : MonoBehaviour
{
    [SerializeField] private Transform _head;

    private void Update()
    {
        transform.LookAt(_head);
    }
}
