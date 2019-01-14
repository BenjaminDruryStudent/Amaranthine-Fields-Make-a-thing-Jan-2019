using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Rendering;
using Unity.Mathematics;

namespace AmaranthineFields
{
    public class Bootstrap : MonoBehaviour
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
                                ComponentType.Create<Position>(),
                                ComponentType.Create<MeshInstanceRenderer>()
                                );

                entityManager.SetSharedComponentData(playerEntity, new MeshInstanceRenderer
                {
                    mesh = mesh,
                    material = material
                });
            }
        }
    } 
}
