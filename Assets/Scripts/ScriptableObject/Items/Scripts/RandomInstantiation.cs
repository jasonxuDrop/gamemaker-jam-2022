using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomInstantiation : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform pos;
    public GameObject[] objectsToInstantiate;

    void Start()
    {
        InstantiateObject();
    }
    private void InstantiateObject()
    {
        int n = Random.Range(0, objectsToInstantiate.Length);
        Instantiate(objectsToInstantiate[n], pos.position, objectsToInstantiate[n].transform.rotation);
    }
}
