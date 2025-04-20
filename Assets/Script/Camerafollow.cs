using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    public Vector3 offset;

    public Transform PTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (PTransform == null)
        {
            return;
        }
        transform.position = PTransform.position + offset;
    }
}
