Console.WriteLine("Starting the calculation");
var result = Calculator.SomeLengthyCalculation(new UserProgressReporter());
Console.WriteLine($"The result is: {result}.");

Console.ReadKey();
public class UserProgressReporter : ProgressReporter
{
    public override void ReportProgress(int percentDone)
    {
        Console.WriteLine($"Calculating. {percentDone}% already done.");
    }
}


//  ^
//  |    User Code using the Calculation. User code cannot change the calculation's 
//  |    .implementation but needs to report the progress to the user.
///////////////////////////////////////////////////////////////////////////////////////////
//  |    Implementation of Calculation. Implementors don't know anything about
//  |    the context their code is called in (language, UI-System, etc.)
//  V

public class ProgressReporter
{
    public virtual void ReportProgress(int percentDone)
    {
        // No implementation here 
    }
}

public static class Calculator
{
    public static int SomeLengthyCalculation(ProgressReporter pr)
    {
        for (int i = 0; i < 100; i++)
        {
            // Sleep 1/10 second - simulates a step in the calculation
            Thread.Sleep(100);

            pr.ReportProgress(i);
        }
        return 42;
    }
}