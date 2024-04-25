public enum Disposition
{
    Honest = 1,
    Greedy = 3,
};


public static class Utilities
{
    public static T GetRandomEnumValue<T>(T[] enumVals) where T : Enum
    {
        int randomIndex = new Random().Next(0, enumVals.Length);
        return enumVals[randomIndex];
    }

}