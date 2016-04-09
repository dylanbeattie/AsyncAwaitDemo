using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitDemo {
    internal class Program {
        private static void Main(string[] args) {
            Console.WriteLine("*** WELCOME TO HOUSEWORK SIMULATOR 1.0! ***");
            var sw = new Stopwatch();
            sw.Start();
            DoTheChores();
            sw.Stop();
            Log("Housework took {0} hours today!", (sw.Elapsed.TotalSeconds / 2.0).ToString("0.0"));
            Relax();
        }

        private static void DoTheChores() {
            var dirtyLaundry = new Laundry() { State = LaundryState.Dirty };
            var cleanLaundry = DoTheLaundry(dirtyLaundry);
            CleanAllTheThings();
            PutAwayDryClothes(cleanLaundry);
        }

        private static Laundry DoTheLaundry(Laundry dirtyLaundry) {
            var wetLaundry = RunWashingMachine(dirtyLaundry);
            var dryLaundry = RunDryer(wetLaundry);
            return (dryLaundry);
        }

        static void CleanAllTheThings() {
            CleanKitchen();
            CleanBathroom();
            Log("CLEANED ALL THE THINGS!");
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
            Report("(washing machine has finished)");
            return (laundry);
        }

        static Laundry RunDryer(Laundry laundry) {
            Log("Tumble dryer is running.");
            Thread.Sleep(6000);
            laundry.State = LaundryState.Dry;
            Report("(tumble dryer has finished)");
            return (laundry);
        }

        static void PutAwayDryClothes(Laundry laundry) {
            laundry.State = LaundryState.PutAway;
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

        static void Report(string message, params object[] args) {
            var c = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Log(message, args);
            Console.ForegroundColor = c;
        }

        private static readonly DateTime StartedAt = DateTime.Now;
        static void Log(string message, params object[] args) {
            var now = DateTime.Today.Date.AddHours(10).AddHours((DateTime.Now - StartedAt).TotalSeconds / 2);
            Console.WriteLine("{0} [Thread #{1}] {2}", now.ToString("HH:mm"), Thread.CurrentThread.ManagedThreadId, String.Format(message, args));
            Thread.Sleep(200);
        }
    }
}
