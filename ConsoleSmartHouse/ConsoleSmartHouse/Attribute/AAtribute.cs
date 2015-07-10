namespace ConsoleSmartHouse.Attribute
{
    class AAtribute
    {
        protected double value;
        protected double delta;

        public double Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public double Delta
        {
            get { return delta; }
            set { delta = value; }
        }
    }
}
