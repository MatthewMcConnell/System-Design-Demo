using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ParticleCharacteristics;

/* Contains the characteristics of and controls behaviour of the nuclear particles in the game. */
public class ParticleController : MonoBehaviour
{
    // shape of the particle
    Shape shape;

    // colour of the particle
    Colour colour;

    // excess energy contained in the particle
    private int energy;

    // current scale size of the particle
    private float scale;

    // disappearing rate of the particle
    private readonly float disappearRate;

    // Start is called before the first frame update
    void Start()
    {
        shape = Shape.TRIANGLE;
        Sprite sprite = Resources.Load<Sprite>(shape.ToString());
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
        colour = Colour.BLUE;
        gameObject.GetComponent<SpriteRenderer>().color = ColourUtil.GetSpriteColour(colour);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
