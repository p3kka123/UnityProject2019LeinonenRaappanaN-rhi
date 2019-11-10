using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorSceneChange : Interactable
{

    [SerializeField] private string sceneToLoad;

    public override void Interact() {
        StartCoroutine(SceneFader.Instance.FadeAndLoadScene(SceneFader.FadeDirection.In,sceneToLoad));
        //SceneManager.LoadScene(sceneToLoad);
    }

}
