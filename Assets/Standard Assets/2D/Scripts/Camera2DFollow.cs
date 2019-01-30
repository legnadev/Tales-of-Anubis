using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class Camera2DFollow : MonoBehaviour
    {

		public float verticalCameraPacing;
		public bool fixedVerticalCamera;
		private Vector3 newPosition;

        public Transform target;
        public float damping = 1;
        public float lookAheadFactor = 3;
        public float lookAheadReturnSpeed = 0.5f;
        public float lookAheadMoveThreshold = 0.1f;

        private float m_OffsetZ;
        private Vector3 m_LastTargetPosition;
        private Vector3 m_CurrentVelocity;
        private Vector3 m_LookAheadPos;

        // Use this for initialization
        private void Start()
        {
			
			m_LastTargetPosition = calculatePosition ();
			m_OffsetZ = (transform.position - calculatePosition()).z;
            transform.parent = null;
        }


        // Update is called once per frame
        private void Update()
        {
            // only update lookahead pos if accelerating or changed direction
			float xMoveDelta = (calculatePosition () - m_LastTargetPosition).x;

            bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

            if (updateLookAheadTarget)
            {
                m_LookAheadPos = lookAheadFactor*Vector3.right*Mathf.Sign(xMoveDelta);
            }
            else
            {
                m_LookAheadPos = Vector3.MoveTowards(m_LookAheadPos, Vector3.zero, Time.deltaTime*lookAheadReturnSpeed);
            }

			Vector3 aheadTargetPos = calculatePosition () + m_LookAheadPos + Vector3.forward*m_OffsetZ;
			Vector3 newPos = Vector3.SmoothDamp (transform.position, aheadTargetPos, ref m_CurrentVelocity, damping);

			if (fixedVerticalCamera) {
				//newPosition = new Vector3 (transform.position.x, transform.position.y - verticalCameraPacing, transform.position.z);
				//newPos = Vector3.SmoothDamp (newPosition, aheadTargetPos, ref m_CurrentVelocity, damping);

			} 
            transform.position = newPos;

			m_LastTargetPosition = calculatePosition ();
        }

		private Vector3 calculatePosition(){
			float myVerticalPacing;

			if (!fixedVerticalCamera) {
				myVerticalPacing = 0;
			} else {
				myVerticalPacing = verticalCameraPacing;
			}

			Vector3 omg = new Vector3 (target.position.x, target.position.y - myVerticalPacing, target.position.z);
			return omg;
		}
    }
}
