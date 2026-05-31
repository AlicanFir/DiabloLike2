using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class MenuManager : MonoBehaviour
    {

        public void ReturnToMainMenu()
        {
            SceneManager.LoadScene("Base");
        }

        public void Restart()
        {
            SceneManager.LoadScene("MainScene");
        }


        public void Exit()
        {
            this.gameObject.SetActive(false);
        }
        
        
        
        
    }
}