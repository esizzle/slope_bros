using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScreenFader : MonoBehaviour
{
    [SerializeField] private Image _fadeImage;
    [SerializeField] private float _fadeDuration = 1f;

    public IEnumerator FadeOut()
    {
        float t = 0f;

        while (t < _fadeDuration)
        {
            t += Time.deltaTime;
            SetAlpha(t / _fadeDuration);
            yield return null;
        }

        SetAlpha(1f);
    }

    public IEnumerator FadeIn()
    {
        float t = 0f;

        while (t < _fadeDuration)
        {
            t += Time.deltaTime;
            SetAlpha(1f - (t / _fadeDuration));
            yield return null;
        }

        SetAlpha(0f);
    }

    private void SetAlpha(float a)
    {
        Color c = _fadeImage.color;
        c.a = a;
        _fadeImage.color = c;
    }
}
