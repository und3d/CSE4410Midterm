using System.Collections.Generic;
using UnityEngine;

public class ScoringSystem : MonoBehaviour
{
    // Singleton instance
    public static ScoringSystem Instance { get; private set; }

    // Dictionary to store point values for different target types
    private Dictionary<string, int> pointValues = new Dictionary<string, int>();

    private void Awake()
    {
        // Ensure there's only one instance of the ScoringSystem
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Add a point value for a target type
    public void AddPointValue(string targetType, int points)
    {
        if (!pointValues.ContainsKey(targetType))
        {
            pointValues.Add(targetType, points);
        }
        else
        {
            Debug.LogWarning("Point value for target type " + targetType + " already exists.");
        }
    }

    // Get the point value for a target type
    public int GetPointValue(string targetType)
    {
        int points = 0;
        if (pointValues.ContainsKey(targetType))
        {
            points = pointValues[targetType];
        }
        else
        {
            Debug.LogWarning("Point value for target type " + targetType + " does not exist.");
        }
        return points;
    }
}
