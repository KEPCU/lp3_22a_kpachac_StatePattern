using System.Text;
public class Program {  

    public static BaseOperation GetOperation(string option) {
        switch (option) {
            case "S": return new SumOperation();
            case "R": return new SubtractionOperation();
            case "M": return new MultiplicationOperation();
            case "D": return new DivisionOperation();
            default: return null;
        }
    }

    public static void Main (string[] args) {
        Console.WriteLine("-----------Calculator-----------");
        Console.Write("number 1: ");
        double number1 = double.Parse(Console.ReadLine() ?? "1");
        Console.Write("number 2: ");
        double number2 = double.Parse(Console.ReadLine() ?? "1");

        Console.Write("Operation (S/R/M/D): ");
        var option = Console.ReadLine() ?? "S";

        var calculator = new Calculator(0,number1,number2, GetOperation(option));
        calculator.Calculate();
        while(calculator.Cache > -1000 || calculator.Cache < 1000) {
            Console.Write("number: ");
            number1 = double.Parse(Console.ReadLine() ?? "1");
            calculator = new Calculator(calculator.Operations, calculator.Cache,number1, calculator.Operation);
            calculator.Calculate();
        }
    }
}
