using UnityEngine;
using Obi;

[RequireComponent(typeof(ObiEmitter))]
public class EmitOnKeyPress : MonoBehaviour
{
    [SerializeField] private float _speed;
    ObiEmitter emitter;
    public float emitSpeed = 4;
    public KeyCode key;

    void Start()
    {
        emitter = GetComponent<ObiEmitter>();
    }

    void Update()
    {
        if (Input.GetKey(key))
        {
            emitter.speed = emitSpeed;
            emitter.transform.Translate(Vector3.right * _speed * Time.deltaTime, Space.World);
        }
        else
            emitter.speed = 0;
    }
}
