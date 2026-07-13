using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float horizontalPadding = 0.5f;

    private float minX;
    private float maxX;
    private void Awake()
    {
        Camera cam = Camera.main;
        float halfWidth = cam.orthographicSize * cam.aspect;
        minX = cam.transform.position.x - halfWidth + horizontalPadding;
        maxX = cam.transform.position.x + halfWidth - horizontalPadding;
    }
    private void Update()
    {
        float input = 0f;
        if (Keyboard.current.aKey.isPressed) input -= 1f;
        if (Keyboard.current.dKey.isPressed) input += 1f;

        if (Mathf.Approximately(input, 0f)) return;

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x + input * moveSpeed * Time.deltaTime, minX, maxX);
        transform.position = pos;
    }
}