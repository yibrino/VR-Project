using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CarSelection : MonoBehaviour
{
    [Header("Buttons and Canvas")]
    public Button nextButton;
    public Button previousButton;

    private int currentCar;
    private GameObject[] carList;

    private void Awake()
    {
        chooseCar(0);
    }

    private void Start()
    {
        // Load previously selected car (default to 0 if not found)
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

        // Activate the selected car
        if (currentCar >= 0 && currentCar < carList.Length && carList[currentCar] != null)
        {
            carList[currentCar].SetActive(true);
        }

        // Make sure buttons reflect current state
        chooseCar(currentCar);
    }

    private void chooseCar(int index)
    {
        currentCar = index;

        // Update button interactability
        previousButton.interactable = (currentCar != 0);
        nextButton.interactable = (currentCar != transform.childCount - 1);

        // Show only the selected car
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == index);
        }
    }

    public void switchCar(int switchCars)
    {
        currentCar += switchCars;

        // Optional: clamp to valid range (prevents out-of-bounds)
        currentCar = Mathf.Clamp(currentCar, 0, transform.childCount - 1);

        chooseCar(currentCar);
    }

    public void playGame()
    {
        PlayerPrefs.SetInt("CarSelected", currentCar);
        SceneManager.LoadScene("scene_day");
    }
}