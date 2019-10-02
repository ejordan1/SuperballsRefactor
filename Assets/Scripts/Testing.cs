using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Collections;
using Unity.Rendering;
using Unity.Mathematics;

public class Testing : MonoBehaviour
{

    [SerializeField] private Mesh mesh;
    [SerializeField] private Material material;
    // Start is called before the first frame update
    void Start()
    {
        EntityManager entityManager = World.Active.EntityManager;

        EntityArchetype entityArchetype = entityManager.CreateArchetype(
            typeof(Translation),
            typeof(RenderMesh),
            typeof(LocalToWorld),
            typeof(ForceToAddComponent),
            typeof(ForceComponent)
            );

        NativeArray<Entity> entityArray = new NativeArray<Entity>(10000, Allocator.Temp);

        entityManager.CreateEntity(entityArchetype, entityArray);

        for (int i = 0; i < entityArray.Length; i++)
        {
            Entity entity = entityArray[i];
            entityManager.SetComponentData(entity, new Translation
            {
                Value = new float3((i % 30) * 6 - 50, (i / 30) * 6 - 20, 20)
            });
            entityManager.SetComponentData(entity, new ForceToAddComponent { force = new float3(.4f, .2f, .05f) });
            entityManager.SetSharedComponentData(entity, new RenderMesh {
                mesh = mesh,
                material = material

              });

        }

        entityArray.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
