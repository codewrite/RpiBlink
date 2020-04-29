using System.Device.Gpio;
using System.Threading;
using RpiBlinkLib;

namespace RpiBlinkApp
{
    public class Blink
    {
        private readonly GpioController _gpioController;
        private readonly Led _led;

        public Blink()
        {
             _gpioController = new GpioController();
            _led = new Led(_gpioController);
        }
        
        public void SetRedLed(bool on) => _led.SetRed(on);
        public void SetGreenLed(bool on) => _led.SetGreen(on);

        public void LedCycleTest()
        {
            int num = 0;
            while (true)
            {
                _led.SetGreen((num & 1) != 0);
                _led.SetRed((num & 2) != 0);
                if (++num > 3) num = 0;
                Thread.Sleep(125);
            }
        }

    }
}