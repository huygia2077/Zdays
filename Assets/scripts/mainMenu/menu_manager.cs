using UnityEngine;

public class menu_manager : MonoBehaviour
{
    public void quit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
