
var calc = new Calculator();
// events ermöglichen mehr Instanzen hinzuzufügen
calc.PR += ReportProgress;
calc.PR += OtherReportProgress;
calc.RR += ReceiveResult;

Console.WriteLine("Starting the calculation");
calc.StartSomeLengthyCalculation();
Console.WriteLine("We are here but the calculation is not done yet!!");
Thread.Sleep(1000);
Console.WriteLine("How long might the calculation take??");
Thread.Sleep(2000);
Console.WriteLine("Still not done?");
Thread.Sleep(4000);
Console.WriteLine("Seems to take hours!!!");


Console.ReadKey();

static void ReportProgress(int percentDone)
{
    Console.WriteLine($"Calculating. {percentDone}% already done.");
}


static void OtherReportProgress(int percentDone)
{
    if (percentDone % 10 == 0)
        Console.WriteLine($"Another tenth is done.");
}

static void ReceiveResult(int result)
{
    Console.WriteLine($"The result is {result}.");
}


//  ^
//  |    User Code using the Calculation. User code cannot change the calculation's 
//  |    implementation but needs to report the progress to the user.
///////////////////////////////////////////////////////////////////////////////////////////
//  |    Implementation of Calculation. Implementors don't know anything about
//  |    the context their code is called in (language, UI-System, etc.).
//  V

// Declares the _DATA TYPE_ ProgressReporter. Variables of that type can
// hold a method 
public delegate void ProgressReporter(int percentDone);
public delegate void ResultReceiver(int result);

public class Calculator
{
    // events
    public event ProgressReporter PR;
    public event ResultReceiver RR;

    public void StartSomeLengthyCalculation()
    {
        // Start the calculation in a different thread and immediately return to caller.
        new Task(DoCalculate).Start();
    }

    private void DoCalculate()
    {
        for (int i = 0; i < 100; i++)
        {
            // Sleep 1/10 second - simulates a step in the calculation
            Thread.Sleep(100);

            PR(i);
        }
        RR(42);
    }
}