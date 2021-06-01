using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    // generic particle object for instantiation
    public GameObject particlePrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void startLevel(int seed, Level level)
    {
        level.SetupAndStartLevel(seed, particlePrefab);
    }
}
