using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private Insertions _insertionRoot;
    [SerializeField] private Insertion[] _insertions;
    [SerializeField] private TMP_Text _pointsText;
    [SerializeField] private StarsCounter _starsCounter;

    public float AllPoints { get; private set; }

    public void CheckCount()
    {
        foreach (var insertion in _insertions)
            AllPoints += insertion.Point;

        _pointsText.text = "Scores:" + " " + AllPoints.ToString();
        _starsCounter.CheckScore();
    }
}
