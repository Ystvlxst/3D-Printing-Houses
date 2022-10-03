using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private Insertions _insertionRoot;
    [SerializeField] private Insertion[] _insertions;
    [SerializeField] private TMP_Text _pointsText;
    [SerializeField] private StarsCounter _starsCounter;

    public float AllScore { get; private set; }

    public void CheckCount()
    {
        foreach (var insertion in _insertions)
            AllScore += insertion.Score;

        _pointsText.text = "Scores:" + " " + AllScore.ToString();
        _starsCounter.CheckScore();
    }
}
