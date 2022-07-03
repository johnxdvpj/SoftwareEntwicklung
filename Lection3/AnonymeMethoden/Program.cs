
int theResult = 0;
var calc = new Calculator();
// anonyme Methode
// delegate ersetzt den Namen der Methode und ist somit ein anonym
calc.PR += delegate (int percentDone)
{
    Console.WriteLine($"Calculating. {percentDone}% already done.");
};
// lambda
// mit => bilden wir percentDone auf die Funktionalität ab
calc.PR += percentDone =>
{
    if (percentDone % 10 == 0)
        Console.WriteLine($"Another tenth is done.");
};
calc.RR += delegate (int result)
{
    Console.WriteLine($"The result is {result}.");
    theResult = result;
};

Console.WriteLine("Starting the calculation");
calc.StartSomeLengthyCalculation();
Console.WriteLine("The result at the beginning is: " + theResult);

Thread.Sleep(11000);

Console.WriteLine("The result at the end is:" + theResult);


Console.ReadKey();








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