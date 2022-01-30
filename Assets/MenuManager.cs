using UnityEngine;
using DG.Tweening;

public class MenuManager : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject[] initialObjects;

    private CanvasGroup _canvasGroup;


    void Start(){
        _canvasGroup = menuPanel.GetComponent<CanvasGroup>();
    }

    void Update(){
	if(Input.GetKeyDown("space") || Input.GetKeyDown("enter")) {

            _canvasGroup.DOFade(0f, 2f).OnComplete(() => {
		if(menuPanel.active) {
		    menuPanel.SetActive(false);

		    for (int i = 0; i < initialObjects.Length; i++){
			initialObjects[i].SetActive(true);
		    }
		}		
	    });

        }
    }

}
