namespace ParticleCharacteristics
{
    /* Represents the four colours available for particles and their corresponding points. */
    public enum Colour
    {
        RED = 1,
        GREEN = 2,
        BLUE = 3,
        YELLOW = 4
    }

    /* Helper methods for getting more information associated with colours. */
    static class ColourUtil
    {
        /* Returns the Unity Sprite Color corresponding the the Colour Enum. */
        public static UnityEngine.Color GetSpriteColour(Colour colour)
        {
            switch (colour)
            {
                case Colour.RED:
                    return UnityEngine.Color.red;
                case Colour.BLUE:
                    return UnityEngine.Color.blue;
                case Colour.GREEN:
                    return UnityEngine.Color.green;
                case Colour.YELLOW:
                    return UnityEngine.Color.yellow;
                default: // ideally we throw some kind of error here as it is a Colour enum value that doesn't exist
                    return UnityEngine.Color.white;
            }
        }
    }
}