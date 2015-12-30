using UnityEngine;
using System.Collections;

public class loadingScreen : MonoBehaviour {

    public string levelToLoad;

    public GameObject background;
    public GameObject text;
    public GameObject progressBar;

    //設一個進度讀取值，這個的值在 0 到 1 之間
    private int loadProgress = 0;
	// Use this for initialization
	void Start () {
        background.SetActive(false);
        text.SetActive(false);
        progressBar.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            //按下 space 就會開始執行 DisplayLoadingScreen 這個程式
            StartCoroutine(DisplayLoadingScreen(levelToLoad));
        }
	}

    IEnumerator DisplayLoadingScreen(string level)
    {
        //將進度讀取介面打開
        background.SetActive(true);
        text.SetActive(true);
        progressBar.SetActive(true);

        /*progressBar.transform.localScale = new Vector3(loadProgress, progressBar.transform.localScale.y, progressBar.transform.localScale.z);

        text.GetComponent<GUIText>().text = "Loading... " + loadProgress + "%";*/

        //設置一個異步讀取的對象   進行異步讀取場景 level 就是要讀取的場景
        AsyncOperation async = Application.LoadLevelAsync(level);

        while (!async.isDone)
        {
            //將讀取的進度值 *100 使之最大可到 100 ，之後轉換為整數
            loadProgress = (int)(async.progress*100);

            //讀取條表現方式控制碼
            progressBar.transform.localScale = new Vector3(async.progress, progressBar.transform.localScale.y, progressBar.transform.localScale.z);

            //Unity 5 之後要使用 GUIText 就要是用下面的方式來抓取 GUIText 裡的參數
            text.GetComponent<GUIText>().text = "Loading... " + loadProgress + "%";

            //回傳 null ，此方法會回到上層的 StartCoroutine ，重新呼叫一次
            yield return null;
        }
    }
}
