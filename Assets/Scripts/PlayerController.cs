using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class PlayerController : MonoBehaviour {

	public float velocidad;
    public Text winText;

	private Rigidbody rb;

    Gyroscope m_Gyro;

    public TextMeshProUGUI crab;
    public TextMeshProUGUI shell;
    public TextMeshProUGUI star;
    public GameController over; 

    public static int cont_crab;
    public static int cont_shell;
    public static int cont_star;

	void Start() 
	{
		rb = GetComponent<Rigidbody>();
        cont_crab = 0;
        cont_shell = 0;
        cont_star = 0;
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
        if (other.gameObject.CompareTag("crab"))
        {
            other.gameObject.SetActive(false);
            cont_crab = cont_crab + 1;
            crab.text = cont_crab.ToString();
        }
        if (other.gameObject.CompareTag("shell"))
        {
            other.gameObject.SetActive(false);
            cont_shell = cont_shell + 1;
            shell.text = cont_shell.ToString();
        }  
        if (other.gameObject.CompareTag("star"))
        {
            other.gameObject.SetActive(false);
            cont_star = cont_star + 1;
            star.text = cont_star.ToString();

            if (cont_star == 1)
            {
                winText.text = "Ganaste!!";
            }
            over.Win();
        }
    }

    void SetCountText()
    {
        star.text = cont_star.ToString();
        if (cont_star == 1)
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