using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ParticleCharacteristics;

/* Representation of a single level where particles are randomly generated and spawned. */
public class LevelController : MonoBehaviour
{
    // starting scale of generated particles
    private const float PARTICLESCALE = 1.0f;

    // decreasing scale of particles for every frame
    private const float DECREASINGRATE = 0.005f;

    // all colour and shape values available
    Array colours = Enum.GetValues(typeof(Colour));
    Array shapes = Enum.GetValues(typeof(Shape));

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

    /* Sets up and runs the level using a seed to generate particles */
    public void SetupAndStartLevel(int seed)
    {
        // calculating parameters for particle generation
        int numOfParticles = (int)Mathf.Pow(seed, 2);
        int maxNumOfShapes = Mathf.Min(seed, shapes.Length);
        int maxNumOfColours = Mathf.Min(seed, colours.Length);

        generateParticles(numOfParticles, maxNumOfShapes, maxNumOfColours);
    }

    /* generates particles to be spawned */
    private void generateParticles(int numOfParticles, int maxNumOfShapes, int maxNumOfColours)
    {
        System.Random random = new System.Random();

        // spawning randomised particles
        for (int i = 0; i < numOfParticles; i++)
        {
            Colour colour = (Colour)colours.GetValue(random.Next(1, maxNumOfColours));
            Shape shape = (Shape)shapes.GetValue(random.Next(1, maxNumOfShapes));

            GameObject particle = Instantiate(particlePrefab, getRandomPos(), Quaternion.identity);
            particle.GetComponent<ParticleController>().SetCharacteristics(shape, colour, PARTICLESCALE, DECREASINGRATE);
        }
    }

    /* generates a random spawn position on the screen */
    private Vector2 getRandomPos()
    {
        float spawnY = UnityEngine.Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
        float spawnX = UnityEngine.Random.Range
            (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

        return new Vector2(spawnX, spawnY);
    }
}
