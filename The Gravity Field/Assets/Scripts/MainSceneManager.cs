using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainSceneManager : MonoBehaviour, IPointerClickHandler
{
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (gameObject.name == "Level1")
            SceneManager.LoadScene("Level01");
        if (gameObject.name == "Level2")
            SceneManager.LoadScene("Level02");
        if (gameObject.name == "Level3")
            SceneManager.LoadScene("Level03");
        if (gameObject.name == "LevelMain")
            SceneManager.LoadScene("Main");
    }
}
