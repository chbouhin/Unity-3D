using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManagerSingleton : MonoBehaviour
{
    public static GameManagerSingleton _instance;
    #region Music-variable
    private Dictionary<string, Dictionary<string, List<ResourceItem>>> _musicCollection;
    private string _currentRegroupement = "All";
    private string _currentTheme = "Menu";
    private AudioClip _currentClip = null;
    private AudioSource _audioPlayer;
    private bool _isPlayingMusic = true;
    #endregion
    #region InGameTime-variable
    private float _inGameTimer = 0f;
    private bool _isTimerActive = false;
    #endregion
    #region Score-variable
    private int _currentScore;
    #endregion
    #region Leaderboard-variable
    private string _saveFilePath;
    #endregion
    #region GameOption-variable
    private float _volume = 1f;
    #endregion
    public bool _checkPoint = false;
    public Vector3 _savePosition;

    private void Awake()
    {
        if (_instance != null)
            Destroy(gameObject);
        else {
            _instance = this;
            DontDestroyOnLoad(gameObject);
            LoadAllMusic();
            _audioPlayer = gameObject.GetComponent<AudioSource>();
            _saveFilePath = Application.persistentDataPath + "/leaderboard.save";
        }
    }

    private void Update()
    {
        if (_isPlayingMusic && !_audioPlayer.isPlaying)
            PlayMusic();
        if (_isTimerActive)
            _inGameTimer += Time.deltaTime;
    }

    #region Music
    public void PlayMusic(string theme = null, string regroupement = null)
    {
        _currentTheme = (theme == null || theme == "") ? _currentTheme : theme;
        _currentRegroupement = (regroupement == null || regroupement == "") ? _currentRegroupement : regroupement;
        if (_currentClip != null)
            Resources.UnloadAsset(_currentClip);
        _currentClip = _musicCollection[_currentRegroupement][_currentTheme][Random.Range(0, _musicCollection[_currentRegroupement][_currentTheme].Count)].Load<AudioClip>();
        _audioPlayer.clip = _currentClip;
        _audioPlayer.Play();
        _isPlayingMusic = true;
    }

    public void StopMusic()
    {
        _audioPlayer.Stop();
        _isPlayingMusic = false;
    }

    public void ChangeRegroupement(string regroupement)
    {
        _currentRegroupement = regroupement;
    }

    public void ChangeTheme(string theme)
    {
        _currentTheme = theme;
    }

    public List<string> RegroupementList()
    {
        return _musicCollection.Keys.ToList<string>();
    }

    public List<string> ThemeList()
    {
        return _musicCollection[_currentRegroupement].Keys.ToList<string>();
    }

    private void LoadAllMusic()
    {
        _musicCollection = new Dictionary<string, Dictionary<string, List<ResourceItem>>>();
        _musicCollection["All"] = new Dictionary<string, List<ResourceItem>>();
        foreach (ResourceItem regroupementItem in ResourceDB.GetFolder("Music").GetChilds("", ResourceItem.Type.Folder)) {
            _musicCollection[regroupementItem.Name] = new Dictionary<string, List<ResourceItem>>();
            foreach (ResourceItem themeItem in ResourceDB.GetFolder(regroupementItem.ResourcesPath).GetChilds("", ResourceItem.Type.Folder)) {
                if (!(_musicCollection["All"].ContainsKey(themeItem.Name)))
                    _musicCollection["All"][themeItem.Name] = new List<ResourceItem>();
                _musicCollection[regroupementItem.Name][themeItem.Name] = new List<ResourceItem>();
                foreach (ResourceItem musicItem in ResourceDB.GetFolder(themeItem.ResourcesPath).GetChilds("", ResourceItem.Type.Asset)) {
                    _musicCollection["All"][themeItem.Name].Add(musicItem);
                    _musicCollection[regroupementItem.Name][themeItem.Name].Add(musicItem);
                }
            }
        }
    }
    #endregion
    #region InGameTime
    public float GetInGameTime()
    {
        return _inGameTimer;
    }

    public void StartTimer()
    {
        _isTimerActive = true;
    }

    public void StopTimer()
    {
        _isTimerActive = false;
    }

    public void ResetTimer()
    {
        _inGameTimer = 0f;
    }
    #endregion
    #region Score
    public int GetCurrentScore()
    {
        return _currentScore;
    }

    public void AddToScore(int toAdd)
    {
        _currentScore += toAdd;
    }

    public void ResetScore()
    {
        _currentScore = 0;
    }
    #endregion
    #region Leaderboard
    public List<SavedScoreData> LoadLeaderboard()
    {
        if (File.Exists(_saveFilePath)) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(_saveFilePath, FileMode.Open);
            List<SavedScoreData> leaderboard = (List<SavedScoreData>)bf.Deserialize(file);
            file.Close();
            return leaderboard;
        } else
            return null;
    }

    public void SaveScore()
    {
        List<SavedScoreData> leaderboard = LoadLeaderboard();
        if (leaderboard != null)
            File.Delete(_saveFilePath);
        else
            leaderboard = new List<SavedScoreData>();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream saveFile = File.Create(_saveFilePath);
        leaderboard.Add(new SavedScoreData {
            inGameTime = _inGameTimer,
            score = _currentScore
        });
        bf.Serialize(saveFile, leaderboard);
        saveFile.Close();
    }

    public List<SavedScoreData> GetBestScore(int size = 10)
    {
        List<SavedScoreData> leaderboard = LoadLeaderboard();
        leaderboard.Sort(delegate(SavedScoreData a, SavedScoreData b) {
            if (a.score > b.score) return 1;
            else if (a.score < b.score) return -1;
            else return 0;
        });
        List<SavedScoreData> ret = new List<SavedScoreData>();
        for (int i = 0; ret.Count != size && leaderboard.Count < i; ++i)
            ret.Add(leaderboard[i]);
        return ret;
    }

    public List<SavedScoreData> GetBestTime(int size = 10)
    {
        List<SavedScoreData> leaderboard = LoadLeaderboard();
        leaderboard.Sort(delegate (SavedScoreData a, SavedScoreData b) {
            if (a.inGameTime > b.inGameTime) return -1;
            else if (a.inGameTime < b.inGameTime) return 1;
            else return 0;
        });
        List<SavedScoreData> ret = new List<SavedScoreData>();
        for (int i = 0; ret.Count != size && leaderboard.Count < i; ++i)
            ret.Add(leaderboard[i]);
        return ret;
    }
    #endregion
    #region GameOption
    public void SetVolume(float volume)
    {
        _volume = volume;
        AudioListener.volume = _volume;
    }
    #endregion
}

[System.Serializable]
public class SavedScoreData
{
    public int score;
    public float inGameTime;
}