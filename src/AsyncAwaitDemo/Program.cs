using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitDemo {
    internal class Program {
        private static void Main(string[] args) {
            var sw = new Stopwatch();
            sw.Start();
            DoTheLaundry();
            CleanAllTheThings();
            sw.Stop();
            Log("Housework took {0} hours today!", (sw.Elapsed.TotalSeconds / 2.0).ToString("0.0"));
            Relax();
        }

        private static void DoTheLaundry() {
            var dirtyLaundry = new Laundry() { State = LaundryState.Dirty };
            var wetLaundry = RunWashingMachine(dirtyLaundry);
            var dryLaundry = RunDryer(wetLaundry);
            PutAwayDryClothes(dryLaundry);
        }

        static void CleanAllTheThings() {
            CleanKitchen();
            CleanBathroom();
        }

        static void Relax() {
            Log("Commencing relaxation process.");
            Log("(press a key when you feel sufficiently relaxed)");
            Console.ReadKey();
        }

        static Laundry RunWashingMachine(Laundry laundry) {
            Log("Washing machine is running.");
            Thread.Sleep(6000);
            laundry.State = LaundryState.Wet;
            Log("Washing machine is finished.");
            return (laundry);
        }

        static Laundry RunDryer(Laundry laundry) {
            Log("Tumble dryer is running.");
            Thread.Sleep(6000);
            laundry.State = LaundryState.Dry;
            Log("Tumble dryer is finished");
            return (laundry);
        }

        static void PutAwayDryClothes(Laundry laundry) {
            Log("Dry clothes have been put away.");
        }

        static void CleanKitchen() {
            Log("Starting to clean kitchen");
            Thread.Sleep(2000);
            Log("Kitchen is now clean");
        }

        static void CleanBathroom() {
            Log("Starting to clean bathroom");
            Thread.Sleep(2000);
            Log("Bathroom is now clean");
        }

        static void Log(string message, params object[] args) {
            Console.WriteLine("{0} : {1}", Thread.CurrentThread.ManagedThreadId, String.Format(message, args));
            Thread.Sleep(500);
        }
    }
}
