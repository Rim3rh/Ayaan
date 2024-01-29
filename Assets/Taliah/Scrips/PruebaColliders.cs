using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public class PruebaColliders : MonoBehaviour
{
    public int subdivisionLevel = 2; // Number of times to subdivide the collider

    private PolygonCollider2D polygonCollider;

    private void Start()
    {
        polygonCollider = GetComponent<PolygonCollider2D>();

        if (subdivisionLevel > 0)
        {
            for (int i = 0; i < subdivisionLevel; i++)
            {
                SubdivideCollider();
            }
        }
        else
        {
            Debug.LogWarning("Subdivision level should be greater than 0.");
        }
    }

    private void SubdivideCollider()
    {
        Vector2[] originalPoints = polygonCollider.points;
        int originalPointCount = originalPoints.Length;
        int newPointCount = originalPointCount * 2 - 1;

        Vector2[] subdividedPoints = new Vector2[newPointCount];

        for (int i = 0; i < originalPointCount; i++)
        {
            subdividedPoints[i * 2] = originalPoints[i];
            if (i < originalPointCount - 1)
            {
                subdividedPoints[i * 2 + 1] = Vector2.Lerp(originalPoints[i], originalPoints[i + 1], 0.5f);
            }
            else
            {
                // To close the loop, add a point that is halfway between the last and first points.
                subdividedPoints[i * 2 + 1] = Vector2.Lerp(originalPoints[i], originalPoints[1], 0.5f);
            }
        }

        polygonCollider.points = subdividedPoints;
    }
}