using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using Random = UnityEngine.Random;
using RunnerMovementSystem;

public class ProgressEffect : MonoBehaviour
{
    [SerializeField] private TMP_Text[] _textTemplates;

    private Coroutine _coroutine;

    private void Awake()
    {
        for (int i = 0; i < _textTemplates.Length; i++)
            _textTemplates[i].gameObject.transform.DOScale(0, 0.01f);
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Reaction();
            Debug.Log("up");
        }
    }

    private void Reaction()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Scaling());
    }

    private IEnumerator Scaling()
    {
        int textNumber = Random.Range(0, _textTemplates.Length);

        _textTemplates[textNumber].gameObject.transform.DOScale(1, 0.5f);
        yield return new WaitForSeconds(1f);
        _textTemplates[textNumber].gameObject.transform.DOScale(0, 0.5f);
    }
}
