using System;
using System.Threading;

namespace AsyncAwaitDemo {
    public static class TumbleDryer {
        public static void Dry(Laundry laundry) {
            if (laundry.State != LaundryState.Wet) {
                throw (new Exception("FOR BEST RESULTS ENSURE LAUNDRY IS WET BEFORE ATTEMPTING TO DRY IT."));
            }
            Program.DoWork(TimeSpan.FromHours(3));
            laundry.State = LaundryState.Dry;
            Program.Report("(tumble dryer has finished)");
        }
    }
}