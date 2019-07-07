using Model;
using View;

namespace Controller
{
    public class BaseController
    {
        protected UiInterface UiInterface;

        protected BaseController()
        {
            UiInterface = new UiInterface();
        }
        
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