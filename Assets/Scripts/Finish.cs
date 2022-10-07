using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using RunnerMovementSystem.Examples;
using Obi;

public class Finish : MonoBehaviour
{
    [SerializeField] private Transform _house;
    [SerializeField] private MouseInput mouseInput;
    [SerializeField] private EmitOnKeyPress _enimtOnKeyPress;

    private void Awake()
    {
        _house.DOScale(0, 0.1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CapsuleCollider capsuleCollider))
        {
            _enimtOnKeyPress.SetZeroSpeed();
            mouseInput.enabled = false;
            _house.DOScale(3, 5);
        }
    }
}
