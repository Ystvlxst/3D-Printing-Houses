using UnityEngine;
using Obi;
using static Obi.ObiSolver;

public class Vaporator : MonoBehaviour
{
    [SerializeField] private ObiSolver _solver;
    //[SerializeField] private ParticleSystem _smoke;
    //[SerializeField] private SmokeParticlePool _smokeParticlePool;


    private void Start()
    {
        _solver.OnCollision += Solver_OnCollision;
    }

    private void OnEnable()
    {
        if(_solver != null)
            _solver.OnCollision += Solver_OnCollision;
    }

    private void OnDisable()
    {
        _solver.OnCollision -= Solver_OnCollision;
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    private void Solver_OnCollision(object sender, ObiSolver.ObiCollisionEventArgs collisionEvent)
    {
        var world = ObiColliderWorld.GetInstance();

        foreach (Oni.Contact contact in collisionEvent.contacts)
        {
            if (contact.distance < 0.01)
            {
                ObiColliderBase collider = world.colliderHandles[contact.bodyB].owner;

                if (collider != null && collider.gameObject.TryGetComponent(out Vaporator _))
                {
                    int particleIndex = _solver.simplices[contact.bodyA];
                    ParticleInActor particle = _solver.particleToActor[particleIndex];

                    particle.actor.DeactivateParticle(particle.indexInActor);
                }
            }
        }
    }
}
