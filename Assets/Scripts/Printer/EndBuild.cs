using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EndBuild : MonoBehaviour
{
    [SerializeField] private PrintWall _printWall;
    [SerializeField] private GameObject _printer;

    private void OnEnable()
    {
        _printWall.BuildEnded += OnBuildEnd;
    }

    private void OnDisable()
    {
        _printWall.BuildEnded -= OnBuildEnd;
    }

    private void OnBuildEnd()
    {
        _printer.gameObject.SetActive(false);
    }
}
