using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public RowUI rowUi;
    public ScoreManager scoreManager;

    void Start()
    {
        var scores = scoreManager.GetHighScores().ToArray();
        for (int i = 0; i < scores.Length; i++)
        {
            var row = Instantiate(rowUi, transform).GetComponent<RowUI>();
            row.transform.position = new Vector3(row.transform.position.x, row.transform.position.y - 35 * i, row.transform.position.z);
            row.rank.text = (i + 1).ToString();
            row.name.text = scores[i].name;
            row.score.text = TimeToString(scores[i].score);
        }
    }

    public void UpdateScores()
    {
        foreach(GameObject j in GameObject.FindGameObjectsWithTag("ScoreRow"))
        {
            Destroy(j);
        }
        var scores = scoreManager.GetHighScores().ToArray();
        for (int i = 0; i < scores.Length; i++)
        {
            var row = Instantiate(rowUi, transform).GetComponent<RowUI>();
            row.transform.position = new Vector3(row.transform.position.x, row.transform.position.y - 35 * i, row.transform.position.z);
            row.rank.text = (i + 1).ToString();
            row.name.text = scores[i].name;
            row.score.text = TimeToString(scores[i].score);
        }
    }
    private string TimeToString(float time)
    {
        string minutes = ((int)time / 60).ToString("00");
        string seconds = (time % 60).ToString("00");
        string milliseconds = ((time * 1000) % 1000).ToString("000");
        return minutes + ":" + seconds + "." + milliseconds;
    }
}