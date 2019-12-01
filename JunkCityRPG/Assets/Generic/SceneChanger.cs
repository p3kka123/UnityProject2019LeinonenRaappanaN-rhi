using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{

    [SerializeField] private string targetScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.transform.root.tag == "Player") {
            print("Enter " + targetScene);
            StartCoroutine(SceneFader.Instance.FadeAndLoadScene(SceneFader.FadeDirection.In,targetScene));
            
        }
    }
}
