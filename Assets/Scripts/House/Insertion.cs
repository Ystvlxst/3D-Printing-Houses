using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Insertion : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private PrintWall _printWall;
    [SerializeField] private Vector3 _targetScale;

    public Vector3 TargetScale => _targetScale;
    public float Point { get; private set; }

    private void OnEnable()
    {
        Point = 0;

        gameObject.transform.localScale = Vector3.zero;

        _printWall.BuildEnded += FindHoles;
    }

    private void OnDisable()
    {
        _printWall.BuildEnded -= FindHoles;
    }

    public void SetScale()
    {
        gameObject.transform.DOScale(_targetScale, 1);
    }

    private void FindHoles()
    {
        Collider[] colliders = Physics.OverlapBox(transform.position, transform.localScale / 2, Quaternion.identity, _layerMask);

        foreach (Collider collider in colliders)
        {
            if(collider.TryGetComponent(out Wall wall))
                Point += colliders.Length;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(transform.position, transform.localScale);
    }
}
