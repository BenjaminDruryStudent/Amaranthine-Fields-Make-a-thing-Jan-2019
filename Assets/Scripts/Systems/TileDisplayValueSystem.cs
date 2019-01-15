using Unity.Entities;
using Unity.Jobs;
using Unity.Rendering;

public class TileDisplayValueSystem : JobComponentSystem
{
    private struct TileDisplayJob : IJobProcessComponentData<TileDisplayValue>
    {
        public void Execute(ref TileDisplayValue tileDisplay)
        {
            
        }
    }

    //protected override JobHandle OnUpdate(JobHandle inputDeps)
    //{
    //    PlayerInputJob job = new PlayerInputJob
    //    {
    //        Horizontal = Input.GetAxis("Horizontal")
    //    };

    //    return job.Schedule(this, inputDeps);
    //}
}
