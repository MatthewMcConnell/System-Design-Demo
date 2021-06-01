using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ParticleCharacteristics;

/* Representation of a single level where particles are randomly generated and spawned. */
public class Level
{
    // starting scale of generated particles
    private const float PARTICLESCALE = 1.0f;

    // decreasing scale of particles for every frame
    private const float DECREASINGRATE = 0.002f;

    // all colour and shape values available
    Array colours = Enum.GetValues(typeof(Colour));
    Array shapes = Enum.GetValues(typeof(Shape));

    // seed number that the particle generation is based on
    private int seed;

    // particle prefab to build values from
    private GameObject particlePrefab;

    public Level(int seed, GameObject particlePrefab)
    {
        this.seed = seed;
        this.particlePrefab = particlePrefab;
    }

    /* Sets up and runs the level using a seed to generate particles */
    public int SetupAndStartLevel()
    {
        // calculating parameters for particle generation
        int numOfParticles = (int)Mathf.Pow(seed, 2);
        int maxNumOfShapes = Mathf.Min(seed, shapes.Length);
        int maxNumOfColours = Mathf.Min(seed, colours.Length);

        GenerateParticles(particlePrefab, numOfParticles, maxNumOfShapes, maxNumOfColours);

        return numOfParticles;
    }

    /* generates particles to be spawned */
    private void GenerateParticles(GameObject particlePrefab, int numOfParticles, int maxNumOfShapes, int maxNumOfColours)
    {
        System.Random random = new System.Random();

        // spawning randomised particles
        for (int i = 0; i < numOfParticles; i++)
        {
            Colour colour = (Colour)colours.GetValue(random.Next(maxNumOfColours));
            Shape shape = (Shape)shapes.GetValue(random.Next(maxNumOfShapes));

            GameObject particle = MonoBehaviour.Instantiate(particlePrefab, GetRandomPos(), Quaternion.identity);
            particle.GetComponent<ParticleController>().SetCharacteristics(shape, colour, PARTICLESCALE, DECREASINGRATE);
        }
    }

    /* generates a random spawn position on the screen */
    private Vector3 GetRandomPos()
    {
        float spawnY = UnityEngine.Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
        float spawnX = UnityEngine.Random.Range
            (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

        return new Vector3(spawnX, spawnY);
    }
}
