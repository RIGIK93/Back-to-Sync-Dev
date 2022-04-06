using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDoor : MonoBehaviour
{
    private BoxCollider2D col;
    private SpriteRenderer rn;
    private Animator anim;
    private AudioManager manager;
    [SerializeField] private AudioClip doorSound;
    // Start is called before the first frame update
    void Start()
    {
        //manager = GetComponent<AudioManager>();
        anim = GetComponent<Animator>();
        col = GetComponent<BoxCollider2D>();
    }

    public void Open()
    {

        col.enabled = false;
        //if (!manager.isPlaying()) manager.Play(doorSound);
        anim.SetBool("IsOpened", true);
    }

    public void Close()
    {
        col.enabled = true;
        //if (!manager.isPlaying()) manager.Play(doorSound);
        anim.SetBool("IsOpened", false);
    }
}
