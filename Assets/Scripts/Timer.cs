using System.Collections;
using UnityEngine;
using UnityEngine.UI;                    // Required for Text (UI)
using System.Collections.Generic;        

public class Timer : MonoBehaviour
{
    [Header("Timer")]
    public float countDownTimer = 5f;

    [Header("Things to stop")]
    public PlayerCarController playerCarController;
    public PlayerCarController playerCarController1;
    public PlayerCarController playerCarController2;


    public OpponentCar opponentCar;
    public OpponentCar opponentCar1;
    public OpponentCar opponentCar2;
    public OpponentCar opponentCar3;
    public OpponentCar opponentCar4;

    public Text countDownText;

    void Start()
    {
        // Start the countdown coroutine
        StartCoroutine(TimerCountdown());
    }

    void Update()
    {
        // Keep cars stopped until countdown reaches 0
        if (countDownTimer > 1)
        {
            playerCarController.accelerationForce = 0f;
            playerCarController1.accelerationForce = 0f;
            playerCarController2.accelerationForce = 0f;


            opponentCar.movingSpeed     = 0f;
            opponentCar1.movingSpeed    = 0f;
            opponentCar2.movingSpeed    = 0f;
            opponentCar3.movingSpeed    = 0f;
            opponentCar4.movingSpeed    = 0f;
        }
        // When countdown hits 0 → start the race
        else if (countDownTimer == 0)
        {
            // Only apply once (or you can move this to the coroutine end)
            playerCarController.accelerationForce = 300f;
            playerCarController1.accelerationForce = 300f;
            playerCarController2.accelerationForce = 300f;



            opponentCar.movingSpeed     = 12f;
            opponentCar1.movingSpeed    = 13f;
            opponentCar2.movingSpeed    = 14f;
            opponentCar3.movingSpeed    = 9f;
            opponentCar4.movingSpeed    = 8f;

            // Optional: prevent repeated assignment every frame
            countDownTimer = -1f; // or use a bool hasRaceStarted
        }
    }

    private IEnumerator TimerCountdown()
    {
        while (countDownTimer > 0)
        {
            // Update UI text (shows 5, 4, 3, 2, 1)
            countDownText.text = countDownTimer.ToString("0");

            yield return new WaitForSeconds(1f);
            countDownTimer--;
        }

        // Show "GO!" for 1 second
        countDownText.text = "GO!";
        yield return new WaitForSeconds(1f);

        // Hide countdown text
        countDownText.gameObject.SetActive(false);

        // Optional: set timer to 0 or negative to trigger race start in Update
        countDownTimer = 0f;
    }
}