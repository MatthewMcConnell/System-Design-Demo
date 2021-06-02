using System;
using UnityEngine;
using ParticleCharacteristics;

/// <summary>
/// Representation of a single level where particles are randomly generated and spawned.
/// </summary>
public class Level : MonoBehaviour
{
    /// <summary>
    /// The starting scale of generated particles.
    /// </summary>
    private const float PARTICLESCALE = 1.0f;

    /// <summary>
    /// The decreasing scale of particles for every frame.
    /// </summary>
    private const float DECREASINGRATE = 0.002f;

    /// <summary>
    /// All the colours of particles available to be used.
    /// </summary>
    protected Array colours = Enum.GetValues(typeof(Colour));

    /// <summary>
    /// All the shapes of particles available to be used.
    /// </summary>
    protected Array shapes = Enum.GetValues(typeof(Shape));

    /// <summary>
    /// Sets up and runs the level using a seed to generate particles.
    /// </summary>
    /// <param name="seed">Seed number the particle generation is based on.</param>
    /// <param name="particlePrefab">Particle object to generate from.</param>
    /// <returns></returns>
    public virtual int SetupAndStartLevel(int seed, GameObject particlePrefab)
    {
        // calculating parameters for particle generation
        int numOfParticles = (int)Mathf.Pow(seed, 2);
        int maxNumOfShapes = Mathf.Min(seed, shapes.Length);
        int maxNumOfColours = Mathf.Min(seed, colours.Length);

        GenerateParticles(particlePrefab, numOfParticles, maxNumOfShapes, maxNumOfColours);

        return numOfParticles;
    }

    /// <summary>
    /// Generates and spawns particles.
    /// </summary>
    /// <param name="particlePrefab">Particle object to generate from.</param>
    /// <param name="numOfParticles">Number of particles to spawn.</param>
    /// <param name="maxNumOfShapes">Maximum number of shapes allowed to use to generate particles.</param>
    /// <param name="maxNumOfColours">Maximum number of colours allowed to use to generate particles.</param>
    protected void GenerateParticles(GameObject particlePrefab, int numOfParticles, int maxNumOfShapes, int maxNumOfColours)
    {
        System.Random random = new System.Random();

        // spawning randomised particles
        for (int i = 0; i < numOfParticles; i++)
        {
            Colour colour = (Colour)colours.GetValue(random.Next(maxNumOfColours));
            Shape shape = (Shape)shapes.GetValue(random.Next(maxNumOfShapes));

            GameObject particle = Instantiate(particlePrefab, GetRandomPos(), Quaternion.identity);
            particle.GetComponent<ParticleController>().SetCharacteristics(shape, colour, PARTICLESCALE, DECREASINGRATE);
        }
    }

    /// <summary>
    /// Generates a random spawn position on the screen.
    /// </summary>
    /// <returns>Vector positions for an object.</returns>
    private Vector3 GetRandomPos()
    {
        float spawnY = UnityEngine.Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
        float spawnX = UnityEngine.Random.Range
            (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

        return new Vector3(spawnX, spawnY);
    }
}
