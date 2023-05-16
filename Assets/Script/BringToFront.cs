using UnityEngine;

public class BringToFront : MonoBehaviour
{
    private void Start()
    {
        // Bring the UI element to the forefront
        transform.SetAsLastSibling();
    }
}
