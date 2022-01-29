using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject[] initialObjects;

    void Update(){
	if(Input.GetKeyDown("space") || Input.GetKeyDown("enter")) {
	    if(menuPanel.active) {
                menuPanel.SetActive(false);

                for (int i = 0; i < initialObjects.Length; i++){
                    initialObjects[i].SetActive(true);
                }
	    }
        }
    }

}
