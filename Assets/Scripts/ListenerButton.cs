        using UnityEngine;
        using UnityEngine.UI;
        using System.Collections;
        using UnityEngine.SceneManagement;

        public class ListenerButton : MonoBehaviour
        {
        public Button yourButton;
        
        void Start()
        {
                Button btn = yourButton.GetComponent<Button>();
                btn.onClick.AddListener(TaskOnClick);
        }

        void TaskOnClick()
        {
                Debug.Log("You have clicked the button!");
                SceneManager.LoadScene("Level");
        }
}