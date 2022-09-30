using UnityEngine;
using System.Collections;

public class CameraBlend : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void Finish()
    {
        StartCoroutine(Trigger());
    }

    private IEnumerator Trigger()
    {
        _animator.SetTrigger(Parameters.Finish);
        yield return new WaitForSeconds(1);
        _animator.ResetTrigger(Parameters.Finish);
    }

    private static class Parameters
    {
        public static readonly string Finish = nameof(Finish);
    }
}
