using UnityEngine;

public class CozzleCharacter : MonoBehaviour
{

    public GameObject controlIndicator;

    void Start(){
        controlIndicator.SetActive(false);
    }

    public void SetControl(bool control){
        controlIndicator.SetActive(control);
    }

}
