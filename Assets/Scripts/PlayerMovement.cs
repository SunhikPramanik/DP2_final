using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb2D;
    public bool pause;

    public static PlayerMovement instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.constraints = RigidbodyConstraints2D.None;
        animator.SetBool("Complete", false);
        pause = true;
        StartCoroutine(PauseControls());
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Spike"))
        {
            Debug.Log("hi");
            pause = true;
            rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
            animator.SetTrigger("IsDead");
            AudioController.instance.audioSource.PlayOneShot(AudioController.instance.deathClip);
            StartCoroutine(ReloadSceneAfterPause());
        }
        else pause = false; 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Door"))
        {
            rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
            animator.SetBool("Complete", true);
            AudioController.instance.audioSource.PlayOneShot(AudioController.instance.passClip);
            pause = true;
            StartCoroutine(LoadSceneAfterPause());
        }
        else
        {
            pause = false; rb2D.constraints = RigidbodyConstraints2D.None; animator.SetBool("Complete", false);
        }
    }
    public IEnumerator ReloadSceneAfterPause()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public IEnumerator LoadSceneAfterPause()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator PauseControls()
    {
        yield return new WaitForSeconds(1f);
        pause = false;
    }
}
