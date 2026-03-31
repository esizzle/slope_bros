using UnityEngine;
using UnityEngine.UI;

public enum PowerupType
{
    SpeedUp,
    GravityUp
}

public class PowerupManager : MonoBehaviour
{
    public static PowerupManager Instance;

    [System.Serializable]
    public class PowerupContainerUI
    {
        public Image powerupIcon;
        public PowerupType type;
    }

    public Rigidbody2D[] players;
    public PowerupContainerUI[] powerupContainersUI;
    public Sprite[] powerupIcons;

    public float _force = 100f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            var container = powerupContainersUI[0];
            if (!container.powerupIcon.enabled) return;

            ActivatePowerup(players[0], container.type, container.powerupIcon);
        }
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            var container = powerupContainersUI[1];
            if (!container.powerupIcon.enabled) return;

            ActivatePowerup(players[1], container.type, container.powerupIcon);
        }
    }

    public void GetRandomPowerUp(Transform player)
    {
        try
        {
            SoundManager.Instance.PlaySound2D(SoundID.Hover);
        }
        catch (System.Exception ex)
        {
            Debug.LogWarning($"SoundManager not found: {ex.Message}");
        }
        
        int randomIndex = Random.Range(0, System.Enum.GetValues(typeof(PowerupType)).Length);

        int playerIndex = player.name == "Blue Racer" ? 0 : 1;
        PowerupContainerUI container = powerupContainersUI[playerIndex];

        container.powerupIcon.GetComponent<Image>().sprite = powerupIcons[randomIndex];
        container.type = (PowerupType) randomIndex;
        
        container.powerupIcon.enabled = true;
    }

    private void ActivatePowerup(Rigidbody2D player, PowerupType type, Image icon)
    {
        switch (type)
        {
            case PowerupType.SpeedUp:
                try
                {
                    SoundManager.Instance.PlaySound2D(SoundID.Click);
                }
                catch (System.Exception ex)
                {
                    Debug.LogWarning($"SoundManager not found: {ex.Message}");
                }

                player.AddForce(Vector2.right * _force, ForceMode2D.Impulse);

                icon.enabled = false;
                break;

            case PowerupType.GravityUp:
                try
                {
                    SoundManager.Instance.PlaySound2D(SoundID.Click);
                }
                catch (System.Exception ex)
                {
                    Debug.LogWarning($"SoundManager not found: {ex.Message}");
                }
                
                player.AddForce(Vector2.down * _force, ForceMode2D.Impulse);

                icon.enabled = false;
                break;
        }
    }
}
