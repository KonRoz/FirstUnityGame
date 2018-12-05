using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour {

    //level name is inputed manually winthin the editor -- i.e. On Click Attribute for Button

	public void Select(string levelName)
    {
        //Literal Scene name -- does not have to be the build index :)
        SceneManager.LoadScene(levelName);
    }
}
