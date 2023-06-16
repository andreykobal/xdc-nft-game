using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UI : MonoBehaviour
{
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button buttonSelect1 = root.Q<Button>("ButtonSelect1");
        Button buttonSelect2 = root.Q<Button>("ButtonSelect2");
        Button buttonSelect3 = root.Q<Button>("ButtonSelect3");

        buttonSelect1.clicked += () =>
        {
            Debug.Log("Selected Character 1");
            LoadNextScene();
        };

        buttonSelect2.clicked += () =>
        {
            Debug.Log("Selected Character 2");
            LoadNextScene();
        };

        buttonSelect3.clicked += () =>
        {
            Debug.Log("Selected Character 3");
            LoadNextScene();
        };
    }

    private void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nextSceneIndex);
    }
}