using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StarsCounter : MonoBehaviour
{
    [SerializeField] private float _minScore;
    [SerializeField] private float _middleScore;
    [SerializeField] private float _maxScore;
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private GameObject[] _starPoints;

    private float AllScore => _scoreCounter.AllPoints;

    public void CheckScore()
    {
        for(int i = 0; i < _starPoints.Length; i++)
        {
            if (AllScore <= _middleScore && AllScore > _minScore)
                ScaleStar(_starPoints[1]);

            if (AllScore <= _minScore && AllScore >= 500)
            {
                ScaleStar(_starPoints[1]);
                ScaleStar(_starPoints[2]);
            }

            if(AllScore >= _middleScore && AllScore < _maxScore)
                ScaleStar(_starPoints[i]);

            if (AllScore < _minScore || AllScore > _maxScore)
                ScaleStar(_starPoints[1]);
        }
    }

    private void ScaleStar(GameObject gameObject)
    {
        gameObject.transform.DOScale(2, 1);
    }
}
