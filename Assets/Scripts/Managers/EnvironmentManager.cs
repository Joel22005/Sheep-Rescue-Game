using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    public static EnvironmentManager Instance;

    public MeshRenderer groundRenderer;
    public Light directionalLight;

    void Awake()
    {
        Instance = this;
    }

    public void ChangeEnvironment(string level)
    {
        Color floorColor = Color.white;
        Color lightColor = Color.white;
        float intensity = 1f;
        switch (level)
        {
            case "Ice":
                ColorUtility.TryParseHtmlString("#B3E5FF", out floorColor);
                ColorUtility.TryParseHtmlString("#D6F1FF", out lightColor);
                intensity = 1.2f;
                break;
            case "Western":
                ColorUtility.TryParseHtmlString("#D9A05B", out floorColor);
                ColorUtility.TryParseHtmlString("#FFD182", out lightColor);
                intensity = 1.5f;
                break;
            case "SciFi":
                ColorUtility.TryParseHtmlString("#1A1A1A", out floorColor);
                ColorUtility.TryParseHtmlString("#FF00FF", out lightColor);
                intensity = 1.0f;
                break;
        }
        if (groundRenderer != null)
            groundRenderer.material.color = floorColor;
        if (directionalLight != null)
        {
            directionalLight.color = lightColor;
            directionalLight.intensity = intensity;
        }
    }
}