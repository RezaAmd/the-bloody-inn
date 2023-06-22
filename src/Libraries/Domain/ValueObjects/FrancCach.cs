namespace TheBloodyInn.Domain.ValueObjects;

public class FrancCash
{
    #region Constructors
    FrancCash() { }
    #endregion

    public byte Value { get; private set; }

    #region Methods
    /// <summary>
    /// Create a new franc cash.
    /// </summary>
    /// <param name="initCach">initialize cash value.</param>
    /// <returns>instance of franc cash object.</returns>
    public static FrancCash CreateNew(byte initCach = 0)
    {
        if (initCach > 40)
            throw new ArgumentException("Cash must be less than 40.");
        var francCash = new FrancCash();
        francCash.Increase(initCach);
        return francCash;
    }

    /// <summary>
    /// Increase to franc cash value.
    /// </summary>
    /// <param name="cash">Cash must between 0 - 40</param>
    public void Increase(byte cash)
    {
        Value += cash;
        if (Value > 40)
            Value = 40;
    }

    /// <summary>
    /// Decrease from cash value.
    /// </summary>
    /// <param name="cash">Cash must between 0 - 40</param>
    public void Decrease(byte cash)
    {
        if (cash > Value)
            Value = 0;
        else
            Value -= cash;
    }
    #endregion
}