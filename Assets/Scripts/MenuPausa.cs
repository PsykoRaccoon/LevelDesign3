using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausaSimple : MonoBehaviour
{
    public GameObject menuCanvas;
    private bool juegoPausado = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            juegoPausado = !juegoPausado;
            menuCanvas.SetActive(juegoPausado);
            Time.timeScale = juegoPausado ? 0f : 1f;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("Saliendo del juego...");
            Application.Quit();

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}
