using System.Collections;
using System.Collections.Generic;

namespace xUnitTutorial
{
    public class CalculatorDivisionTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {30, new decimal[] {60, 2}};
            yield return new object[] {0, new decimal[] {0, 1}};
            yield return new object[] {1, new decimal[] {60, 60}};
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}