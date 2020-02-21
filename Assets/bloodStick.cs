using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bloodStick : MonoBehaviour
{
    private ParticleSystem particles;
    public GameObject[] bloodSprites;
    private List<ParticleCollisionEvent> collisionEvents = new List<ParticleCollisionEvent>();

    void Start() {
        particles = GetComponent<ParticleSystem>();
    }

    void Update() {
        
    }

    private void OnParticleCollision(GameObject other) {
        ParticlePhysicsExtensions.GetCollisionEvents(particles, other, collisionEvents);
        
        // int count = collisionEvents.Count;
        // for (int i = 0; i < count; i++) {
        Instantiate(bloodSprites[Random.Range(0, bloodSprites.Length)], collisionEvents[0].intersection, Quaternion.Euler(0f, 0f, 0f));
        // }
    }
}
