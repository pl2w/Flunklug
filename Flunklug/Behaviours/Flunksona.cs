using DevHoldableEngine;
using UnityEngine;

namespace Flunklug.Behaviours
{
    public class Flunksona : DevHoldable
    {
        public FlunksonaDescriptor descriptor { get; set; }
        public Rigidbody rb { get; set; }
        public GorillaVelocityEstimator velocityEstimator { get; set; }

        Vector3 _prevPosition;

        public Flunksona()
        {
            try
            {
                _prevPosition = transform.position;

                descriptor = gameObject.GetComponent<FlunksonaDescriptor>();
                velocityEstimator = gameObject.AddComponent<GorillaVelocityEstimator>();

                gameObject.layer = 8;

                for (int i = 0; i < transform.childCount; i++)
                    transform.GetChild(i).gameObject.layer = 8;

                rb = GetComponent<Rigidbody>();
                rb.position = new Vector3(-67.1012f, 12.12f, -82.6848f);

                GrabDistance = GetComponent<SphereCollider>().radius;
            }
            catch (System.Exception)
            {

                GameObject.Destroy(this.gameObject);
            }
        }

        public void Update()
        {
            float velocity = rb.velocity.magnitude;

            if (descriptor.FastMoveAudio == null)
                return;

            if (velocity >= descriptor.FastMoveSpeed)
            {
                descriptor.FastMoveAudio.loop = true;
                if (!descriptor.FastMoveAudio.isPlaying)
                    descriptor.FastMoveAudio.Play();
            }
            else
            {
                descriptor.FastMoveAudio.loop = false;
            }
        }

        public override void OnGrab(bool isLeft)
        {
            if(rb != null)
                rb.isKinematic = true;

            if(descriptor.GrabAudio != null)
                descriptor.GrabAudio.Play();
        }

        public override void OnDrop(bool isLeft)
        {
            if (rb != null)
            {
                rb.isKinematic = false;
                rb.velocity = velocityEstimator.linearVelocity * descriptor.ThrowStrength;
                rb.angularVelocity = velocityEstimator.angularVelocity;
            }

            if (descriptor.DropAudio != null)
                descriptor.DropAudio.Play();
        }

        void OnCollisionEnter(Collision collision)
        {
            if (descriptor.CollisionAudio != null && rb.velocity.magnitude > 0.5f)
                descriptor.CollisionAudio.Play();
        }
    }
}
