using CalculatorLibrary.Data;

namespace CalculatorLibrary.Logic
{
    public class Calculator
    {
        DataLayerAbstract c = DataLayerAbstract.CreateLinq2SQL();

        public int Add(int x, int y)
        {
            return x + y;
        }

        public int Sub(int x, int y)
        {
            return x - y;
        }

        public int Mul(int x, int y)
        {
            return x * y;
        }

        public double Div(int x, int y)
        {
            if (y == 0)
                return x < 0 ? double.NegativeInfinity : double.PositiveInfinity;

            return (double)x / y;
        }
    }
}
