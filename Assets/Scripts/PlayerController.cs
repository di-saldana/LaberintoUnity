using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float velocidad;
    public Text countText;
    public Text winText;

	private Rigidbody rb;
    private int contador;

    Gyroscope m_Gyro;

	void Start() 
	{
		rb = GetComponent<Rigidbody>();
        contador = 0;
        SetCountText();
        winText.text = "";

        // Time.timeScale = 0;

        if(SystemInfo.deviceType != DeviceType.Desktop) {
            m_Gyro = Input.gyro;
            m_Gyro.enabled = true;
        }    
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        if(SystemInfo.deviceType == DeviceType.Desktop) {
            float posH = Input.GetAxis("Horizontal");
            float posV = Input.GetAxis("Vertical");

            Vector3 movimiento = new Vector3(posH, 0.0f, posV);

            rb.AddForce(movimiento * 10);
        } else{
            float posH = m_Gyro.rotationRate.y;
            float posV = -m_Gyro.rotationRate.x;

            Vector3 movimiento = new Vector3 (posH, 0.0f, posV);
                        
            rb.AddForce(movimiento * 10);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("mono"))
        {
            other.gameObject.SetActive(false);
            contador = contador + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = contador.ToString();
        if (contador >= 4)
        {
            winText.text = "Ganaste!!";
        }
    }

    private void OnTriggerExit(Collider other)
    {
		if (other.gameObject.CompareTag("tablero"))
		{
			winText.text = "Perdiste?!! :(";
			Invoke("QuitGame", 1f);
		}
	}

	void QuitGame()
	{
		#if UNITY_EDITOR
		    UnityEditor.EditorApplication.isPlaying = false;
		#elif UNITY_WEBPLAYER
		    Application.OpenURL(webplayerQuitURL);
		#else
		    Application.Quit();
		#endif
	}

}