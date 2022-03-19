using UnityEngine;
using UnityEngine.SceneManagement;

public class FinDeNiveau : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Scene scene = SceneManager.GetActiveScene();
            string nomScene = scene.name;
            MainMenuButtonAction mainMenuButtonAction = new MainMenuButtonAction();

            Debug.Log("Félicitation, le niveau est terminé.");
            GameManager.Instance.SaveData();

            if (nomScene == "Level1")
            {
                //mainMenuButtonAction.ActiverBoutonNiveau(0);
                SceneManager.LoadScene("Level2");
            }
            else if (nomScene == "Level2")
            {
               
                SceneManager.LoadScene("Level3");
            }
            else
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
