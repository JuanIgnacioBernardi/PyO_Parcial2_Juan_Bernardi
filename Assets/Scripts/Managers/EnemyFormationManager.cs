using UnityEngine;
public class EnemyFormationManager : MonoBehaviour
{
    [Header("Formation Settings")]
    [SerializeField] private Transform formationRoot;
    [SerializeField] private float moveSpeed = 1.5f;
    [SerializeField] private float horizontalPadding = 0.5f;

    private float minX;
    private float maxX;
    private float direction = 1f;
    private float formationHalfWidth;
    private void Awake()
    {
        Camera cam = Camera.main;
        float halfWidth = cam.orthographicSize * cam.aspect;
        minX = cam.transform.position.x - halfWidth + horizontalPadding;
        maxX = cam.transform.position.x + halfWidth - horizontalPadding;

        formationHalfWidth = CalculateFormationHalfWidth();
    }
    private float CalculateFormationHalfWidth()
    {
        if (formationRoot.childCount == 0) return 0f;

        float left = float.MaxValue;
        float right = float.MinValue;
        foreach (Transform child in formationRoot)
        {
            left = Mathf.Min(left, child.position.x);
            right = Mathf.Max(right, child.position.x);
        }
        return (right - left) * 0.5f;
    }
    private void Update()
    {
        formationRoot.position += new Vector3(direction * moveSpeed * Time.deltaTime, 0f, 0f);

        float leftEdge = formationRoot.position.x - formationHalfWidth;
        float rightEdge = formationRoot.position.x + formationHalfWidth;

        if (rightEdge >= maxX || leftEdge <= minX)
            direction *= -1f;
    }
}