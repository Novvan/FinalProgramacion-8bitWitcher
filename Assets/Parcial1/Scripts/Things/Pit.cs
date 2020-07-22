// using System;
// using System.Collections;
// using System.Collections.Generic;
// using System.Runtime.ExceptionServices;
// using UnityEngine;
// using UnityEngine.SceneManagement;
//
// public class Pit : MonoBehaviour
// {
//     [SerializeField] private GameManager _gameManager;
//     private Rigidbody2D _rigidbody;
//
//     private void Awake()
//     {
//         _rigidbody = GetComponent<Rigidbody2D>();
//     }
//
//     private void OnTriggerEnter2D(Collider2D other)
//     {
//         if (other.CompareTag("Player"))
//         {
//             StartCoroutine(PitCoroutine(other.gameObject));
//         }
//     }
//
//     IEnumerator PitCoroutine(GameObject player)
//     {
//         if (player.GetComponent<Player>().Life == 0)
//         {
//             player.SetActive(false);
//             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+3);
//         }
//         else
//         {
//             player.SetActive(false);
//             player.GetComponent<Player>().Damage(1);
//             yield return new WaitForSeconds(2f);
//             player.transform.position = _gameManager.transform.position;
//             player.SetActive(true);
//             Canvas.ForceUpdateCanvases();
//             yield return null;   
//         }
//     }
// }