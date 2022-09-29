using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class EndLevelPanel : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private PrintWall _printWall;
    [SerializeField] private ScoreCounter _scoreCounter;

    private void OnEnable()
    {
        _panel.SetActive(false);
        _printWall.BuildEnded += OnBuiledEnd;
    }

    private void OnDisable()
    {
        _printWall.BuildEnded -= OnBuiledEnd;
    }

    private void OnBuiledEnd()
    {
        StartCoroutine(PanelActive());
    }

    private IEnumerator PanelActive()
    {
        yield return new WaitForSeconds(1);
        _panel.SetActive(true);
        _panel.transform.DOScale(1, 1);
        _scoreCounter.CheckCount();
    }
}
