using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Present present;

    private static GameManager _instance;
    public static GameManager Instance {
	get {
	    if(_instance != null)
		return _instance;
	    return null;
	}
    }

    void Start(){
	if(_instance != null)
            DestroyImmediate(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
        present.onWinEvent.AddListener(OnWin);
    }

    void OnWin(){
        Debug.Log("You Win");
    }


}
