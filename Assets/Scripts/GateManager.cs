using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateManager : MonoBehaviour
{
    [Tooltip("The scene index which will be switch to")]
    [SerializeField] int SceneIndex;

    [Tooltip("SceneIndex won't work if this is true")]
    [SerializeField] bool LastScene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform == GameManager.Instance.Player)
            switchToScene();
    }
    void switchToScene()
    {
        if(LastScene)
        {
            GameManager.Instance.GameFinished();
        }
        else
        {
            foreach(var act in GameManager.Instance.OnPlayerWinLevel)
            {
                act();
            }

            float delay = GameManager.Instance.SceneTransitionDelay;
            Invoke(nameof(OpenTheScene), delay);
        }
    }
    void OpenTheScene()
    {
        GameManager.Instance.SceneController.OpenSceneAtIndex(SceneIndex);
    }
}
