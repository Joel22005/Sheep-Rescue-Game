using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance; // 1
    [HideInInspector]
    public int sheepSaved; // 2
    [HideInInspector]
    public int sheepDropped; // 3
    public int sheepDroppedBeforeGameOver; // 4
    public SheepSpawner sheepSpawner; // 5
    public float duration;
    public float magnitude;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Title");
        }
    }

    public void SavedSheep()
    {
        sheepSaved++;
        if (sheepSaved == 5)
        {
            EnvironmentManager.Instance.ChangeEnvironment("Ice");
        }
        else if (sheepSaved == 10)
        {
            EnvironmentManager.Instance.ChangeEnvironment("Western");
        }
        else if (sheepSaved == 15)
        {
            EnvironmentManager.Instance.ChangeEnvironment("SciFi");
        }
        sheepSpawner.DecreaseSpawnInterval();
        UIManager.Instance.UpdateSheepSaved();
    }

    private void GameOver()
    {
        sheepSpawner.canSpawn = false; // 1
        sheepSpawner.DestroyAllSheep(); // 2
        UIManager.Instance.ShowGameOverWindow();
    }

    public void DroppedSheep()
    {
        sheepDropped++; // 1
        UIManager.Instance.UpdateSheepDropped();
        StartCoroutine(Camera.main.GetComponent<CameraShake>().Shake(duration, magnitude));
        if (sheepDropped == sheepDroppedBeforeGameOver) // 2
        {
            GameOver();
        }
    }
}
