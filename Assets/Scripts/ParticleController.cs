using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ParticleCharacteristics;

/// <summary>
///  Contains the characteristics of and controls behaviour of the nuclear particles in the game.
/// </summary>
public class ParticleController : MonoBehaviour
{
    /// <summary>
    ///  The excess energy contained in the particle.
    /// </summary>
    private int energy;

    /// <summary>
    /// The disappearing rate of the particle.
    /// </summary>
    private float disappearRate;

    /// <summary>
    /// The scale threshold at which the particle will release excess energy it has.
    /// </summary>
    private const float SCALETHRESHOLD = 0.2f;

    /// <summary>
    /// Reference to the game manager object so it can communicate with it.
    /// </summary>
    public GameObject gameManager;


    /// <summary>
    /// Sets the characteristics of the particle changing its visual appearance and setting its behaviour.
    /// </summary>
    /// <param name="shape">Shape the particle should have.</param>
    /// <param name="colour">Colour the particle should have.</param>
    /// <param name="scale">The scale size the particle should be.</param>
    /// <param name="disappearRate">Rate that the particle should become smaller and disappear.</param>
    public void SetCharacteristics(Shape shape, Colour colour, float scale, float disappearRate)
    {
        ChangeAppearanceAndSetEnergy(shape, colour);
        gameObject.transform.localScale = new Vector3(scale, scale, scale);
        this.disappearRate = disappearRate;
    }

    /// <summary>
    /// Sets appearance and excess energy of the particle based on the shape and colour.
    /// </summary>
    /// <param name="shape">Shape the particle should have.</param>
    /// <param name="colour">Colour the particle should have.</param>
    private void ChangeAppearanceAndSetEnergy(Shape shape, Colour colour)
    {
        // calculating and setting the excess energy the particle has
        energy = (int)shape + (int)colour;

        // changing the appearance of the object
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = Resources.Load<Sprite>(shape.ToString());
        spriteRenderer.color = ColourUtil.GetSpriteColour(colour);
    }

    /// <summary>
    /// Called once every frame and decreases the particle size until it hits a threshold.
    /// </summary>
    void Update()
    {
        // decrease size of game object over time
        gameObject.transform.localScale -= new Vector3(1.0f, 1.0f, 1.0f) * disappearRate;

        if (gameObject.transform.localScale.x <= SCALETHRESHOLD)
            // if hits threshold then end of particle life cycle
            EmitParticleEnergy();

    }

    /// <summary>
    /// On click the particle excess energy is decreased.
    /// </summary>
    void OnMouseUp()
    {
        energy--;
    }

    /// <summary>
    /// Emits excess energy and ends lifecycle of the particle.
    /// </summary>
    private void EmitParticleEnergy()
    {
        gameManager.GetComponent<GameManagerController>().AddExcessEnergy(energy);
        Destroy(gameObject);
    }
}
