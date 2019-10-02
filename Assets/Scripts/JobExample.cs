using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Unity.Mathematics;
//using Unity.Jobs;
//using Unity.Collections;
//using Unity.Burst;

//public class Testing : MonoBehaviour
//{
//    [SerializeField] private bool useJobs;

//    private List<float> numberList;

//    private void Start()
//    {
//        numberList = new List<float>();
//        for (int i = 0; i < 10000; i++)
//        {
//            numberList.Add(5);
//        }
//    }
//    // Update is called once per frame
//    void Update()
//    {
//        float startTime = Time.realtimeSinceStartup;

//        if (!useJobs)
//        {
//            for (int i = 0; i < numberList.Count; i++)
//            {
//                numberList[i] += 5;
//                for (int j = 0; j < 1000; j++)
//                {
//                    int a = 4 + 3 + 2 + 1;
//                }
//            }

//        }
//        else
//        {
//            NativeArray<float> numArray = new NativeArray<float>(numberList.Count, Allocator.TempJob);
//            for (int i = 0; i < numberList.Count; i++)
//            {
//                numArray[i] = numberList[i];
//            }
//            ReallyToughParallelJob reallyToughParallelJob = new ReallyToughParallelJob
//            {
//                nums = numArray
//            };

//            for (int i = 0; i < numberList.Count; i++)
//            {
//                numberList[i] = numberList[i];
//            }

//            JobHandle jobHandle = reallyToughParallelJob.Schedule(numberList.Count, numberList.Count / 10);
//            jobHandle.Complete();

//            for (int i = 0; i < numberList.Count; i++)
//            {
//                numberList[i] = numArray[i];
//            }
//            numArray.Dispose();
//        }
//        /*
//        if (useJobs)
//        {
//            NativeList<JobHandle> jobHandleList = new NativeList<JobHandle>(Allocator.Temp);
//            for (int i = 0; i < 10; i++)
//            {
//                JobHandle jobHandle = ReallyToughTaskJob();
//                jobHandleList.Add(jobHandle);
//            }
//            JobHandle.CompleteAll(jobHandleList);
//            jobHandleList.Dispose();
//        }
//        else
//        {
//            for (int i = 0; i < 10; i++)
//            {
//                ReallyToughTask();
//            }
//        }

//        */
//        Debug.Log(((Time.realtimeSinceStartup - startTime) * 1000) + "ms");
//    }

//    private void ReallyToughTask()
//    {
//        float value = 0f;
//        for (int i = 0; i < 50000; i++)
//        {
//            value = math.exp10(math.sqrt(value));
//        }
//    }

//    private JobHandle ReallyToughTaskJob()
//    {
//        ReallyToughJob job = new ReallyToughJob();
//        return job.Schedule();
//    }
//}

//[BurstCompile]
//public struct ReallyToughJob : IJob
//{
//    public void Execute()
//    {
//        float value = 0f;
//        for (int i = 0; i < 50000; i++)
//        {
//            value = math.exp10(math.sqrt(value));
//        }
//    }
//}

//[BurstCompile]
//public struct ReallyToughParallelJob : IJobParallelFor
//{
//    public NativeArray<float> nums;

//    public void Execute(int index)
//    {
//        nums[index] += 5;
//        for (int i = 0; i < 1000; i++)
//        {
//            int a = 4 + 3 + 2 + 1;
//        }
//    }
//}