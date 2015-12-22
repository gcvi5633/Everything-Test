using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour {

	public Slider volumeslider;
	public Text playtext;//改變 Play 按鈕的文字顯示
	private int status = 0;//設計music的狀態 0 的時候是準備播放，1是暫停，2是繼續
    AudioSource audio1;//導入 AudioSource

    void Start () {
		//讓 audio1 取得 AudioSource
        audio1 = GetComponent<AudioSource>();
	}

	void Update () {
        audio1.volume = volumeslider.GetSliderPercent();
    }

	public void PlayMusic(){
        if(status == 0){
		    audio1.Play();
		    playtext.text = "Pause";
		    status ++;
		}
		else if(status == 1){
            audio1.Pause();
            playtext.text = "Play";
		    status ++;
		}
        else if(status == 2){
			audio1.UnPause();
			playtext.text = "Pause";
			status --;
		}
	}

    //按下 Stop 按鈕時停止音樂並且將 music 的狀態回到播放前
	public void StopMusic(){
		audio1.Stop();
        playtext.text = "Play";
        status = 0;
    }
}
