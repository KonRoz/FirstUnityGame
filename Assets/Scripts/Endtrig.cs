using UnityEngine;

public class Endtrig : MonoBehaviour {

    public GameManager manager;

    void OnTriggerEnter()
    {
        manager.CompleteLevel();    
    }

}
