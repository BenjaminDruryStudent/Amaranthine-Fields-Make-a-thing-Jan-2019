using Unity.Jobs;
using Unity.Entities;
using Pure.Components;
using Unity.Transforms;
using UnityEngine;


namespace Pure.Systems
{
    public class PlayerMovementSystem : JobComponentSystem
    {
        private struct PlayerMovementJob : IJobProcessComponentData<Speed, PlayerInput, Position>
        {
            public float deltaTime;

            public void Execute(ref Speed speed, ref PlayerInput input, ref Position position)
            {
                

                position.Value.x += speed.Value * input.horizontal * deltaTime;
            }
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            PlayerMovementJob job = new PlayerMovementJob
            {
                deltaTime = Time.deltaTime
            };
            return job.Schedule(this, inputDeps);
        }
    } 
}
