using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class ScoreManager : MonoBehaviour
{

    private string filePath;
    public List<int> Scores { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        this.filePath = Path.Combine(Application.persistentDataPath, "scores.txt");
        if (File.Exists(filePath))
        {
            this.LoadScores();
        }
        if (this.Scores == null)
        {
            this.Scores = new List<int>();
            this.Scores.AddRange(Enumerable.Repeat(0,5));
            this.SaveScores();
        }
    }

    private void LoadScores()
    {
        using(FileStream fs = new FileStream(this.filePath, FileMode.Open, FileAccess.Read))
        {
            BinaryFormatter bf = new BinaryFormatter();
            this.Scores = (List<int>)bf.Deserialize(fs);
        }    
     }

     public void UpdateScores(int score)
     {
          if (score > this.Scores.Min())
          {
                this.Scores.Add(score);
                this.Scores = this.Scores.OrderByDescending (x => x).Take(5).ToList();
                this.SaveScores();
          }
     }

     private void SaveScores()
     {
          using(FileStream fs = new FileStream(this.filePath, FileMode.OpenOrCreate, FileAccess.Write))
          {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, this.Scores);
          }
     }
}
