using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    private float gameSpeed;
    public float gameSpeedStep = 0.01f;
    public float minGameSpeed = 0.8f;
    public float maxGameSpeed = 1.3f;
    public float maxInsaneGameSpeed = 1.5f;
    public AudioSource music;

    private float score = 0f;
    public int pointsPerSecond = 100;
    public TextMeshProUGUI scoreValue;

    private float sanity = 1f;
    public float sanityDropPerSecond = 0.1f;
    public Slider sanityBar;

    // Start is called before the first frame update
    void Start() {
        gameSpeed = minGameSpeed;
        music.volume = PlayerPrefs.GetFloat("Volume", 1f);
    }

    // Update is called once per frame
    void Update() {
        Time.timeScale = gameSpeed;
        music.pitch = gameSpeed;

        score += Time.deltaTime * pointsPerSecond;
        scoreValue.text = score.ToString("#,##0");

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
            TurnLightsOnOff(false);
        } else {
            sanity -= Time.deltaTime * sanityDropPerSecond;
            TurnLightsOnOff(true);
        }
        sanityBar.value = sanity;
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

    void TurnLightsOnOff(bool enabled) {
        foreach (Light light in FindObjectsOfType<Light>()) {
            if (light.type == LightType.Point) {
                light.enabled = enabled;
            }
        }
    }

}
