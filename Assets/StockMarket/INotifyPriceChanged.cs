//MVP 패턴을 위한 인터페이스

public interface INotifyPriceChanged
{
    public delegate void PriceChangedEventHandler(float newPrice);

    public event PriceChangedEventHandler OnPriceChanged;
}