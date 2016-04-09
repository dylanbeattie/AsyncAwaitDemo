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
            LoadWashingMachine();
            RunWashingMachine();
            PutWetClothesInDryer();
            RunDryer();
            PutAwayDryClothes();
            CleanKitchen();
            CleanBathroom();
        }

        static void Relax() {
            Log("Relaxing...");
            Log("(press a key when you're sufficiently relaxed");
            Console.ReadKey();
        }

        static void LoadWashingMachine() {
            Log("Washing machine is ready to go!");
        }

        static void RunWashingMachine() {
            Log("Washing machine is running.");
            Thread.Sleep(3000);
            Log("Washing machine is finished.");
        }

        static void PutWetClothesInDryer() {
            Log("Tumble dryer is ready to go!");
        }

        static void RunDryer() {
            Log("Tumble dryer is running.");
            Thread.Sleep(3000);
            Log("Tumble dryer is finished");
        }

        static void PutAwayDryClothes() {
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
}
