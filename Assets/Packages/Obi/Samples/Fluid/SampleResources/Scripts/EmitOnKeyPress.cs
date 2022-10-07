using UnityEngine;
using Obi;

[RequireComponent(typeof(ObiEmitter))]
public class EmitOnKeyPress : MonoBehaviour
{
    ObiEmitter emitter;
    public float emitSpeed = 4;
    public KeyCode key;
    public float speed;

    void Start()
    {
        emitter = GetComponent<ObiEmitter>();
    }

    void Update()
    {
        if (Input.GetKey(key))
        {
            emitter.speed = emitSpeed;
        }
        else
            emitter.speed = 0;
    }

    public void SetZeroSpeed()
    {
        emitter.speed = 0;
    }
}
