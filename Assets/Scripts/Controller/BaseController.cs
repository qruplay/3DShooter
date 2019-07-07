using Model;

namespace Controller
{
    public class BaseController
    {
        public bool IsActive { get; private set; }

        public virtual void On()
        {
            On(null);
        }

        public virtual void On(BaseModel obj)
        {
            IsActive = true;
        }

        public virtual void Off()
        {
            IsActive = false;
        }

        public void Switch()
        {
            if (IsActive)
            {
                Off();
            }
            else
            {
                On();
            }
        }
    }
}