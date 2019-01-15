using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Rendering;
using Unity.Mathematics;

namespace AmaranthineFields
{
    public class Bootstrap : MonoBehaviour
    {
        public int size;
        public float3 rotation;
        public Mesh mesh;
        public Material material;

        private void Start()
        {
            EntityManager entityManager = World.Active.GetOrCreateManager<EntityManager>();

            EntityArchetype entityArchetype = entityManager.CreateArchetype(
                typeof(TileDisplayValue)
                );

            material.SetFloat("_icon_texture_index", 0);

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    Entity entity = entityManager.CreateEntity(entityArchetype);

                    entityManager.SetComponentData(entity, new TileDisplayValue { Value = 0});
                }
            }
        }
    }
}
