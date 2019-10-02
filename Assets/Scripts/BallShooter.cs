using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Collections;
using Unity.Rendering;
using Unity.Mathematics;

public class BallShooter : MonoBehaviour
{

    [SerializeField] private Mesh mesh;
    [SerializeField] private Material material;
    // Start is called before the first frame update

    private GameObject ballLauncherDefault;

    private EntityManager entityManager;
    private EntityArchetype ballArchetype;
    private float3 ballLauncherPosition;
    private float3 ballLauncherDirection;
        
        
    void Start()
    {
        entityManager = World.Active.EntityManager;

        ballArchetype = entityManager.CreateArchetype(
            typeof(Translation),
            typeof(RenderMesh),
            typeof(LocalToWorld),
            typeof(ForceToAddComponent),
            typeof(ForceComponent),
            typeof(Scale)
        );

        ballLauncherDefault = GameObject.Find("BallLauncherDefault");
        ballLauncherPosition = new float3(ballLauncherDefault.transform.position);
        ballLauncherDirection = new float3(ballLauncherDefault.transform.rotation.eulerAngles);
        //fireTestGrid();
    }

    void Update()
    {
        //updates the position as a flaot3 so doesn't have to get this for every object being fired in that frame
        ballLauncherPosition = new float3(ballLauncherDefault.transform.position);
        ballLauncherDirection = new float3(ballLauncherDefault.transform.rotation.eulerAngles);


        //testing
        if (Input.GetKeyDown(KeyCode.H))
        {
            fireTestGrid();
        }
    }

    public void fireSingleBall()
    {
        Entity entity = entityManager.CreateEntity(ballArchetype);
        entityManager.SetComponentData(entity, new Translation
        {
            Value = ballLauncherPosition
           
        });
        entityManager.SetComponentData(entity, new ForceToAddComponent { force = new float3(5f, .2f, .5f)});
        entityManager.SetSharedComponentData(entity, new RenderMesh
        {
            mesh = mesh,
            material = material
        });
        entityManager.SetComponentData(entity, new Scale { Value = 1f });
    }

    public void fireBallGroup(List<float3> ballPositions)
    {
        NativeArray<Entity> entityArray = new NativeArray<Entity>(ballPositions.Count, Allocator.Temp);
        entityManager.CreateEntity(ballArchetype, entityArray);

        for(int i = 0; i < entityArray.Length; i++)
        {
            Entity entity = entityArray[i];
            entityManager.SetComponentData(entity, new Translation
            {
                Value = ballPositions[i] 
            });
            entityManager.SetComponentData(entity, new ForceToAddComponent { force = new float3(.5f, .5f, .5f) });
            entityManager.SetSharedComponentData(entity, new RenderMesh
            {
                mesh = mesh,
                material = material
            });
            entityManager.SetComponentData(entity, new Scale { Value = .3f });
        }
        entityArray.Dispose();
    }

    public void fireTestGrid()
    {
        NativeArray<Entity> entityArray = new NativeArray<Entity>(10000, Allocator.Temp);

        entityManager.CreateEntity(ballArchetype, entityArray);

        for (int i = 0; i < entityArray.Length; i++)
        {
            Entity entity = entityArray[i];
            entityManager.SetComponentData(entity, new Translation
            {
                Value = new float3((i % 30) * 6 - 50, (i / 30) * 6 - 20, 20)
            });
            entityManager.SetComponentData(entity, new ForceToAddComponent { force = new float3(.4f, .2f, .05f) });
            entityManager.SetSharedComponentData(entity, new RenderMesh
            {
                mesh = mesh,
                material = material

            });
            entityManager.SetComponentData(entity, new Scale { Value = 3 });

        }
        entityArray.Dispose();
    }

}

