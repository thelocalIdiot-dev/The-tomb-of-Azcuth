using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeManager 
{
    public static void Shake(CinemachineImpulseSource Impulsesource)
    {
        Impulsesource.GenerateImpulseWithForce(1);
    }
}
