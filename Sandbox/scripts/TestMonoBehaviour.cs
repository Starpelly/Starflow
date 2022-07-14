using Starflow;
using System;

public class TestMonoBehaviour : MonoBehaviour
{
    private AudioSource ass = new AudioSource();

    public override void Start()
    {
        ass = gameObject.AddComponent<AudioSource>();
        var sprite = gameObject.AddComponent<SpriteRenderer>();
        sprite.sprite = new Sprite(@"C:\Dev\Starflow\Sandbox\sprites\schizo.png");
        ass.clip = new AudioClip(@"C:\Users\Braedon\Music\MDK - Interlaced [HD].mp3");
        ass.volume = 0.1f;
        ass.playOnAwake = true;
        ass.Play();
        // transform.position = new Vector2(640, 360);
    }

    public override void Update()
    {
        /*
        float speed = 650;
        Vector2 dir = Vector2.Zero;

        if (Input.GetKey(KeyCode.Left))
            dir.x -= 1;
        if (Input.GetKey(KeyCode.Right))
            dir.x += 1;
        if (Input.GetKey(KeyCode.Up))
            dir.y -= 1;
        if (Input.GetKey(KeyCode.Down))
            dir.y += 1;
        if (dir != Vector2.Zero)
            dir.Normalize();

        transform.position += dir * Time.deltaTime * speed;
        */
    }
}

