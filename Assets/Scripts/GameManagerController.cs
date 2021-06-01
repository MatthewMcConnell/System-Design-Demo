﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Controls the Highest-level view of the game, starting up levels and providing UI feedback to the user. */
public class GameManagerController : MonoBehaviour
{
    // the energy decay rate of excess energy between levels
    private const float ENERGYDECAYRATE = 0.5f;

    // max excess energy allowed
    private const int MAXEXCESSENERGY = 50;

    // number of levels we will have in the game
    private const int NUMOFLEVELS = 5;

    // at what level number we start to have levels with waves of particles
    private const int WAVEDLEVELS = 3;

    // current level number
    private static int currentLevel = 1;

    // current excess energy total
    private static int excessEnergy = 0;

    // number of particles waiting to be emitted
    private static int unemittedParticles = 0;

    // particle prefab to instantiate new levels
    public GameObject particlePrefab;

    // Start is called before the first frame update
    void Start()
    {
        // in a future iteration could load levels from a file e.g. domain language/yaml/json
        // instantiate initial level to be run
        StartLevel();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /* Adds the excess energy to the total and provides feedback to the player. */
    public void AddExcessEnergy(int excess)
    {
        unemittedParticles--;
        excessEnergy += Mathf.Abs(excess);

        if (excessEnergy > MAXEXCESSENERGY) // game loss
            Debug.Log("You Lost");
        else if (unemittedParticles <= 0) // level success
            LevelEnd();


    }

    /* Signals to the game manager that all particles have been successfully dealt with */
    void LevelEnd()
    {
        Debug.Log("hello");
        if (++currentLevel <= NUMOFLEVELS)
        {
            // decay the energy
            excessEnergy = (int)(excessEnergy * ENERGYDECAYRATE);
            // instantiate next level
            StartLevel();
        }
        else
        {
            // otherwise game win!
            // give final excess energy   
        }

    }

    void StartLevel()
    {
        Level level = new Level(currentLevel, particlePrefab);
        unemittedParticles = level.SetupAndStartLevel();
    }

    // /* Gives the current excess energy of the nuclear reactor (game) */
    public static string GetExcessEnergy()
    {
        return excessEnergy.ToString();
    }
}
