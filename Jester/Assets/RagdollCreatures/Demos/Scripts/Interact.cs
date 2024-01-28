using UnityEngine;
using UnityEngine.InputSystem;

namespace RagdollCreatures
{
    [RequireComponent(typeof(Collider2D))]
    public class Interact : MonoBehaviour, IInputSystem
    {
        public GameObject root;
        public Rigidbody2D parent;
        public Transform position;

        public bool useNewInputSystem = InputSystemSwitcher.UseNewInputSystem;
        public float throwForce = 10f;

        private GameObject nearestInteractable;
        private GameObject currentInteractable;
        private Vector2 aimPosition;

        void Awake()
        {
            useNewInputSystem = InputSystemSwitcher.UseNewInputSystem;
        }

        void Update()
        {
            if (!useNewInputSystem)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    OnInteract();
                }

                if (Input.GetMouseButtonDown(0))
                {
                    OnAttack();
                }

                if (Input.GetMouseButtonDown(1))
                {
                    OnThrow();
                }
            }
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
            if (context.started && useNewInputSystem)
            {
                OnAttack();
            }
        }

        private void OnAttack()
        {
            if (null != currentInteractable)
            {
                IInteractable interactable = currentInteractable.GetComponent<IInteractable>();
                if (null != interactable)
                {
                    interactable.interact(parent.gameObject);
                }
            }
        }

        public void OnAim(InputAction.CallbackContext context)
        {
            if (useNewInputSystem)
            {
                aimPosition = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
            }
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.started && useNewInputSystem)
            {
                OnInteract();
            }
        }

        private void OnInteract()
        {
            Reset();

            if (null != nearestInteractable && null == nearestInteractable.transform.parent && null == currentInteractable)
            {
                foreach (Collider2D collider in root.GetComponentsInChildren<Collider2D>())
                {
                    Physics2D.IgnoreCollision(nearestInteractable.GetComponent<Collider2D>(), collider);
                }

                nearestInteractable.transform.SetParent(position, false);
                nearestInteractable.transform.position = position.position;

                Rigidbody2D rb = nearestInteractable.GetComponent<Rigidbody2D>();
                if (null != rb)
                {
                    //rb.isKinematic = true;
                    /*rb.gravityScale = 0;
                    rb.drag = 10;
                    rb.constraints = RigidbodyConstraints2D.FreezeRotation;*/
                }

                Equipable equipable = nearestInteractable.GetComponent<Equipable>();
                if (null != equipable)
                {
                    nearestInteractable.transform.rotation = Quaternion.Euler(0.0f, 0.0f, equipable.rotationOffset + position.rotation.eulerAngles.z);
                }

                RotationFlipper rotationFlipper = nearestInteractable.GetComponent<RotationFlipper>();
                if (null != rotationFlipper)
                {
                    rotationFlipper.activeRotationFlip = true;
                }

                currentInteractable = nearestInteractable;
            }
        }

        private void OnThrow()
        {
            /*if (null != currentInteractable)
            {
                Rigidbody2D rb = currentInteractable.GetComponent<Rigidbody2D>();
                if (null != rb)
                {
                    rb.isKinematic = false;
                    Vector2 throwDirection = -currentInteractable.transform.right;
                    rb.AddForce(throwDirection * throwForce, ForceMode2D.Impulse);
                    Reset();
                }
            }*/
        }

        public void Reset()
        {
            if (null != currentInteractable)
            {
                foreach (Collider2D collider in root.GetComponentsInChildren<Collider2D>())
                {
                    Physics2D.IgnoreCollision(currentInteractable.GetComponent<Collider2D>(), collider, false);
                }

                Rigidbody2D rb = currentInteractable.GetComponent<Rigidbody2D>();
                if (null != rb)
                {
                    //rb.isKinematic = false;
                    /*rb.gravityScale = 1;
                    rb.drag = 0;
                    rb.constraints = RigidbodyConstraints2D.None;*/
                }

                RotationFlipper rotationFlipper = currentInteractable.GetComponent<RotationFlipper>();
                if (null != rotationFlipper)
                {
                    rotationFlipper.activeRotationFlip = false;
                }

                currentInteractable.transform.parent = null;
                currentInteractable = null;
            }
        }

        public void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Equipable"))
            {
                nearestInteractable = col.gameObject;
            }
        }

        public void OnTriggerExit2D(Collider2D col)
        {
            if (col.CompareTag("Equipable") && col.gameObject == nearestInteractable)
            {
                nearestInteractable = null;
            }
        }

        public bool UseNewInputSystem()
        {
            return useNewInputSystem;
        }

        public void SetUseNewInputSystem(bool useNewInputSystem)
        {
            this.useNewInputSystem = useNewInputSystem;
        }
    }
}
