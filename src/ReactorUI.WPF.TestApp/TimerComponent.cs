using ReactorUI.Widgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactorUI.WPF.TestApp
{
    internal class TimerComponent : Component
    {
        private System.Timers.Timer _timer = new System.Timers.Timer(1000);

        public TimerComponent()
        {
            _timer.Elapsed += _timer_Elapsed;
            _timer.Start();
        }

        protected override void OnDeactivate()
        {
            _timer.Elapsed -= _timer_Elapsed;

            base.OnDeactivate();
        }

        private void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"Timer.Elapsed(ThreadId={System.Threading.Thread.CurrentThread.ManagedThreadId})");
            Invalidate();
        }

        public override VisualNode Render()
        {
            return new Button(DateTime.Now.ToString()).OnClick(OnStartStop);
        }

        private void OnStartStop()
        {
            System.Diagnostics.Debug.WriteLine($"OnStartStop(RenderThreadId={System.Threading.Thread.CurrentThread.ManagedThreadId})");
            _timer.Enabled = !_timer.Enabled;
        }
    }
}
