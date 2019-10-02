using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicShot : MonoBehaviour, iMakeShoot
{
    public BallShooter ballShooter;

    public void Start()
    {
        ballShooter = GameObject.Find("BallShooter").GetComponent<BallShooter>();
    }

    public void fire()
    {
        ballShooter.fireSingleBall();
    }
}
