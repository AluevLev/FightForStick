using System.Collections.Generic;
using Unity.Mathematics;

public static class AdvancedRandom
{
	private static Random _globalRandom = new();
	public static uint Seed
	{
		get => _globalRandom.state;
		set => _globalRandom = new(value);
	}
	public static int BetweenInt(int min, int max) => _globalRandom.NextInt(min, max);
	public static float BetweenFloat(float min, float max) => _globalRandom.NextFloat() * (max - min) + min;
	public static bool FiftyFifty => BetweenInt(0, 2) == 1;
	public static float Percent => BetweenFloat(0f, 1f);
	public static T InArray<T>(T[] array) => array.Exist() ? array[BetweenInt(0, array.Length)] : default;
	public static T InList<T>(List<T> list) => list.Exist() ? list[BetweenInt(0, list.Count)] : default;
	public static T RandomElement<T>(this T[] array) => InArray(array);
    public static T RandomElement<T>(this List<T> list) => InList(list);
}
