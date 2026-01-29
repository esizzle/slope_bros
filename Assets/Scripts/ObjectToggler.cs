using UnityEngine;

public class ObjectToggler : MonoBehaviour
{
    public SoundID toggleSound;
    public GameObject toggleBlocker;
    public GameObject[] itemsToToggle;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!toggleBlocker.activeSelf)
            {
                foreach (var item in itemsToToggle)
                {
                    item.SetActive(!item.activeSelf);
                }

                Time.timeScale = Time.timeScale == 1f ? 0f : 1f;

                SoundManager.Instance.PlaySound2D(toggleSound);
            }
        }
    }

    public void Continue()
    {
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }
}