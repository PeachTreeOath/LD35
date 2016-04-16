using UnityEngine;
using System.Collections;

public class Options : MonoBehaviour {
    private CanvasGroup optionsCanvas;
    // Use this for initialization
    void Start () {
        optionsCanvas = GameObject.Find("Options Screen").GetComponent<CanvasGroup>();
        HideOptions();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ShowOptions()
    {
        optionsCanvas.alpha = 1;
        optionsCanvas.blocksRaycasts = true;
        optionsCanvas.interactable = true;
    }

    public void HideOptions()
    {
        optionsCanvas.alpha = 0;
        optionsCanvas.blocksRaycasts = false;
        optionsCanvas.interactable = false;
    }
}
