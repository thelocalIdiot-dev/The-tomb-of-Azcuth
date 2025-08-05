using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

namespace Dialog
{
    public class DialogManager : MonoBehaviour
    {
        [Header("UI Elements")]
        [SerializeField] private GameObject thoughtPanel;
        [SerializeField] private TextMeshProUGUI thoughtText;
        
        [Header("Settings")]
        [SerializeField] private float displayDuration = 3f;
        [SerializeField] private float fadeSpeed = 2f;
        
        private static DialogManager instance;
        private Queue<string> thoughtQueue = new Queue<string>();
        private bool isDisplayingThought = false;
        private CanvasGroup thoughtCanvasGroup;
        
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
                return;
            }
            
            if (thoughtPanel != null)
            {
                thoughtCanvasGroup = thoughtPanel.GetComponent<CanvasGroup>();
                if (thoughtCanvasGroup == null)
                {
                    thoughtCanvasGroup = thoughtPanel.AddComponent<CanvasGroup>();
                }
                thoughtPanel.SetActive(false);
            }
        }
        
        public static void ShowThought(string thoughtText)
        {
            if (instance != null)
            {
                instance.QueueThought(thoughtText);
            }
        }
        
        private void QueueThought(string thought)
        {
            thoughtQueue.Enqueue(thought);
            
            if (!isDisplayingThought)
            {
                StartCoroutine(DisplayNextThought());
            }
        }
        
        private IEnumerator DisplayNextThought()
        {
            while (thoughtQueue.Count > 0)
            {
                isDisplayingThought = true;
                string currentThought = thoughtQueue.Dequeue();
                
                yield return StartCoroutine(ShowThoughtCoroutine(currentThought));
            }
            
            isDisplayingThought = false;
        }
        
        private IEnumerator ShowThoughtCoroutine(string thought)
        {
            if (thoughtPanel == null || thoughtText == null) yield break;
            
            thoughtText.text = thought;
            thoughtPanel.SetActive(true);
            
            yield return StartCoroutine(FadeIn());
            
            yield return new WaitForSeconds(displayDuration);
            
            yield return StartCoroutine(FadeOut());
            
            thoughtPanel.SetActive(false);
        }
        
        private IEnumerator FadeIn()
        {
            float alpha = 0f;
            while (alpha < 1f)
            {
                alpha += Time.deltaTime * fadeSpeed;
                thoughtCanvasGroup.alpha = alpha;
                yield return null;
            }
            thoughtCanvasGroup.alpha = 1f;
        }
        
        private IEnumerator FadeOut()
        {
            float alpha = 1f;
            while (alpha > 0f)
            {
                alpha -= Time.deltaTime * fadeSpeed;
                thoughtCanvasGroup.alpha = alpha;
                yield return null;
            }
            thoughtCanvasGroup.alpha = 0f;
        }
        
        private void Update()
        {
            if (isDisplayingThought && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.KeypadEnter)))
            {
                StopAllCoroutines();
                thoughtPanel.SetActive(false);
                isDisplayingThought = false;
                
                if (thoughtQueue.Count > 0)
                {
                    StartCoroutine(DisplayNextThought());
                }
            }
        }
    }
}