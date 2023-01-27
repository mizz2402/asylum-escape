using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    private bool isAlive = true;
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
    public float sanityIncresedByPill = 0.2f;
    public Slider sanityBar;

    public GameObject gameOverPanel;
    public GameObject topScorePanel;
    public TextMeshProUGUI scorePlacementText;
    public string playerName = "Winston";
    int scorePlacement;

    // Start is called before the first frame update
    void Start() {
        gameSpeed = minGameSpeed;
        music.volume = PlayerPrefs.GetFloat("Volume", 1f);
    }

    // Update is called once per frame
    void Update() {
        if (isAlive) {
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

    public void GameOver() {
        isAlive = false;
        scorePlacement = GetScorePlacement();
        if (scorePlacement > 0) {
            scorePlacementText.text = scorePlacementText.text.Replace("0", scorePlacement.ToString());
            topScorePanel.SetActive(true);
        } else
            gameOverPanel.SetActive(true);
    }

    // value 0 means score is below top 3
    int GetScorePlacement() {
        if (score > PlayerPrefs.GetFloat("Score3", 0f)) {
            if (score > PlayerPrefs.GetFloat("Score2", 0f)) {
                if (score > PlayerPrefs.GetFloat("Score1", 0f))
                    return 1;
                return 2;
            }
            return 3;
        }

        return 0;
    }

    public void RestartGame() {
        if (scorePlacement > 0)
            SaveTopScore(scorePlacement, playerName, score);
        SceneManager.LoadScene(1);
    }

    public void BackToMenu() {
        if (scorePlacement > 0)
            SaveTopScore(scorePlacement, playerName, score);
        SceneManager.LoadScene(0);
    }

    void SaveTopScore(int scorePlacement, string playerName, float score) {
        if (scorePlacement == 1) {
            SaveTopScore(2, PlayerPrefs.GetString("Name1", ".........."), PlayerPrefs.GetFloat("Score1", 0f));
            PlayerPrefs.SetString("Name1", playerName);
            PlayerPrefs.SetFloat("Score1", score);
        } else if (scorePlacement == 2) {
            SaveTopScore(3, PlayerPrefs.GetString("Name2", ".........."), PlayerPrefs.GetFloat("Score2", 0f));
            PlayerPrefs.SetString("Name2", playerName);
            PlayerPrefs.SetFloat("Score2", score);
        } else if (scorePlacement == 3) {
            PlayerPrefs.SetString("Name3", playerName);
            PlayerPrefs.SetFloat("Score3", score);
        }
    }

    public void SetPlayerName(string name) {
        playerName = name.Trim();
    }

    public void AddSanity() {
        sanity += sanityIncresedByPill;
    }
}
