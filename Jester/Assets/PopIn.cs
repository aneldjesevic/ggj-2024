using UnityEngine;

public class PopIn : MonoBehaviour
{
    public float popInDuration = 0.3f;

    private RectTransform rectTransform;
    private Vector3 originalScale;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalScale = rectTransform.localScale;

        rectTransform.localScale = Vector3.zero;

        StartCoroutine(PopInn());
    }

    private System.Collections.IEnumerator PopInn()
    {
        float elapsedTime = 0f;
        Vector3 initialScale = rectTransform.localScale;

        while (elapsedTime < popInDuration)
        {
            rectTransform.localScale = Vector3.Lerp(initialScale, originalScale, elapsedTime / popInDuration);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        rectTransform.localScale = originalScale;
    }
}
