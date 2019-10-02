using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Collections;
using Unity.Burst;

public class ApplyForceSystem : JobComponentSystem
{
    [BurstCompile]
    struct MoveBall : IJobForEach<Translation, ForceToAddComponent, ForceComponent>
    {
        public void Execute(ref Translation translation, ref ForceToAddComponent forceToAdd, ref ForceComponent force)
        {
            force.force += forceToAdd.force;
            translation.Value += force.force;
            forceToAdd.force = new float3(0, 0, 0);
        }

    }

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var job = new MoveBall { };

        return job.Schedule(this, inputDeps);
    }


}
