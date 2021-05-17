using UnityEngine;

namespace FoodFight.Scripts
{
    public class Foodstuff : GrabbableObject
    {
        [SerializeField] private float _throwForce;
        
        private Grabber _hand;

        public override void OnHoverStart()
        {
            // No hover effects
        }
        
        public override void OnHoverEnd()
        {
            // No hover effects
        }

        public override void OnGrabbed(Grabber hand)
        {
            // Remember the hand the picked up the foodstuff
            _hand = hand;

            base.OnGrabbed(hand);
        }

        public override void OnDropped()
        {
            base.OnDropped();
            
            // Throw the food forward in the hand's direction
            GetComponent<Rigidbody>().AddForce(_hand.transform.forward * _throwForce);
        }
    }
}
