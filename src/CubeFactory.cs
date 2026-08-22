using System.Collections.Generic;
using UnityEngine;

public class CubeFactory : MonoBehaviour
{
    // get prefab
    public GameObject cubePrefab;

    // list of cubes
    public List<GameObject> cubes = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // create a new cube
            GameObject newCube = Instantiate(cubePrefab);

            // set position
            newCube.transform.position = new Vector3(0, 0, 0);

            // add to list
            cubes.Add(newCube);

            // print number of cubes
            Debug.Log(cubes.Count);
        }

        if (Input.GetKeyDown(KeyCode.R) && cubes.Count > 0)
        {
            // remove oldest cube
            GameObject oldestCube = cubes[0];
            cubes.Remove(oldestCube);
            Destroy(oldestCube);

            // print number of cubes
            Debug.Log(cubes.Count);
        }
    }
}
