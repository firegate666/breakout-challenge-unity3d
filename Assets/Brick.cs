using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int Health = 3;

    private Renderer _renderer;
    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        var ball = collision.gameObject.GetComponent<Ball>();

        if (ball != null)
        {
            Health--;

            Color c = _renderer.material.color;
            c.a = c.a / 2.0f;
            _renderer.material.color = c;

            if (Health <= 0)
            {
                Destroy(gameObject);
                GameManager.Instance.BrickDestroyed();
            }
        }
    }
}
