using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CarSelection : MonoBehaviour
{
    [Header("Buttons and Canvas")]
    public Button nextButton;
    public Button previousButton;

    [Header("Cameras")]
    public GameObject cam1;
    public GameObject cam2;

    [Header("Buttons and Canvas")]
    public GameObject SelectionCanvas;
    public GameObject SkipButton;
    public GameObject PlayButton;

    private int currentCar;
    private GameObject[] carList;

    private void Awake()
    {
        SelectionCanvas.SetActive(false);
        PlayButton.SetActive(false);
        cam2.SetActive(false);

        ChooseCar(0);
    }

    private void Start()
    {
        currentCar = PlayerPrefs.GetInt("CarSelected", 0);

        // Feeding car models to carList array
        carList = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            carList[i] = transform.GetChild(i).gameObject;
        }

        // Deactivate all cars first
        foreach (GameObject go in carList)
        {
            go.SetActive(false);
        }

        // Activate the current/selected one
        if (carList[currentCar] != null)
        {
            carList[currentCar].SetActive(true);
        }
    }

    private void ChooseCar(int index)
    {
        // Disable buttons at edges
        previousButton.interactable = (index != 0);
        nextButton.interactable = (index != transform.childCount - 1);

        // Activate only the selected car
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == index);
        }
    }

    public void SwitchCar(int direction)
    {
        currentCar += direction;

        // Optional: clamp the value (prevents out-of-bounds even if buttons are disabled)
        currentCar = Mathf.Clamp(currentCar, 0, transform.childCount - 1);

        ChooseCar(currentCar);
    }

    public void PlayGame()
    {
        PlayerPrefs.SetInt("CarSelected", currentCar);
        SceneManager.LoadScene("scene_day");   // ← make sure this scene name exists
    }

    public void SkipButtonFunc()   // renamed to avoid confusion with object name
    {
        SelectionCanvas.SetActive(true);
        PlayButton.SetActive(true);
        SkipButton.SetActive(false);

        cam1.SetActive(false);
        cam2.SetActive(true);
    }
}