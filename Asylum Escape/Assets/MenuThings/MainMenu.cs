using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI leaderboardContent;
    public Slider volumeSlider;

    void Start() {
        string name = PlayerPrefs.GetString("Name1", "..........");
        float score = PlayerPrefs.GetFloat("Score1", 0f);
        leaderboardContent.text = leaderboardContent.text.Replace("$name1", name);
        leaderboardContent.text = leaderboardContent.text.Replace("$score1", score.ToString("#,##0"));

        name = PlayerPrefs.GetString("Name2", "..........");
        score = PlayerPrefs.GetFloat("Score2", 0f);
        leaderboardContent.text = leaderboardContent.text.Replace("$name2", name);
        leaderboardContent.text = leaderboardContent.text.Replace("$score2", score.ToString("#,##0"));

        name = PlayerPrefs.GetString("Name3", "..........");
        score = PlayerPrefs.GetFloat("Score3", 0f);
        leaderboardContent.text = leaderboardContent.text.Replace("$name3", name);
        leaderboardContent.text = leaderboardContent.text.Replace("$score3", score.ToString("#,##0"));

        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 1f);
    }

    public void Play()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void UpdateVolume(float volume) {
        PlayerPrefs.SetFloat("Volume", volume);
        Debug.Log("Volume: " + volume);
    }
}
