using Pure.Components;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

namespace Pure.Systems
{
    public class PlayerInputSystem : JobComponentSystem
    {
        private struct PlayerInputJob : IJobProcessComponentData<PlayerInput>
        {
            public float Horizontal;

            public void Execute(ref PlayerInput input)
            {
                input.horizontal = Horizontal;
            }
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            PlayerInputJob job = new PlayerInputJob
            {
                Horizontal = Input.GetAxis("Horizontal")
            };

            return job.Schedule(this,inputDeps);
        }
    }
}
