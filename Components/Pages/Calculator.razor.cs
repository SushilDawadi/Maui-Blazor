// Task 2 
// Note: we have seperate the logic from the UI
//which is possible due to Partial classes in C#

/*
Why namespace is needed here
You have two files:
Calculator.razor
Calculator.razor.cs

Both together form one component using a partial class.
For them to work together:
-> Class name must be same
-> Namespace must be same

 */

using Microsoft.AspNetCore.Components;
namespace MyMauiApp.Pages
{

    public partial class Calculator : ComponentBase
    {
        private double firstNumber = 0;
        private double secondNumber = 0;
        private string result = "0";

        private void Add()
        {
            result = (firstNumber + secondNumber).ToString();
        }

        private void Subtract()
        {
            result = (firstNumber - secondNumber).ToString();
        }

        private void Multiply()
        {
            result = (firstNumber * secondNumber).ToString();
        }

        private void Clear()
        {
            firstNumber = 0;
            secondNumber = 0;
            result = "0";
        }


        private void Divide()
        {
            if (secondNumber != 0)
            {
                result = (firstNumber / secondNumber).ToString("F2");
            }
            else
            {
                result = "Cannot divide by zero!";
            }
        }


    }
}
