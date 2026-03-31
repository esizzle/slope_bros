using UnityEngine;
using UnityEngine.UI;

public class PowerupIcon : MonoBehaviour
{
    private void Awake()
    {
        if (gameObject.name == "Powerup Icon 1")
        {
            PowerupManager.Instance.powerupContainersUI[0].powerupIcon = GetComponent<Image>();
        }
        else
        {
            PowerupManager.Instance.powerupContainersUI[1].powerupIcon = GetComponent<Image>();
        }
        
    }
}