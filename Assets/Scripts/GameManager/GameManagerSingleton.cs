using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManagerSingleton : MonoBehaviour
{
    public static GameManagerSingleton _instance;
    private Dictionary<string, Dictionary<string, List<AudioClip>>> _musicCollection;
    private string _currentRegroupement = "All";
    private string _currentTheme = "Menu";
    private AudioSource _audioPlayer;
    private bool _isPlayingMusic = false;

    private void Awake()
    {
        if (_instance != null)
            Destroy(gameObject);
        else {
            _instance = this;
            DontDestroyOnLoad(gameObject);
            LoadAllMusic();
            _audioPlayer = gameObject.GetComponent<AudioSource>();
        }
    }

    private void Update()
    {
        if (_isPlayingMusic && !_audioPlayer.isPlaying)
            PlayMusic();
    }

    public void PlayMusic(string theme = null, string regroupement = null)
    {
        _currentTheme = (theme == null || theme == "") ? _currentTheme : theme;
        _currentRegroupement = (regroupement == null || regroupement == "") ? _currentRegroupement : regroupement;
        _audioPlayer.clip = _musicCollection[_currentRegroupement][_currentTheme][Random.Range(0, _musicCollection[_currentRegroupement][_currentTheme].Count)];
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
        _musicCollection = new Dictionary<string, Dictionary<string, List<AudioClip>>>();
        _musicCollection["All"] = new Dictionary<string, List<AudioClip>>();
        foreach (ResourceItem regroupementItem in ResourceDB.GetFolder("Music").GetChilds("", ResourceItem.Type.Folder)) {
            _musicCollection[regroupementItem.Name] = new Dictionary<string, List<AudioClip>>();
            foreach (ResourceItem themeItem in ResourceDB.GetFolder(regroupementItem.ResourcesPath).GetChilds("", ResourceItem.Type.Folder)) {
                if (!(_musicCollection["All"].ContainsKey(themeItem.Name)))
                    _musicCollection["All"][themeItem.Name] = new List<AudioClip>();
                _musicCollection[regroupementItem.Name][themeItem.Name] = new List<AudioClip>();
                foreach (ResourceItem musicItem in ResourceDB.GetFolder(themeItem.ResourcesPath).GetChilds("", ResourceItem.Type.Asset)) {
                    _musicCollection["All"][themeItem.Name].Add(musicItem.Load<AudioClip>());
                    _musicCollection[regroupementItem.Name][themeItem.Name].Add(musicItem.Load<AudioClip>());
                }
            }
        }
    }
}
