using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Insertion : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private PrintWall _printWall;

    public float Point { get; private set; }

    private void OnEnable()
    {
        Point = 0;

        _printWall.BuildEnded += FindHoles;
    }

    private void OnDisable()
    {
        _printWall.BuildEnded -= FindHoles;
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
