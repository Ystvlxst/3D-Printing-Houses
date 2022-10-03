using UnityEngine;
using DG.Tweening;

public class StarsCounter : MonoBehaviour
{
    [SerializeField] private float _minScore;
    [SerializeField] private float _middleScore;
    [SerializeField] private float _maxScore;
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private GameObject[] _starPoints;

    private float Score => _scoreCounter.AllScore;
    private float _zeroScore = 500;

    public void CheckScore()
    {
        for(int i = 0; i < _starPoints.Length; i++)
        {
            if(Score <= _zeroScore)
            {
                ScaleStar(_starPoints[i]);
            }
            else if(Score >= _minScore && Score <= _middleScore)
            {
                ScaleStar(_starPoints[1]);
                ScaleStar(_starPoints[2]);
            }
            else if (Score >= _middleScore && Score <= _maxScore)
            {
                ScaleStar(_starPoints[1]);
                ScaleStar(_starPoints[2]);
            }
            else if(Score >= _maxScore)
            {
                return;
            }
        }
    }

    private void ScaleStar(GameObject gameObject)
    {
        gameObject.transform.DOScale(2, 1);
    }
}
