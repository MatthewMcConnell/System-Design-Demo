using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ParticleCharacteristics;

/* Contains the characteristics of and controls behaviour of the nuclear particles in the game. */
public class ParticleController : MonoBehaviour
{
    // excess energy contained in the particle
    private int energy;

    // disappearing rate of the particle
    private float disappearRate;

    // scale threshold at which the particle will release excess energy it has
    private const float scaleThreshold = 0.2f;


    /* Sets the characteristics of the particle changing its visual appearance and setting its behaviour. */
    void SetCharacteristics(Shape shape, Colour colour, float scale, float disappearRate)
    {
        ChangeAppearanceAndSetEnergy(shape, colour);
        gameObject.transform.localScale = new Vector3(scale, scale, scale);
        this.disappearRate = disappearRate;
    }

    /* Sets appearance and excess energy of the particle based on the shape and colour */
    private void ChangeAppearanceAndSetEnergy(Shape shape, Colour colour)
    {
        // calculating and setting the excess energy the particle has
        energy = (int)shape + (int)colour;

        // changing the appearance of the object
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = Resources.Load<Sprite>(shape.ToString());
        spriteRenderer.color = ColourUtil.GetSpriteColour(colour);
    }

    // Start is called before the first frame update
    void Start()
    {
        SetCharacteristics(Shape.SQUARE, Colour.YELLOW, 1.0f, 0.002f);
    }

    // Update is called once per frame
    void Update()
    {
        // decrease size of game object
        gameObject.transform.localScale -= new Vector3(1.0f, 1.0f, 1.0f) * disappearRate;

        if (gameObject.transform.localScale.x <= scaleThreshold)
            // if hits threshold then end of particle life cycle
            EmitParticleEnergy();

    }

    void OnMouseUp()
    {
        if (Input.GetMouseButtonUp(0)) // Left mouse button (decrease particle energy)
            energy--;
        else if (Input.GetMouseButtonUp(1)) // right mouse button (confirmation of being done with the particle)
            EmitParticleEnergy();
    }

    /* Emits excess energy and ends lifecycle of the particle. */
    private void EmitParticleEnergy()
    {
        // send excess energy to game manager
        Destroy(gameObject);
    }
}
