using UnityEngine;

public class ARInteractable : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    private Renderer objectRenderer;
    private float currentHue;

    private void Awake()
    {
        objectRenderer = GetComponentInChildren<Renderer>();

        if (objectRenderer != null)
        {
            Color.RGBToHSV(
                objectRenderer.material.color,
                out currentHue,
                out _,
                out _
            );
        }

        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();

        if (audioSource != null)
            audioSource.playOnAwake = false;
    }

    public void Activate()
    {
        if (objectRenderer != null)
        {
            currentHue = Mathf.Repeat(currentHue + 0.18f, 1f);

            objectRenderer.material.color =
                Color.HSVToRGB(currentHue, 0.8f, 1f);
        }

        if (audioSource != null)
        {
            audioSource.Stop();
            audioSource.Play();
        }
    }
}