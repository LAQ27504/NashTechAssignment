namespace CarAPI
{
    public interface IChargable
    {
        void Charge(DateTime timeOfCharge);
        DateTime ShowLastChargeTime();
    }
}