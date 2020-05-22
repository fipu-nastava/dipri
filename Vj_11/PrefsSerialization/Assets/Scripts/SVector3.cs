using System;
using UnityEngine;

[Serializable]
public class SVector3
{
    public float x;
    public float y;
    public float z;
    public static implicit operator Vector3(SVector3 p)
    {
        return new Vector3(p.x, p.y, p.z);
    }
    public SVector3(Vector3 p)
    {
        this.x = p.x;
        this.y = p.y;
        this.z = p.z;
    }
    public SVector3(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
}