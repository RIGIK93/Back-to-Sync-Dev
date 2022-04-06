using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] private UnityEvent ButtonPressed;
    [SerializeField] private UnityEvent ButtonReleased;
    public List<string> allowedTags;
    private Sprite buttonReleased;
    [SerializeField] private Sprite buttonPressed;
    [SerializeField] private AudioClip buttonClick;
    private AudioManager manager;
    private SpriteRenderer rend;
    private int Counter = 0;

    private void Start()
    {
        manager = GetComponent<AudioManager>();
        rend = GetComponent<SpriteRenderer>();
        buttonReleased = rend.sprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isValid(collision)) return;
        if (Counter == 0)
        {
            ButtonPressed.Invoke();
            manager.Play(buttonClick);
        }
        Counter++;
        rend.sprite = buttonPressed;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!isValid(collision)) return;
        if (Counter > 0)
            Counter--;
        if (Counter == 0)
        {
            ButtonReleased.Invoke();
            rend.sprite = buttonReleased;
            manager.Play(buttonClick);
        }
    }

    bool isValid(Collider2D col)
    {
        if (allowedTags.Contains(col.gameObject.tag))
            return true;
        return false;
    }
}
