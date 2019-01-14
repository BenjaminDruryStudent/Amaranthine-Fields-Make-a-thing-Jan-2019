using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Rendering;
using Pure.Components;
using Unity.Mathematics;

namespace Pure
{
    public class PureBootstrap : MonoBehaviour
    {
        public float speed;
        public Mesh mesh;
        public Material material;
        Entity[] entities;

        private void Start()
        {
            EntityManager entityManager = World.Active.GetOrCreateManager<EntityManager>();

            for (int i = 0; i < 10; i++)
            {
                Entity playerEntity = entityManager.CreateEntity(
                                ComponentType.Create<Speed>(),
                                ComponentType.Create<VelocityComponent>(),
                                ComponentType.Create<PlayerInput>(),
                                ComponentType.Create<Position>(),
                                ComponentType.Create<MeshInstanceRenderer>()
                                );
                entityManager.SetComponentData(playerEntity, new Speed { Value = speed });
                entityManager.SetComponentData(playerEntity, new Position { Value = new float3(i, 0, 0) });
                entityManager.SetComponentData(playerEntity, new VelocityComponent { velocity = new float3(0) });

                entityManager.SetSharedComponentData(playerEntity, new MeshInstanceRenderer
                {
                    mesh = mesh,
                    material = material
                });
            }
        }

        [ContextMenu("Trigger Death")]
        public void Death()
        {
            Debug.Log("Dide");
        }
    } 
}
