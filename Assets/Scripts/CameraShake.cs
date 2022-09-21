using UnityEngine;
using UnityEngine.Random.Range;

public class CameraShake : MonoBehaviour
{
    private Transform camTransform;
    private float shakeDuraion = 1f, shakeAmount = 0.05f, decreaseFactor = 1.5f;

    private Vector3 originPosition;

    private void Start()
    {
        camTransform = GetComponent<Transform>();
        originPosition = camTransform.localPosition;
    }
    private void Update()
    {
        if (shakeDuraion > 0)
        {
            camTransform.localPosition = originPosition + Random.InsideUnitSphere * shakeAmount;
            shakeDuraion -= Time.deltaTime * decreaseFactor;
        } else
        {
            camTransform.localPosition = originPosition;
            shakeDuraion = 0;
        }
    }
}
