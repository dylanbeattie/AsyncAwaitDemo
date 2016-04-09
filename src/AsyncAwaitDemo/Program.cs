using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitDemo {
    class Program {
        static void Main(string[] args) {
            var sw = new Stopwatch();
            sw.Start();
            DoHousework();
            sw.Stop();
            Log("Housework took {0} hours today!", sw.Elapsed.TotalSeconds.ToString("0.00"));
            Relax();
        }

        static void DoHousework() {
            
            var laundry = new Laundry() {
                State = LaundryState.Dirty, 
                Location = LaundryLocation.LaundryBasket
            };

            LoadWashingMachine(laundry);
            RunWashingMachine(laundry);
            PutWetClothesInDryer(laundry);
            RunDryer(laundry);
            PutAwayDryClothes(laundry);
            CleanKitchen();
            CleanBathroom();
        }

        static void Relax() {
            Log("Relaxing...");
            Log("(press a key when you're sufficiently relaxed");
            Console.ReadKey();
        }

        static void LoadWashingMachine(Laundry laundry) {
            laundry.Location = LaundryLocation.WashingMachine;
            Log("Washing machine is ready to go!");
        }

        static void RunWashingMachine(Laundry laundry) {
            Log("Washing machine is running.");
            Thread.Sleep(5000);
            laundry.State = LaundryState.Wet;
            Log("Washing machine is finished.");
        }

        static void PutWetClothesInDryer(Laundry laundry) {
            laundry.Location = LaundryLocation.TumbleDryer;
            Log("Tumble dryer is ready to go!");
        }

        static void RunDryer(Laundry laundry) {
            Log("Tumble dryer is running.");
            Thread.Sleep(3000);
            laundry.State = LaundryState.Dry;
            Log("Tumble dryer is finished");
        }

        static void PutAwayDryClothes(Laundry laundry) {
            laundry.Location = LaundryLocation.Wardrobe;
            Log("Dry clothes have been put away.");
        }

        static void CleanKitchen() {
            Log("Starting to clean kitchen");
            Thread.Sleep(1000);
            Log("Kitchen is now clean");
        }

        static void CleanBathroom() {
            Log("Starting to clean bathroom");
            Thread.Sleep(1000);
            Log("Bathroom is now clean");
        }

        static void Log(string message, params object[] args) {
            Console.WriteLine("{0} : {1}", Thread.CurrentThread.ManagedThreadId, String.Format(message, args));
        }
    }

    public enum LaundryLocation {
        LaundryBasket,
        WashingMachine,
        TumbleDryer,
        Wardrobe
    }

    public enum LaundryState {
        Dirty,
        Wet,
        Dry
    }

    public class Laundry {
        public LaundryState State { get; set; }
        public LaundryLocation Location { get; set; }
    }
}
