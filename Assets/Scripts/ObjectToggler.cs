using UnityEngine;

public class ObjectToggler : MonoBehaviour
{
    public SoundID toggleSound;

    public GameObject[] itemsToToggle;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            foreach (var item in itemsToToggle)
            {
                item.SetActive(!item.activeSelf);
            }

            SoundManager.Instance.PlaySound2D(toggleSound);
        }
    }
}
