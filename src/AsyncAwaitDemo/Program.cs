using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitDemo {
    internal class Program {
        private static void Main(string[] args) {
            Console.WriteLine("*** Welcome to Housework Simulator! ***");
            CleanAllTheThings();
            Log("The housework took {0} hrs {1} mins today. Yay.", Duration.Hours, Duration.Minutes);
            Relax();
        }

        private static void CleanAllTheThings() {
            var dirtyLaundry = new Laundry() { State = LaundryState.Dirty };
            var wetLaundry = RunWashingMachine(dirtyLaundry);
            CleanBathroom();
            var cleanLaundry = RunDryer(wetLaundry);
            CleanLivingRoom();
            CleanKitchen();
            PutAwayDryClothes(cleanLaundry);
        }

        private static void Relax() {
            Log("Commencing relaxation process.");
            Log("(press a key when you feel sufficiently relaxed)");
            Console.ReadKey();
        }

        private static async Task<Laundry> RunWashingMachineAsync(Laundry laundry) {
            return await Task.Run(() => RunWashingMachine(laundry));
        }

        private static Laundry RunWashingMachine(Laundry laundry) {
            Log("Washing machine is running.");
            WashingMachine.Wash(laundry);
            return (laundry);
        }

        private static async Task<Laundry> RunDryerAsync(Laundry laundry) {
            return await Task.Run(() => RunDryer(laundry));
        }

        private static Laundry RunDryer(Laundry laundry) {
            Log("Tumble dryer is running.");
            TumbleDryer.Dry(laundry);
            return (laundry);
        }

        private static void PutAwayDryClothes(Laundry laundry) {
            laundry.State = LaundryState.PutAway;
            Log("Dry clothes have been put away.");
        }

        private static void CleanKitchen() {
            Log("Starting to clean kitchen");
            DoWork(TimeSpan.FromHours(1.5));
            Log("Kitchen is now clean");
        }

        private static void CleanBathroom() {
            Log("Starting to clean bathroom");
            DoWork(TimeSpan.FromHours(1));
            Log("Bathroom is now clean");
        }

        private static void CleanLivingRoom() {
            Log("Starting to clean bedroom");
            DoWork(TimeSpan.FromHours(1));
            Log("Bedroom is now clean");
        }

        public static void Report(string message, params object[] args) {
            var c = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Log(message, args);
            Console.ForegroundColor = c;
        }

        public static readonly int TimeSpeedup = (int)(TimeSpan.FromHours(1).Ticks / TimeSpan.FromSeconds(2.5).Ticks);
        private static readonly DateTime SimRunStartedAt = DateTime.Now;
        private static readonly DateTime Datum = DateTime.Today.Date.AddHours(10);

        private static TimeSpan Duration {
            get { return (SimNow - Datum); }
        }

        private static DateTime SimNow {
            get {
                var elapsed = DateTime.Now - SimRunStartedAt;
                return (Datum.AddSeconds(elapsed.TotalSeconds * TimeSpeedup));
            }
        }

        private static void Log(string message, params object[] args) {
            Console.WriteLine("{0} [Thread #{1}] {2}", SimNow.ToString("hh:mm:tt"), Thread.CurrentThread.ManagedThreadId, String.Format(message, args));
            Thread.Sleep(200);
        }

        public static void DoWork(TimeSpan span) {
            Thread.Sleep((int)(span.TotalMilliseconds / TimeSpeedup));
        }
    }
}