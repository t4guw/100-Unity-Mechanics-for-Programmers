# Bomb that Destroys Enemies in Radius

## Description
This mechanic will show how to implement a bomb that destroys enemies within a given radius when it explodes.

## Implementation
There are several steps that need to be taken in the Unity Editor.

   1. Set up the scene with enemies and a bomb.
   2. Create a BlastRadius object and save it as a prefab with the file path "Assets/Resources/Prefabs/BlastRadius".
   3. Set a condition to trigger DenonateBomb(). In this example, a button is use to trigger the bomb.
   


Put the following BombBehavior script on your bomb object.

    using UnityEngine;

    public class BombBehavior : MonoBehaviour
    {
        public void DetonateBomb()
        {
            GameObject blast = Instantiate(Resources.Load("Prefabs/BlastRadius") as GameObject);
            Vector3 p = this.transform.position;
            blast.transform.position = p;
            Destroy(this.gameObject);
        }
    }


Put the following BlastBehavior script on your BlastRadius prefab, changing the blastRadiusSize as seen fit.

    using UnityEngine;

    public class BlastBehavior : MonoBehaviour
    {
        float blastRadiusSize = 5;
        Vector3 blastIncrease = new Vector3(0.005f, 0.005f, 0f);

        void Update()
        {
            if (this.transform.localScale.x < blastRadiusSize)
            {
                this.transform.localScale += blastIncrease;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Destroy(collision.gameObject);
        }
    }
