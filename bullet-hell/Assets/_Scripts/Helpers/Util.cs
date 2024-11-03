using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Util
{
    public static T GetRandomElementFromArray<T>(T[] array)
    {
        if (array == null || array.Length == 0)
        {
            Debug.LogError("Array cannot be null or empty");
            return default;
        }

        int randomIndex = Random.Range(0, array.Length);
        return array[randomIndex];
    }

    public static T GetRandomElementFromList<T>(List<T> list)
    {
        if (list == null || list.Count == 0)
        {
            Debug.LogError("List cannot be null or empty");
            return default;
        }

        int randomIndex = Random.Range(0, list.Count);
        return list[randomIndex];
    }

    public static int GetRandomNumberRange(int min, int max)
    {
        System.Random random = new System.Random();
        return random.Next(min, max);
    }
}
