using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UI : MonoBehaviour
{
    private static int desiredAvatarIndex = 0;

    public static int DesiredAvatarIndex
    {
        get { return desiredAvatarIndex; }
        set { desiredAvatarIndex = value; }
    }

    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button buttonSelect1 = root.Q<Button>("ButtonSelect1");
        Button buttonSelect2 = root.Q<Button>("ButtonSelect2");
        Button buttonSelect3 = root.Q<Button>("ButtonSelect3");

        buttonSelect1.clicked += () =>
        {
            Debug.Log("Selected Character 1");
            DesiredAvatarIndex = 0;
            LoadNextScene();
        };

        buttonSelect2.clicked += () =>
        {
            Debug.Log("Selected Character 2");
            DesiredAvatarIndex = 1;
            LoadNextScene();
        };

        buttonSelect3.clicked += () =>
        {
            Debug.Log("Selected Character 3");
            DesiredAvatarIndex = 2;
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