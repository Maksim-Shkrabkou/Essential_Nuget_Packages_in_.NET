using System;

namespace xUnitTutorial
{
    public class Calculator
    {
        private CalculatorState _state = CalculatorState.Cleared;
        
        public decimal Value { get; private set; } = 0;

        public string Text => $"The result is {Value}";

        public decimal Add(decimal value)
        {
            _state = CalculatorState.Active;
            
            return Value += value;
        }

        public decimal Subtract(decimal value)
        {
            _state = CalculatorState.Active;
            
            return Value -= value;
        }

        public decimal Multiply(decimal value)
        {
            if (Value == 0 && _state == CalculatorState.Cleared)
            {
                _state = CalculatorState.Active;

                return Value = value;
            }

            return Value *= value;
        }
        
        public decimal Divide(decimal value)
        {
            if (Value == 0 && _state == CalculatorState.Cleared)
            {
                _state = CalculatorState.Active;

                return Value = value;
            }

            if (Value != 0 && value == 0)
            {
                throw new ArgumentException("Can't divide by 0");    
            }

            return Value /= value;
        }
    }

    internal enum CalculatorState
    {
        Cleared,
        Active
    }
}