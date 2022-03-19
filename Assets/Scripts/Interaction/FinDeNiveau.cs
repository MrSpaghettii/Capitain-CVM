using UnityEngine;
using UnityEngine.SceneManagement;

public class FinDeNiveau : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Scene scene = SceneManager.GetActiveScene();
            string nomSceneActuel = scene.name;
            string prochaineScene;
            Debug.Log("Félicitation, le niveau est terminé.");
            GameManager.Instance.SaveData();

            PlayerData data = new PlayerData();

            if (nomSceneActuel == "Level1")
            {
                prochaineScene = "Level2";
            }
            else if (nomSceneActuel == "Level2")
            {
                data.LevelTermine = 2;
                prochaineScene = "Level3";
            }
            else
            {
                data.LevelTermine = 3;
                prochaineScene ="MainMenu";
            }

            SceneManager.LoadScene(prochaineScene);
        }
    }
}
