using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallThrower : MonoBehaviour
{
    [SerializeField] Vector3 minDirection;
    [SerializeField] float minPower = 5f;
    [SerializeField] Vector3 maxDirection;
    [SerializeField] float maxPower = 25f;
    [SerializeField] GameObject ballPrefab;

    [SerializeField] GameObject Visual;
    float _currentDifficulty;

    public void ThrowBall(float currentDifficulty) {
        _currentDifficulty = currentDifficulty;
        StartCoroutine("Throwing");
    }

    IEnumerator Throwing() {
        for (float i = 0; i < 1f; i += Time.deltaTime) {
            Visual.transform.localScale = Vector3.one * Mathf.Lerp(0.5f,1.25f,i);
            yield return null;
        }
        Visual.transform.localScale = Vector3.one * 0.5f;
        Throw();
    }

    void Throw() {
        GameObject ball = Instantiate(ballPrefab, this.transform.position, Quaternion.identity);
        float power = Mathf.Lerp(minPower, maxPower, _currentDifficulty);
        Vector3 direction = Vector3.Lerp(minDirection, maxDirection, _currentDifficulty);
        ball.GetComponent<Rigidbody>().AddForce(direction * power, ForceMode.Impulse);
    }
}
