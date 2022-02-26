using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Starflow.Editor.Utils
{
    public class EditorCameraComponent : Component
    {
        private Quaternion _orientation = Quaternion.Identity;
        private Vector3 _translation = Vector3.Zero;
        private bool _isDirty;

        private Matrix _view;
        public Matrix _projection;

        public float _fov;
        public float _aspect;
        private float _near;
        private float _far;

        private Vector2 projectionSize;

        public float Fov => _fov;

        public float Aspect => _aspect;

        public float Near => _near;

        public float Far => _far;

        public Matrix Projection => _projection;

        public Vector3 Position
        {
            get => _translation;
            set
            {
                _isDirty = true;
                _translation = value;
            }
        }

        public Matrix View
        {
            get
            {
                if (!_isDirty)
                    return _view;

                _view = Matrix.Invert(Matrix.CreateFromQuaternion(_orientation) * Matrix.CreateTranslation(_translation));
                return _view;
            }
        }

        public EditorCameraComponent()
        {
            _projection = Matrix.Identity;
            _translation -= new Vector3(0.0001f, 0, 0);
        }

        public EditorCameraComponent(int width, int height, float near, float far)
        {
            _near = near;
            _far = far;
            _projection = Matrix.CreateOrthographic(width, height, near, far);
        }

        public EditorCameraComponent(float fov, float aspect, float near, float far)
        {
            _fov = fov;
            _aspect = aspect;
            _near = near;
            _far = far;
            _projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(fov), aspect, near, far);
        }

        public Vector3 ScreenToWorld(Viewport viewport, Vector2 mousePosition, bool near = true)
        {
            return viewport.Unproject(new Vector3(mousePosition, near ? 0 : 1), Projection,
                View, Matrix.Identity);
        }

        public Vector3 WorldToScreen(Viewport viewport, Vector3 worldPosition)
        {
            return viewport.Project(worldPosition, Projection, View, Matrix.Identity);
        }

        public void Move(Vector3 movement)
        {
            _translation.X += movement.X;
            _translation.Y += movement.Y;
            _translation.Z += movement.Z;
            _isDirty = true;
        }

        public void MoveLocal(Vector3 movement)
        {
            _translation += Vector3.Transform(movement, _orientation);
            _isDirty = true;
        }

        public void Rotate(Vector3 axis, float angle)
        {
            var radians = MathHelper.ToRadians(angle);
            _orientation = Quaternion.CreateFromAxisAngle(axis, radians) * _orientation;
            _orientation.Normalize();
            _isDirty = true;
        }

        public void RotateLocal(Vector3 axis, float angle)
        {
            var radians = MathHelper.ToRadians(angle);
            _orientation = _orientation * Quaternion.CreateFromAxisAngle(axis, radians);
            _orientation.Normalize();
            _isDirty = true;
        }

        public void OnResize(int width, int height, float near, float far)
        {
            _near = near;
            _far = far;
            _projection = Matrix.CreateOrthographic(width, height, near, far);
        }
        
        private float dragDebounce = 0.032f;
        private Vector3 clickOrigin;
        private float dragSensitivity = 60.0f; // this should be the fps?
        
        public void Update()
        {
            Vector3 mousePos = ScreenToWorld(StarflowEditor.instance.GraphicsDevice.Viewport, Input.mousePosition);
            mousePos = new Vector3(Input.mousePosition.X, -Input.mousePosition.Y, 0);

            if (Input.GetKey(KeyCode.A))
            Position -= new Vector3(5 * Time.deltaTime, 0, 0);
            
            if (Input.GetMouseButton(2) && dragDebounce > 0)
            {
                this.clickOrigin = mousePos;
                dragDebounce -= Time.deltaTime;
                return;
            }
            else if (Input.GetMouseButton(2))
            {
                Vector3 delta = mousePos - clickOrigin;
                Position -= (delta * Time.deltaTime) * (dragSensitivity);
                // clickOrigin = Vector3.Lerp(clickOrigin, mousePos, Time.deltaTime);
                clickOrigin = mousePos;
            }

            if (dragDebounce <= 0.0f && !Input.GetMouseButton(2))
            {
                dragDebounce = 0.1f;
            }
        }
    }
}