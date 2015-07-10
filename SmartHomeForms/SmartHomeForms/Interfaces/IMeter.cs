namespace SmartHomeForms
{
    public interface IMeter : IConnector
    {
        void Metering(object sender, ResourceConsumedEventArgs e);
    }
}
