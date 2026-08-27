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
            // report the unassigned prefab instead of spawning
            if (cubePrefab == null)
            {
                Debug.LogError("CubeFactory: the Cube Prefab field is unassigned, so no cube was spawned. Assign a prefab to the Cube Prefab field of the CubeFactory component.", this);
            }
            else
            {
                // create a new cube
                GameObject newCube = Instantiate(cubePrefab);

                // set position
                newCube.transform.position = new Vector3(0, 0, 0);

                // add to list
                cubes.Add(newCube);

                // report the spawn and the resulting number of cubes
                Debug.Log("CubeFactory: spawned cube, count is now " + cubes.Count);
            }
        }

        if (Input.GetKeyDown(KeyCode.R) && cubes.Count > 0)
        {
            // remove oldest cube
            GameObject oldestCube = cubes[0];
            cubes.Remove(oldestCube);
            Destroy(oldestCube);

            // report the removal and the resulting number of cubes
            Debug.Log("CubeFactory: removed cube, count is now " + cubes.Count);
        }
    }
}
