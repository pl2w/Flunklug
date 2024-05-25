using DevHoldableEngine;
using UnityEngine;

namespace Flunklug.Behaviours
{
    public class Flunksona : DevHoldable
    {
        public FlunksonaDescriptor descriptor { get; set; }
        public Rigidbody rb { get; set; }
        public GorillaVelocityEstimator velocityEstimator { get; set; }

        public Flunksona()
        {
            descriptor = gameObject.GetComponent<FlunksonaDescriptor>();
            velocityEstimator = gameObject.AddComponent<GorillaVelocityEstimator>();

            gameObject.layer = 8;
            for (int i = 0; i < transform.childCount; i++)
                transform.GetChild(i).gameObject.layer = 8;

            rb = GetComponent<Rigidbody>();
            rb.position = new Vector3(-67.1012f, 12.12f, -82.6848f);

            GrabDistance = GetComponent<SphereCollider>().radius; 
        }

        public override void OnGrab(bool isLeft)
        {
            if(rb != null)
                rb.isKinematic = true;
        }

        public override void OnDrop(bool isLeft)
        {
            if (rb != null)
            {
                rb.isKinematic = false;
                rb.velocity = velocityEstimator.linearVelocity * descriptor.ThrowStrength;
                rb.angularVelocity = velocityEstimator.angularVelocity;
            }
        }
    }
}
