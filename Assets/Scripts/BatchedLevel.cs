using System.Collections;
using UnityEngine;

/// <summary>
/// Represents a slightly more advanced level where the particle spawning is divided into waves.
/// </summary>
public class BatchedLevel : Level
{
    /// <summary>
    /// constant for how long to wait between batches
    /// </summary>
    private const int WAIT = 2;

    /// <summary>
    /// Sets up and runs the level using a seed to generate particles.
    /// </summary>
    /// <param name="seed">Seed number for the particle generation to be based on.</param>
    /// <param name="particlePrefab">Particle object to generate from.</param>
    /// <returns></returns>
    public override int SetupAndStartLevel(int seed, GameObject particlePrefab)
    {
        // calculating parameters for particle generation
        int numOfParticles = (int)Mathf.Pow(seed, 2);
        int maxNumOfShapes = Mathf.Min(seed, shapes.Length);
        int maxNumOfColours = Mathf.Min(seed, colours.Length);

        StartCoroutine(GenerateBatchedParticle(particlePrefab, seed, numOfParticles, maxNumOfShapes, maxNumOfColours));

        return numOfParticles;
    }

    /// <summary>
    /// Generates and spawns particles in waves.
    /// </summary>
    /// <param name="particlePrefab">Particle object to generate from.</param>
    /// <param name="seed">Seed number for the generation to be based on.</param>
    /// <param name="numOfParticles">Number of particles to generate.</param>
    /// <param name="maxNumOfShapes">Maximum number of shapes allowed to use to generate particles.</param>
    /// <param name="maxNumOfColours">Maximum number of colours allowed to use to generate particles.</param>
    /// <returns></returns>
    IEnumerator GenerateBatchedParticle(GameObject particlePrefab, int seed, int numOfParticles, int maxNumOfShapes, int maxNumOfColours)
    {
        int batchNumOfParticles = numOfParticles / seed;

        for (int i = 0; i < seed; i++)
        {
            GenerateParticles(particlePrefab, batchNumOfParticles, maxNumOfShapes, maxNumOfColours);

            yield return new WaitForSeconds(WAIT);
        }
    }
}