using UnityEngine;

public class AutoFov : MonoBehaviour
{
    public GameObject worldBounders;
    private void Start()
    {
        float orthoSize = worldBounders.GetComponent<Collider2D>().bounds.size.x * Screen.height / Screen.width * 0.5f;
        Camera.main.orthographicSize = orthoSize;
    }
}