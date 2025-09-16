using UnityEngine;

public class CameraSegue : MonoBehaviour
{
    public GameObject player;
    public Vector3 posInincial;
    public Vector3 offset;
    [Range(0, 10)]
    public float smoothCam;
    public Vector3 minValue, maxValue;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Fallow();
    }
        public void Fallow()
    {
        Vector3 targetPosition = player.transform.position + offset;
        Vector3 boundPosition = new Vector3(
            Mathf.Clamp(targetPosition.x, minValue.x, maxValue.x),
            Mathf.Clamp(targetPosition.y, minValue.y, maxValue.y),
            Mathf.Clamp(targetPosition.z, minValue.z, maxValue.z)
            );
        Vector3 smoothPosition = Vector3.Lerp(transform.position, boundPosition, smoothCam * Time.deltaTime);
        transform.position = smoothPosition;

    }
<<<<<<< HEAD
}
=======
}
>>>>>>> b75268287060bc5f425305d9db94cbd921304bd3
