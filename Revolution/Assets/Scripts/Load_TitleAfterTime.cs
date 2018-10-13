using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_TitleAfterTime : MonoBehaviour {

    [SerializeField]
    private float delayBeforeLoading = 10f;

    [SerializeField]
    private string SceneNameToLoad;

    private float timeElapsed;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        timeElapsed += Time.deltaTime;

        if (timeElapsed > delayBeforeLoading)
        {
            SceneManager.LoadScene(SceneNameToLoad);
        }
		
	}
}
