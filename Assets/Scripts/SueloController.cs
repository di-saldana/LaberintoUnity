using UnityEngine;
using System.Collections;

public class SueloController : MonoBehaviour {
    private Rigidbody rb;

    // Use this for initialization
    Gyroscope m_Gyro;

    void Start () {
       rb = GetComponent<Rigidbody>();

       if(SystemInfo.deviceType != DeviceType.Desktop) {
            m_Gyro = Input.gyro;
            m_Gyro.enabled = true;
        } 
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if(SystemInfo.deviceType == DeviceType.Desktop) {
            float posH = Input.GetAxis("Horizontal");
            float posV = Input.GetAxis("Vertical");

            transform.Rotate(new Vector3(posV, posH, 0));
        } else {
            float posH = m_Gyro.rotationRate.y;
            float posV = -m_Gyro.rotationRate.x;

            transform.Rotate(new Vector3(posV, posH, 0));
        }
    }
}
