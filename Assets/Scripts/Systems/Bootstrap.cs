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
                typeof(Position),
                typeof(Rotation),
                typeof(Scale),
                typeof(Static),
                typeof(MeshInstanceRenderer)
                );

            material.SetFloat("_icon_texture_index", 0);

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    Entity entity = entityManager.CreateEntity(entityArchetype);

                    Quaternion rot = Quaternion.Euler(rotation.x, rotation.y, rotation.z);

                    entityManager.SetComponentData(entity, new Position { Value = new float3((-size/2)+x,(size/2)-y,0) });
                    entityManager.SetComponentData(entity, new Rotation { Value = new float4(rot.x, rot.y, rot.z, rot.w) });
                    entityManager.SetComponentData(entity, new Scale { Value = new float3(0.1f,1,0.1f)});
                    entityManager.SetSharedComponentData(entity, new MeshInstanceRenderer
                    {
                        mesh = mesh,
                        material = new Material(material)
                    });
                }
            }
        }
    }
}
