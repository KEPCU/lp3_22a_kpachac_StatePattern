public abstract class BaseOperation {
    public abstract double Operation(double number1, double number2);
}

public class SumOperation : BaseOperation {
    public override double Operation(double number1, double number2) { return number1 + number2; }
}


public class SubtractionOperation : BaseOperation {
    public override double Operation(double number1, double number2) { return number1 - number2; }
}

public class MultiplicationOperation : BaseOperation {
    public override double Operation(double number1, double number2) { return number1 * number2; }
}

public class DivisionOperation : BaseOperation {
    public override double Operation(double number1, double number2) { return number1 / number2; }
}

public class Calculator {
    public double Number1 {get; set;} = 0f;
    public double Number2 {get; set;} = 0f;
    public double Cache {get; set;} = 0f;
    const int MaxOperations = 3;
    public int Operations = 0;
    public BaseOperation Operation { get; set; }
    
    public Calculator(int operations,double number1, double number2, BaseOperation operation) {
        Operations = operations;
        Operation = operation;
        Number1 = number1;
        Number2 = number2;
    }

    public void ChangeState(BaseOperation operation) {
        Console.WriteLine($"changing... {Operation.GetType()} >>>>>>> {operation.GetType()}");
        Operation = operation;
        Operations = 0;
    }

    public void Calculate() {
        if(Operations > MaxOperations) {
            if(Operation is SumOperation) ChangeState(new SubtractionOperation());
            else if(Operation is MultiplicationOperation) ChangeState(new DivisionOperation());
            else if(Operation is SubtractionOperation) ChangeState(new MultiplicationOperation()); 
            else ChangeState(new SumOperation());
        }
        Operations++;
        Cache = Operation.Operation(Number1,Number2);
        Console.WriteLine("Result: " + Cache);
    }

}