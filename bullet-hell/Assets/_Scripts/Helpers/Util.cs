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

    public static List<T> GetRandomElementsFromList<T>(List<T> list, int count)
    {
        if (list == null || list.Count == 0 || count <= 0 || count > list.Count)
        {
            Debug.LogError("Invalid input: list is null or empty, or count is invalid");
            return new List<T>();
        }

        List<T> result = new List<T>();
        HashSet<int> usedIndices = new HashSet<int>();

        while (result.Count < count)
        {
            int randomIndex = Random.Range(0, list.Count);
            if (!usedIndices.Contains(randomIndex))
            {
                result.Add(list[randomIndex]);
                usedIndices.Add(randomIndex);
            }
        }

        return result;
    }

    public static int GetRandomNumberRange(int min, int max)
    {
        System.Random random = new System.Random();
        return random.Next(min, max);
    }
}
