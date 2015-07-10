namespace ConsoleSmartHouse.Resources
{
    class Resource :IResource
    {
        protected double value;

        public double Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public Resource(double value)
        {
            this.value = value;
        }
    }
}
