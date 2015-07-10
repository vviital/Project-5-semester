using System;

namespace SmartHomeForms
{
    public class CountElement
    {
        public double Value { private set; get; }

        public DateTime DateTime { private set; get; }

        //
        // impr 
        public void AddValue(double value)
        {
            Value += value;
        }

        public CountElement(DateTime dateTime)
        {
            Value = 0;
            DateTime = dateTime;
        }

        public override bool Equals(object obj)
        {
            if (obj is CountElement)
                return DateTime == (obj as CountElement).DateTime;
            return false;
        }

        public override int GetHashCode()
        {
            return DateTime.GetHashCode();
        }
    }
    
}
