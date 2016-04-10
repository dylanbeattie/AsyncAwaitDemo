using System;
using System.Threading;

namespace AsyncAwaitDemo {
    public static class WashingMachine {
        public static void Wash(Laundry laundry) {
            Program.DoWork(TimeSpan.FromHours(2.5));
            laundry.State = LaundryState.Wet;
            Program.Report("(washing machine has finished)");
        }
    }
}