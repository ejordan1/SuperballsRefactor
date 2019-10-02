using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class GridShot : MonoBehaviour, iMakeShoot
{
    public BallShooter ballShooter;

    public void Start()
    {
        ballShooter = GameObject.Find("BallShooter").GetComponent<BallShooter>();
    }

    public void fire()
    {
        List<float3> grid = new List<float3>();

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                for (int k = 0; k < 5; k++)
                {
                    grid.Add(new float3(i, j, k));
                }
            }
        }
        ballShooter.fireBallGroup(grid);
    }

}
