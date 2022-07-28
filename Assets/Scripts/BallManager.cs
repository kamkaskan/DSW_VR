using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallManager : MonoBehaviour
{
    bool gameInProgress = false;
    int points = 0;
    [SerializeField] Transform buttonColumn;
    [SerializeField] GameObject button;
    [SerializeField] BallThrower thrower;
    [SerializeField] Rotator catcherRotator;
    [SerializeField] Text scoreText;
    [SerializeField] float currentDifficulty = 0f;
    void Start(){
        Invoke("ShowButton", 2);
    }
    
    void ShowButton(){
        StartCoroutine(ShowingButton());
    }

    IEnumerator ShowingButton(){
        yield return new WaitForSeconds(1f);
        for (float i = 0; i < 1f; i += Time.deltaTime / 3f) {
            buttonColumn.localPosition = Vector3.up * Mathf.Lerp(-1f, 1f, i);
            yield return null;
        }
        buttonColumn.localPosition = Vector3.up;
        button.SetActive(true);
    }

    void HideButton(){
        StartCoroutine(HidingButton());
    }

    IEnumerator HidingButton(){
        yield return new WaitForSeconds(1f);
        button.SetActive(false);
        for (float i = 0; i < 1f; i += Time.deltaTime / 1.5f) {
            buttonColumn.localPosition = Vector3.up * Mathf.Lerp(1f, -1f, i);
            yield return null;
        }
        buttonColumn.localPosition = Vector3.up * -1f;
    }

    public void ButtonPressed(){
        Debug.Log("Button Pressed");
        if (!gameInProgress){
            gameInProgress = true;
            HideButton();
            Invoke("ThrowBall", 3);
        }
    }


    public void BallCatched(bool success){
        Debug.Log($"Ball Catched {success}");
        if (success) {
            IncreaseDifficulty();
            UpdatePoints(1);
            Invoke("ThrowBall", Random.Range(2,5));
        }
        else {
            gameInProgress = false;
            ShowButton();
            ResetDifficulty();
            UpdatePoints(-points);
        }
    }

    void ThrowBall(){
        thrower.ThrowBall(currentDifficulty);
    }

    void SetRotatorSpeed(){
        catcherRotator.SetDifficulty(currentDifficulty);
    }

    void UpdatePoints(int change){
        points += change;
        StartCoroutine(UpdatePointsVisual(change > 0));
    }
    IEnumerator UpdatePointsVisual(bool positive) {
        Color color = positive ? Color.green : Color.red;
        
        scoreText.color = color;
        scoreText.text = points.ToString();

        for (float i = 0; i < 1f; i += Time.deltaTime) {
            scoreText.transform.localScale = Vector3.one * Mathf.Lerp(1.2f, 1f, i);
            scoreText.color = Color.Lerp(color, Color.white, i);
            yield return null;
        }
        scoreText.transform.localScale = Vector3.one;
        scoreText.color = Color.white;
    }

    public void IncreaseDifficulty() {
        currentDifficulty += 0.1f;
        if (currentDifficulty > 1f) currentDifficulty = 1f;
    }

    public void ResetDifficulty() {
        currentDifficulty = 0f;
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Space)) ThrowBall();
    }
}
