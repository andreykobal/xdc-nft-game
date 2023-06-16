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

    public CheckNFTOwnership checkNFTOwnership;
    public MintNFT mintNFT;

    private Button buttonSelect1;
    private Button buttonSelect2;
    private Button buttonSelect3;

    private void Start()
    {
        // Begin checking NFT balances on start
        checkNFTOwnership.CheckNFTBalance("0xca9785544566C10B83dF3e49dcc2BbE8EB203138", 0);
        checkNFTOwnership.CheckNFTBalance("0x3084bfcE8877DB2D7C5A60A170649590b65c6D20", 1);
        checkNFTOwnership.CheckNFTBalance("0x44E6A9A038d78dE2a3Dea7B9D5a3767A9BE67Ce7", 2);
    }

    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        buttonSelect1 = root.Q<Button>("ButtonSelect1");
        buttonSelect2 = root.Q<Button>("ButtonSelect2");
        buttonSelect3 = root.Q<Button>("ButtonSelect3");

        buttonSelect1.clicked += () => HandleButtonClick(0);
        buttonSelect2.clicked += () => HandleButtonClick(1);
        buttonSelect3.clicked += () => HandleButtonClick(2);
    }

    private void HandleButtonClick(int avatarIndex)
    {
        if (checkNFTOwnership.HasAvatar(avatarIndex))
        {
            Debug.Log("Selected Character " + (avatarIndex + 1));
            DesiredAvatarIndex = avatarIndex;
            LoadNextScene();
        }
        else
        {
            Debug.Log("Minting Avatar " + (avatarIndex + 1));
            mintNFT.mintItem(avatarIndex);
        }
    }

    public void UpdateButtonLabel(int avatarIndex, string text)
    {
        switch (avatarIndex)
        {
            case 0:
                buttonSelect1.text = text;
                break;
            case 1:
                buttonSelect2.text = text;
                break;
            case 2:
                buttonSelect3.text = text;
                break;
        }
    }

    private void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nextSceneIndex);
    }
}
