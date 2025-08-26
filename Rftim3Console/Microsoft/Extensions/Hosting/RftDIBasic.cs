namespace Rftim3Console.Microsoft.Extensions.Hosting
{
    public class RftDIBasic
    {
        public RftDIBasic()
        {
            SteamController steamController = new();
            Gamepad gamepad = new(steamController);

            gamepad.Showcase();
        }

        class Gamepad(IGamepadFunctionality InGamepadFunctionality)
        {
            private readonly IGamepadFunctionality _GamepadFunctionality = InGamepadFunctionality;

            public void Showcase()
            {
                string gamepadName = _GamepadFunctionality.GetGamepadName();
                string message = $"We're using the {gamepadName} right now, do you want to change the vibrating power?";
                Console.WriteLine(message);
            }
        }

        private interface IGamepadFunctionality
        {
            string GetGamepadName();
            void SetVibrationPower(float InPower);
        }

        private class XBoxGamepad : IGamepadFunctionality
        {
            public float VibrationPower = 1.0f;

            public string GetGamepadName() => "Xbox controller";

            public void SetVibrationPower(float InPower) => VibrationPower = Math.Clamp(InPower, 0.0f, 1.0f);
        }

        private class PlaystationJoystick : IGamepadFunctionality
        {
            public float VibratingPower = 100.0f;

            public string GetGamepadName() => "PlayStation controller";

            public void SetVibrationPower(float InPower) => VibratingPower = Math.Clamp(InPower * 100.0f, 0.0f, 100.0f);
        }

        private class SteamController : IGamepadFunctionality
        {
            public double Vibrating = 1.0;

            public string GetGamepadName() => "Steam controller";

            public void SetVibrationPower(float InPower) => Vibrating = Convert.ToDouble(Math.Clamp(InPower, 0.0f, 1.0f));
        }
    }
}
