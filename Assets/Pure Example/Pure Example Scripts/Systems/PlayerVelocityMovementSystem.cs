using Unity.Jobs;
using Unity.Entities;
using Pure.Components;
using Unity.Transforms;
using UnityEngine;
using Unity.Mathematics;

namespace Pure.Systems
{
    public class PlayerVelocityMovementSystem : JobComponentSystem
    {
        private struct PlayerMovementJob : IJobProcessComponentData<Speed, PlayerInput, Position,VelocityComponent>
        {
            public float deltaTime;

            public void Execute(ref Speed speed, ref PlayerInput input, ref Position position, ref VelocityComponent velocityComp)
            {
                float3 oldPos = position.Value;

                float3 currantVelocity = position.Value - velocityComp.velocity;

                currantVelocity *= new float3(1,0,0) *input.horizontal;

                currantVelocity -= currantVelocity * 2 / 10;

                position.Value += currantVelocity;
                velocityComp.velocity = oldPos;
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
