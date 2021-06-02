using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controls the Highest-level view of the game, starting up levels and determining if the game is won or lost.
/// </summary>
public class GameManagerController : MonoBehaviour
{
    /// <summary>
    /// The energy decay rate of excess energy between levels.
    /// </summary>
    private const float ENERGYDECAYRATE = 0.5f;

    /// <summary>
    /// Max excess energy allowed.
    /// </summary>
    private const int MAXEXCESSENERGY = 50;

    /// <summary>
    /// Number of levels we will have in the game.
    /// </summary>
    private const int NUMOFLEVELS = 5;

    /// <summary>
    /// The level number we start to have levels with waves of particles.
    /// </summary>
    private const int WAVEDLEVELS = 3;

    /// <summary>
    /// The current level number.
    /// </summary>
    private static int currentLevel = 1;

    /// <summary>
    /// The current excess energy total.
    /// </summary>
    private static int excessEnergy = 0;

    /// <summary>
    /// The number of particles waiting to be emitted.
    /// </summary>
    private static int unemittedParticles = 0;

    /// <summary>
    /// Particle object to instantiate.
    /// </summary>
    public GameObject particlePrefab;

    /// <summary>
    /// Base level object to instantiate.
    /// </summary>
    public GameObject levelRunnerPrefab;

    /// <summary>
    /// Batched level object to instantiate.
    /// </summary>
    public GameObject batchedLevelRunnerPrefab;

    /// <summary>
    /// Called on object creation and starts the initial level.
    /// </summary>
    void Start()
    {
        // in a future iteration could load levels from a file e.g. domain language/yaml/json
        // instantiate initial level to be run
        StartLevel();
    }

    /// <summary>
    /// Adds the excess energy to the total and provides feedback to the player.
    /// </summary>
    /// <param name="excess">The amount of excess energy to be added. Can be negative.</param>
    public void AddExcessEnergy(int excess)
    {
        unemittedParticles--;
        excessEnergy += Mathf.Abs(excess);

        if (excessEnergy > MAXEXCESSENERGY) // game loss
            GameObject.Find("lose").GetComponent<Text>().color = Color.black;
        else if (unemittedParticles <= 0) // level success
            LevelEnd();
    }

    /// <summary>
    /// Signals to the game manager that all particles have been successfully dealt with.
    /// </summary>
    void LevelEnd()
    {
        if (++currentLevel <= NUMOFLEVELS)
        {
            excessEnergy = (int)(excessEnergy * ENERGYDECAYRATE); // decay the energy
            StartLevel(); // instantiate next level
        }
        else if (GameObject.Find("lose").GetComponent<Text>().color != Color.black)
        {
            GameObject.Find("win").GetComponent<Text>().color = Color.black;
        }
    }

    /// <summary>
    /// Starts a level based on the level number to be run.
    /// </summary>
    void StartLevel()
    {
        GameObject levelRunner = (currentLevel >= WAVEDLEVELS) ? Instantiate(batchedLevelRunnerPrefab) : Instantiate(levelRunnerPrefab);

        // using polymorphism here for starting a level 
        unemittedParticles = levelRunner.GetComponent<Level>().SetupAndStartLevel(currentLevel, particlePrefab);
    }

    /// <summary>
    /// Gives the current excess energy of the nuclear reactor (game).
    /// </summary>
    /// <returns>The current excess energy as a string.</returns>
    public static string GetExcessEnergy()
    {
        return excessEnergy.ToString();
    }
}
