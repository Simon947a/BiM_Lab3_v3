using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools : MonoBehaviour {


    public static GameObject capsulePrefab;
    public static GameObject capsuleContainer;
    public static int Count = 0;
    public static List<GameObject> capsules;
    public static GameObject capsule;





    public static GameObject MakeCapsule(float x, float y, float z)
    {
        return MakeCapsule(x, y, z, Color.red, 1f);
    }

   

    public static GameObject MakeCapsule(float x, float y, float z, Color color, float size)
    {
        return MakeCapsule(new Vector3(x, y, z), color, size);
    }

    private static GameObject GetCubePrefab()
    {
        if (capsulePrefab == null)
            capsulePrefab = Resources.Load("Capsule") as GameObject;
        return capsulePrefab;
    }

    public static GameObject MakeCapsule(Vector3 position, Color color, float size)
    {
        Count++;
        if (capsuleContainer == null)
        {
            capsuleContainer = new GameObject("capsule container");
            capsules = new List<GameObject>();
        }

        capsule = Instantiate(GetCubePrefab()) as GameObject;
        capsules.Add(capsule);
        capsule.transform.position = position;
        capsule.transform.parent = capsuleContainer.transform;
        capsule.name = "capsule " + Count;

        capsule.GetComponent<Renderer>().material.color = color;
        capsule.transform.localScale = new Vector3(size, size, size);

        return capsule;
    }


}
