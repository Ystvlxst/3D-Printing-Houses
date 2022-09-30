using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Environment : MonoBehaviour
{
    [SerializeField] private PrintWall _printWall;

    private void OnEnable()
    {
        gameObject.transform.DOScale(0, 0.01f);

        _printWall.BuildEnded += OnBuildEnd;
    }

    private void OnDisable()
    {
        _printWall.BuildEnded -= OnBuildEnd;
    }

    private void OnBuildEnd()
    {
        gameObject.transform.DOScale(1, 1);
    }
}
