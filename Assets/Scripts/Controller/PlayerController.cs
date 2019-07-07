using Interface;

namespace Controller
{
    public class PlayerController : BaseController, IInit, IUpdate
    {
        private readonly IMotor _motor;

        public PlayerController(IMotor motor)
        {
            _motor = motor;
        }

        public void OnStart()
        {
            On();
        }

        public void OnUpdate()
        {
            _motor.Move();
        }
    }
}