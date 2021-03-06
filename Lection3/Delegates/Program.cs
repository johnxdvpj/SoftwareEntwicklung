

Console.WriteLine("Starting the calculation");
var result = Calculator.SomeLengthyCalculation(ReportProgress);
Console.WriteLine($"The result is: {result}.");

Console.ReadKey();

static void ReportProgress(int percentDone)
{
    Console.WriteLine($"Calculating. {percentDone}% already done.");
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

// delegate
// 
public delegate void ProgressReporter(int percentDone);

public static class Calculator
{
    public static int SomeLengthyCalculation(ProgressReporter pr)
    {
        for (int i = 0; i < 100; i++)
        {
            // Sleep 1/10 second - simulates a step in the calculation
            Thread.Sleep(100);

            pr(i);
        }
        return 42;
    }
}