using Unity.Entities;
using Unity.Jobs;
using Unity.Rendering;
using UnityEngine;

public class TileDisplayValueSystem : JobComponentSystem
{
    private struct TileDisplayJob : IJobProcessComponentData<TileDisplayValue>
    {
        public int add;
        public void Execute(ref TileDisplayValue tileDisplay)
        {
            tileDisplay.Value += add;
        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        TileDisplayJob job = new TileDisplayJob
        {
            add = 1
        };
        return job.Schedule(this, inputDeps);
    }
}
