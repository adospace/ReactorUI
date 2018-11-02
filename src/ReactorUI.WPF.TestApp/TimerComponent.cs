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
        private int _counter = 0;

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
            _counter++;
            Invalidate();
        }

        public override VisualNode Render()
        {
            System.Diagnostics.Debug.WriteLine($"Render(ThreadId={System.Threading.Thread.CurrentThread.ManagedThreadId})");
            return new Button(_counter.ToString()).OnClick(OnStartStop);
        }

        private void OnStartStop()
        {
            _timer.Enabled = !_timer.Enabled;
        }
    }

    //internal class TimerComponent : Component<TimerComponent.State>
    //{
    //    public class State
    //    {
    //        public System.Timers.Timer Timer { get; set; }
    //        public int Counter { get; set; }
    //    }

    //    protected override void OnAttachState()
    //    {
    //        if (CurrentState.Value.Timer == null)
    //            CurrentState.Value.Timer = new System.Timers.Timer(1000);

    //        CurrentState.Value.Timer.Elapsed += Timer_Elapsed;
    //        CurrentState.Value.Timer.Start();

    //        base.OnAttachState();
    //    }

    //    protected override void OnReleaseState()
    //    {
    //        if (CurrentState.Value.Timer != null)
    //            CurrentState.Value.Timer.Elapsed -= Timer_Elapsed;

    //        base.OnReleaseState();
    //    }

    //    private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    //    {
    //        System.Diagnostics.Debug.WriteLine($"Timer_Elapsed(ThreadId={System.Threading.Thread.CurrentThread.ManagedThreadId})");
    //        CurrentState.Set(_ => _.Counter++);
    //    }

    //    protected override VisualNode Render(State state)
    //    {
    //        System.Diagnostics.Debug.WriteLine($"Render(ThreadId={System.Threading.Thread.CurrentThread.ManagedThreadId})");
    //        return new TextBlock(state.Counter.ToString());
    //    }
    //}
}
