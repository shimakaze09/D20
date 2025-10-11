using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private readonly float speed = 0.9f;
    [SerializeField] private Transform target;

    private void Update()
    {
        if (target == null)
            return;

        var pos = transform.position;
        var lerp = Vector3.Lerp(pos, target.position, speed * Time.deltaTime);
        var result = new Vector3(lerp.x, lerp.y, pos.z);
        transform.position = result;
    }
}