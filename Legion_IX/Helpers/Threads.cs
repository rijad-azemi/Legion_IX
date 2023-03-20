using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Legion_IX.Helpers
{
    public static class Threads
    {
        public static void BlinkingMessage_LOGOUT(Label label, string message)
        {
            int blinkTimes = 5;

            Action blinkAction = () =>
            {
                label.Text = message;

                for (int i = 0; i < blinkTimes; i++)
                {
                    label.ForeColor = Color.Green;

                    Thread.Sleep(1000);

                    label.ForeColor = Color.AntiqueWhite;
                }
            };

            label.Invoke(blinkAction);
        }
    }
}