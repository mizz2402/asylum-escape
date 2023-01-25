using UnityEngine;

public class GameManager : MonoBehaviour {
    private float gameSpeed;
    public float gameSpeedStep = 0.01f;
    public float minGameSpeed = 0.8f;
    public float maxGameSpeed = 1.3f;
    public float maxInsaneGameSpeed = 1.5f;
    public AudioSource music;

    private float score = 0f;
    public int pointsPerSecond = 100;

    private float sanity = 1f;
    public float sanityDropPerSecond = 0.1f;

    // Start is called before the first frame update
    void Start() {
        gameSpeed = minGameSpeed;
    }

    // Update is called once per frame
    void Update() {
        Time.timeScale = gameSpeed;
        music.pitch = gameSpeed;

        score += Time.deltaTime * pointsPerSecond;

        if (sanity > 0f)
            UpdateGameSpeed(maxGameSpeed);
        else
            UpdateGameSpeed(maxInsaneGameSpeed);
        UpdateSanity();
    }

    void UpdateSanity() {
        if (sanity < 0f)
            sanity = 0f;
        else if (sanity == 0f) {
            RenderSettings.reflectionIntensity = 0f;
        } else
            sanity -= Time.deltaTime * sanityDropPerSecond;
    }

    void UpdateGameSpeed(float maxGameSpeed) {
        if (gameSpeed < maxGameSpeed) {
            if (gameSpeed + Time.deltaTime * gameSpeedStep <= maxGameSpeed)
                gameSpeed += Time.deltaTime * gameSpeedStep;
            else
                gameSpeed = maxGameSpeed;
        } else if (gameSpeed > maxGameSpeed)
            gameSpeed -= Time.deltaTime * gameSpeedStep * 10;
    }

}
