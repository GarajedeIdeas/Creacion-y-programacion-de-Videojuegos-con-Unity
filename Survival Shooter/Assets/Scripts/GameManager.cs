using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject panelGameOver;
    public TextMeshProUGUI textScore;

    [Header("Array Positions")]
    public Transform[] positions;//array de posiciones (empty objects)
    [Header("Array Enemies")]
    public GameObject[] enemyPrefab;
    [Space]
    public Transform parentEnemies;//el gameobject vacío que va a ser el padre de los clones de los enemigos

    [Tooltip("Tiempo entre enemigos")]
    public float time;//cada cuanto tiempo voy a estar instanciando enemigos

    int score;//puntuación total

    void Start()
    {
        InvokeRepeating("CreateEnemy", time, time);
    }

    void CreateEnemy()
    {
        int pos = Random.Range(0, positions.Length);
        int enemy = Random.Range(0, enemyPrefab.Length);
        GameObject cloneEnemy = Instantiate(enemyPrefab[enemy], positions[pos].position, positions[pos].rotation);
        cloneEnemy.transform.SetParent(parentEnemies);
    }

    public void GameOver()
    {
        panelGameOver.SetActive(true);
    }
    public void LoadScene(string name)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(name);
    }
    //función pública que vamos a llamar desde el script de salud del enemigo cuando este muere
    public void ScoreEnemy(int scoreValue)
    {
        score += scoreValue;
        textScore.text = "Score: " + score.ToString();
    }
}
