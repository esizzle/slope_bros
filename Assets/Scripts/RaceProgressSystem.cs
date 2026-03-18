using UnityEngine;

public class RaceProgressSystem : MonoBehaviour
{
    [System.Serializable]
    public class Racer
    {
        public Rigidbody2D player;
        public RectTransform icon;
        public float progressPercent;
    }
    
    public Racer[] racers;
    public RectTransform progressBar;

    private float totalDistancetoEnding;
    private Vector2 startingPoint;
    private Vector2 endingPoint;
    private Vector2 startToEndNormalized;

    private void Start()
    {
        GameObject startingPointObj = GameObject.FindGameObjectWithTag("StartingPoint");
        startingPoint = startingPointObj.transform.position;

        GameObject endingPointObj = GameObject.FindGameObjectWithTag("EndingPoint");
        endingPoint = endingPointObj.transform.position;

        totalDistancetoEnding = Vector2.Distance(endingPoint, startingPoint);
        startToEndNormalized = (endingPoint - startingPoint).normalized;
    }

    private void FixedUpdate()
    {
        foreach (Racer racer in racers)
        {
            Vector2 playerPos = racer.player.position;
            Vector2 startToPlayer = playerPos - startingPoint;

            float projectedLength = Vector2.Dot(startToPlayer, startToEndNormalized);
            racer.progressPercent = Mathf.Clamp01(projectedLength / totalDistancetoEnding);

            racer.icon.anchoredPosition = new Vector2(
                racer.progressPercent * progressBar.rect.width,
                racer.icon.anchoredPosition.y
            );
        }
    }
}