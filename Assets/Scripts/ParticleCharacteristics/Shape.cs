namespace ParticleCharacteristics
{
    // can potentially use .toString for getting the name of sprite?
    enum Shape
    {
        CIRCLE = 3,
        SQUARE = 4,
        TRIANGLE = 5
    }

    static class ShapeUtil
    {
        static string GetSprite(Shape shape)
        {
            switch (shape)
            {
                case Shape.CIRCLE:
                    return "circle Sprite";
                case Shape.SQUARE:
                    return "circle Sprite";
                case Shape.TRIANGLE:
                    return "circle Sprite";
                default:
                    return "not a shape";
            }
        }
    }
}
