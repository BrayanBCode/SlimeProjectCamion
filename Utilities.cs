using Godot;

public partial class Utilities : Node
{
    #region VectorMultiplicationFunctions
    public static Vector3 MultipyVector(Vector3 vectorTo, int by)
    {
        Vector3 result = new(vectorTo.X * by, vectorTo.Y * by, vectorTo.Z * by);
        return result;
    }
    public static Vector3 MultipyVector(Vector3 vectorTo, float by)
    {
        Vector3 result = new(vectorTo.X * by, vectorTo.Y * by, vectorTo.Z * by);

        return result;
    }
    public static Vector3 MultipyVector(Vector3 vectorTo, double by)
    {
        float fby = (float)by;
        Vector3 result = new(vectorTo.X * fby, vectorTo.Y * fby, vectorTo.Z * fby);

        return result;
    }

    public static Vector2 MultipyVector(Vector2 vectorTo, int by)
    {
        Vector2 result = new(vectorTo.X * by, vectorTo.Y * by);
        return result;
    }
    public static Vector2 MultipyVector(Vector2 vectorTo, float by)
    {
        Vector2 result = new(vectorTo.X * by, vectorTo.Y * by);

        return result;
    }
    public static Vector2 MultipyVector(Vector2 vectorTo, double by)
    {
        float fby = (float)by;
        Vector2 result = new(vectorTo.X * fby, vectorTo.Y * fby);

        return result;
    }
    #endregion
}
