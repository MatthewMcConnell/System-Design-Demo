using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Controls the Highest-level view of the game, starting up levels and providing UI feedback to the user. */
public class GameManagerController : MonoBehaviour
{
    // the energy decay rate of excess energy between levels
    private const float ENERGYDECAYRATE = 0.1f;

    // max excess energy allowed
    private const int MAXEXCESSENERGY = 50;

    // number of levels we will have in the game
    private const int NUMOFLEVELS = 5;

    // at what level number we start to have levels with waves of particles
    private const int WAVEDLEVELS = 3;

    // current level number
    private int currentLevel = 1;

    // current excess energy total
    private int excessEnergy = 0;

    // level prefab to instantiate new levels
    public GameObject levelPrefab;

    // Start is called before the first frame update
    void Start()
    {
        // in a future iteration could load levels from a file e.g. domain language/yaml/json
        // instantiate level 1
    }

    // Update is called once per frame
    void Update()
    {

    }

    /* Adds the excess energy to the total and provides feedback to the player. */
    void addExcessEnergy(int excess)
    {
        excessEnergy += Mathf.Abs(excess);

        if (excessEnergy > MAXEXCESSENERGY)
            // game lose!
            Debug.Log("You Lost");
        else if (excess > 0)
            // fission!
            Debug.Log("fission");
        else if (excess < 0)
            // fusion!
            Debug.Log("fusion");
    }

    /* Signals to the game manager that all particles have been successfully dealt with */
    void signalLevelEnd()
    {
        if (++currentLevel <= NUMOFLEVELS)
        {
            // decay the energy
            excessEnergy = (int)(excessEnergy * ENERGYDECAYRATE);
            // instantiate next level
        }
        else
        {
            // otherwise game win!
            // give final excess energy   
        }

    }

    void startLevel()
    {
        GameObject level = Instantiate(levelPrefab);
        level.GetComponent<LevelController>();
    }
}
