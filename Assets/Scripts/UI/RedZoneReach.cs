using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using RunnerMovementSystem;
using TMPro;
using UnityEngine;

public class RedZoneReach : MonoBehaviour
{
    [SerializeField] private Insertion[] _insertions;
    [SerializeField] private TMP_Text _textTemplate;
    [SerializeField] private Transform _parent;

    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }

    private void OnRedZoneReach()
    {
        StartCoroutine(Scaling());
    }

    private IEnumerator Scaling()
    {
        var text = Instantiate(_textTemplate, _parent, _parent);
        _textTemplate.gameObject.transform.DOScale(1, 0.5f);
        yield return new WaitForSeconds(1f);
        _textTemplate.gameObject.transform.DOScale(0, 0.5f);
        Destroy(_textTemplate, 0.5f);
    }
}
