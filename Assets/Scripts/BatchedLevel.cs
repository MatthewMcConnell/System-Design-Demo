using System.Collections;
using UnityEngine;

/* Represents a slightly more advanced level where the particle spawning is divided into waves. */
public class BatchedLevel : Level
{
    // constant for how long to wait between batches
    private const int WAIT = 2;

    /* Sets up and runs the level using a seed to generate particles */
    public override int SetupAndStartLevel(int seed, GameObject particlePrefab)
    {
        // calculating parameters for particle generation
        int numOfParticles = (int)Mathf.Pow(seed, 2);
        int maxNumOfShapes = Mathf.Min(seed, shapes.Length);
        int maxNumOfColours = Mathf.Min(seed, colours.Length);

        StartCoroutine(GenerateBatchedParticle(particlePrefab, seed, numOfParticles, maxNumOfShapes, maxNumOfColours));

        return numOfParticles;
    }

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