using UnityEngine;
using UnityEngine.UI;

public class VolumeButton : MonoBehaviour
{
  public Button volume;
  public Sprite soundOn;
  public Sprite soundOff;

  void Start() {
    if (AudioListener.volume == 1) {
      volume.image.sprite = soundOn;
    }
    else {
      volume.image.sprite = soundOff;
    }
  }
  
  public void Volume()
  {
    if (AudioListener.volume == 1) {
      AudioListener.volume = 0;
      volume.image.sprite = soundOff;
    }
    else {
      AudioListener.volume = 1;
      volume.image.sprite = soundOn;
    }
  }

}
