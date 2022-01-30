using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int totalLevels;

    private static GameManager _instance;
    public static GameManager Instance {
	get {
	    if(_instance != null)
		return _instance;
	    return null;
	}
    }

    public int currentLevelIndex = 0;

    void Start(){
	if(_instance != null) {
            DestroyImmediate(this.gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(this);

        AudioManager.Instance().SetSound(true);
        AudioManager.Instance().PlayMusic("puzzle_loop");
        // AudioManager.Instance
    }

    void Update(){
	if(Input.GetKeyDown("r")){
            Debug.Log("welcome");
            SceneManager.LoadSceneAsync(currentLevelIndex, LoadSceneMode.Single);
        }
    }

    public void OnWin(){
        SceneManager.LoadScene((++currentLevelIndex % totalLevels), LoadSceneMode.Single);
    }


}
