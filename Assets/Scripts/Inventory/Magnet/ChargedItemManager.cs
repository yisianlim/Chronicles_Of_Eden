using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargedItemManager : MonoBehaviour {
    // Keeps track of the charged item movement 100 times per second.
    private float cycleInterval = 0.01f;

    private List<ChargedItem> chargedItems;
    private List<MovingChargedItem> movingChargedItems;

	void Start () {
        chargedItems = new List<ChargedItem>(FindObjectsOfType<ChargedItem>());
        movingChargedItems = new List<MovingChargedItem>(FindObjectsOfType<MovingChargedItem>());

        foreach (MovingChargedItem mci in movingChargedItems)
        {
            StartCoroutine(Cycle(mci));
        }

    }

    public IEnumerator Cycle(MovingChargedItem mci) {
        bool isFirst = true;
        while (true) {
            //// At the first go, we are going to wait for a little while
            //// to avoid spiky movements. 
            //if (isFirst) {
            //    isFirst = false;
            //    yield return new WaitForSeconds(Random.Range(0, cycleInterval));
            //}
            ApplyMagneticForce(mci);
            yield return new WaitForSeconds(cycleInterval);
        }
    }

    private void ApplyMagneticForce(MovingChargedItem mci) {
        Vector3 newForce = Vector3.zero;

        foreach (ChargedItem ci in chargedItems) {
            if (mci == ci)
                continue;

            float distance = Vector3.Distance(mci.transform.position, ci.gameObject.transform.position);
            float force = 1000 * mci.charge * ci.charge / Mathf.Pow(distance, 2);

            Vector3 direction = mci.transform.position - ci.transform.position;
            direction.Normalize();

            newForce += force * direction * cycleInterval;

            if (float.IsNaN(newForce.x))
                newForce = Vector3.zero;

            mci.rb.AddForce(newForce);
        }
    }
}
