
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public GameObject textGameObject;
    public Button button;

    private void Start()
    {
        bool isActive = true;

        button.onClick.AddListener(() =>
        {
            isActive = !isActive;
            textGameObject.SetActive(isActive);
        });
    }
}

