using DG.Tweening;
using UnityEngine;

public class PrintHead : MonoBehaviour
{
    [SerializeField] private PrintWall _printWall;
    [SerializeField] private GameObject _modelHead;

    private void FixedUpdate()
    {
        if (_printWall.CurrentWall == 5)
            SetHeadModelTransform(1.5f, -2);

        if (_printWall.CurrentWall == 9)
            SetHeadModelTransform(0.5f, -1);
    }

    private void SetHeadModelTransform(float scaleY, float moveY)
    {
        _modelHead.transform.DOScaleY(scaleY, 0.5f);
        _modelHead.transform.DOLocalMoveY(moveY, 0.5f);
    }
}
