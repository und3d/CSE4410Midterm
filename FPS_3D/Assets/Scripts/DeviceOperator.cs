using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceOperator : MonoBehaviour
{
    public float radius = 1.5f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);

            foreach( Collider collider in hitColliders)
            {
                Vector3 hitPosition = collider.transform.position;
                hitPosition.y = transform.position.y;

                Vector3 direction = hitPosition - transform.position;
                if (Vector3.Dot(transform.forward, direction.normalized) > 0.5f)
                {
                    collider.SendMessage("Operate", SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }
}
