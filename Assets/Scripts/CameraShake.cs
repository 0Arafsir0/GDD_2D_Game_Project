using UnityEngine;
using Unity.Cinemachine;

public class CameraShake : MonoBehaviour
{ 
    public static CameraShake instance;
    public CinemachineCamera cam;
    private float shakeTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        } 
    }

    // Update is called once per frame
    void Update()
    {
        if (shakeTimer > 0f)
        {
            shakeTimer -= Time.deltaTime;
            if(shakeTimer <= 0) {
                CinemachineBasicMultiChannelPerlin perlin = cam.GetComponent<CinemachineBasicMultiChannelPerlin>();
                perlin.AmplitudeGain = 0f;
            }
        }
    }
    public void ShakeCamera(float intensity, float time)
    {
        shakeTimer = time;
        CinemachineBasicMultiChannelPerlin perlin = cam.GetComponent<CinemachineBasicMultiChannelPerlin>();           
        perlin.AmplitudeGain = intensity;
    }
}
