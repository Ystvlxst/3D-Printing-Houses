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
    [SerializeField] private Button _restart;
    [SerializeField] private TMP_Text _pointsText;
    [SerializeField] private Insertions _insertions;

    private void OnEnable()
    {
        _panel.SetActive(false);
        _printWall.BuildEnded += OnBuiledEnd;
        _restart.onClick.AddListener(Restart);
    }

    private void OnDisable()
    {
        _printWall.BuildEnded -= OnBuiledEnd;
        _restart.onClick.RemoveListener(Restart);
    }

    private void OnBuiledEnd()
    {
        StartCoroutine(PanelActive());
    }

    private void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    private IEnumerator PanelActive()
    {
        yield return new WaitForSeconds(1);
        _panel.SetActive(true);
        _panel.transform.DOScale(1, 1);
        _pointsText.text = "Points" + " " + _insertions.AllPoints.ToString();
    }
}
