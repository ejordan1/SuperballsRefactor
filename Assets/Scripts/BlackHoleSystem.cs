using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.Jobs;
using Unity.Burst;



public class BlackHoleSystem : JobComponentSystem
{
    [BurstCompile]
    struct AddGravityForce : IJobForEach<Translation, ForceToAddComponent>
    {

        public void Execute(ref Translation trans, ref ForceToAddComponent forceToAdd)
        {
            forceToAdd.force += new float3(0, 0, 0) - trans.Value / getMagnitudeFromFloat3(trans.Value
              ) * .02f;
        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var job = new AddGravityForce { }; //could add fields in here for struct

        return job.Schedule(this, inputDeps);
    }

        public static float getMagnitudeFromFloat3(float3 f)
        {
            float magnitude = new Vector3(f.x, f.y, f.z).magnitude;
            if (magnitude < 1)
            {
                magnitude = 1;
            }
            return magnitude;
        }
}


//public class BlackHoleSystem : ComponentSystem
//{

//    protected override void OnUpdate()
//    {
//        float3 center = new float3(0, 0, 0);
//        Entities.ForEach((ref Translation translation, ref ForceToAddComponent forceToAdd) =>
//        {

//            forceToAdd.force += center - (translation.Value / getMagnitudeFromFloat3(translation.Value
//            )) * .01f;

//        });
//    }
//    public static float getMagnitudeFromFloat3(float3 f)
//    {
//        float magnitude = new Vector3(f.x, f.y, f.z).magnitude;
//        if (magnitude < 1)
//        {
//            magnitude = 1;
//        }
//        return magnitude;
//    }
//}
