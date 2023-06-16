using UnityEngine;

public class AvatarChanger : MonoBehaviour
{
    public Avatar[] avatars; // The avatars to be assigned
    public GameObject[] avatarModelPrefabs; // The avatar model prefabs

    private Animator animator;
    private GameObject currentAvatarModel;
    public int desiredAvatarIndex = 0;

    private void Start()
    {
        animator = GetComponent<Animator>();
        InstantiateAvatarModel(desiredAvatarIndex);
        UpdateAvatar(desiredAvatarIndex);
        SetActiveAvatarModel(desiredAvatarIndex);
    }

    private void InstantiateAvatarModel(int avatarIndex)
    {
        if (currentAvatarModel != null)
        {
            Destroy(currentAvatarModel);
        }

        currentAvatarModel = Instantiate(avatarModelPrefabs[avatarIndex], transform.position, transform.rotation, transform);
    }

    private void SetActiveAvatarModel(int activeIndex)
    {
        for (int i = 0; i < avatarModelPrefabs.Length; i++)
        {
            if (i == activeIndex)
            {
                currentAvatarModel.SetActive(true);
            }
            else
            {
                Destroy(avatarModelPrefabs[i]);
            }
        }
    }

    private void UpdateAvatar(int avatarIndex)
    {
        // Assign the new avatar to the Animator component
        animator.avatar = avatars[avatarIndex];
    }
}