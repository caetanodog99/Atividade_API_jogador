using UnityEngine;
using UnityEngine.SceneManagement;

public class recarregar : MonoBehaviour
{

    public void Reiniciar()
    {
        Scene cenaAtual = SceneManager.GetActiveScene();
        SceneManager.LoadScene(cenaAtual.name);
    }
}