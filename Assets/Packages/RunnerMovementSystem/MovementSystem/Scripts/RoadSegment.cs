using UnityEngine;
using PathCreation.Examples;

namespace RunnerMovementSystem
{
    [RequireComponent(typeof(RoadMeshCreator))]
    public class RoadSegment : PathSegment
    {
        [SerializeField] public bool AutoMoveForward;

        private RoadMeshCreator _roadMesh;

        public override float Width => _roadMesh.roadWidth;

        protected override void OnAwake()
        {
            _roadMesh = GetComponent<RoadMeshCreator>();
        }
    }
}