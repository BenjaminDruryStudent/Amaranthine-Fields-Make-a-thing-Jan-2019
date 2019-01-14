using Unity.Entities;
using Unity.Mathematics;

namespace Pure.Components
{
    public struct VelocityComponent : IComponentData
    {
        public float mass;
        public float dragForce;
        public float3 velocity;
    } 
}
