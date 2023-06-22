namespace TheBloodyInn.Domain.ValueObjects;

public class Franc10CheckMoney
{
    public byte Count { get; private set; }

    #region Methods
    /// <summary>
    /// Create new instance of "10 Franc check money."
    /// </summary>
    /// <param name="initChekMoney"></param>
    /// <returns></returns>
    public static Franc10CheckMoney CreateNewInstance(byte initChekMoney = 0)
    {
        var checkMoney = new Franc10CheckMoney();
        checkMoney.Increase(initChekMoney);
        return checkMoney;
    }

    public void Increase(byte checkMoneyCount)
    {
        Count = checkMoneyCount;
    }

    public void Decrease(byte checkMoneyCount)
    {
        if (checkMoneyCount > Count)
            Count = 0;
        else
            Count -= checkMoneyCount;
    }

    public int GetCashBalance()
    {
        return Count * 10;
    }

    public FrancCash ConvertToCash(byte checkMoneyCount)
    {
        if (checkMoneyCount > 25)
            throw new ArgumentOutOfRangeException("Check money cash count must less than 25.");
        var cash = FrancCash.CreateNew();
        cash.Increase(Convert.ToByte(checkMoneyCount * 10));
        return cash;
    }
    #endregion
}