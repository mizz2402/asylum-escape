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
        int score = PlayerPrefs.GetInt("Score1", 0);
        leaderboardContent.text = leaderboardContent.text.Replace("$name1", name);
        leaderboardContent.text = leaderboardContent.text.Replace("$score1", score.ToString());

        name = PlayerPrefs.GetString("Name2", "..........");
        score = PlayerPrefs.GetInt("Score2", 0);
        leaderboardContent.text = leaderboardContent.text.Replace("$name2", name);
        leaderboardContent.text = leaderboardContent.text.Replace("$score2", score.ToString());

        name = PlayerPrefs.GetString("Name3", "..........");
        score = PlayerPrefs.GetInt("Score3", 0);
        leaderboardContent.text = leaderboardContent.text.Replace("$name3", name);
        leaderboardContent.text = leaderboardContent.text.Replace("$score3", score.ToString());

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
