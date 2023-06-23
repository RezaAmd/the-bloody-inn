namespace TheBloodyInn.Domain.Enum.Cards;

public enum BuildItemType
{
    None,

    #region Artisans

    /// <summary>
    /// مزرعه
    /// </summary>
    VegetableGarden,

    /// <summary>
    /// کارگاه
    /// </summary>
    Workshop,

    /// <summary>
    /// آشپزخانه
    /// </summary>
    Distillery,

    /// <summary>
    /// باغ
    /// </summary>
    Gardens,

    /// <summary>
    /// قصابی
    /// </summary>
    ButcherShop,

    /// <summary>
    /// پارک
    /// </summary>
    Park,

    #endregion

    #region Merchants

    /// <summary>
    /// کیوسک
    /// </summary>
    Kiosk,

    /// <summary>
    /// تالار
    /// </summary>
    Parlor,

    /// <summary>
    /// آبدارخانه
    /// </summary>
    RoomService,

    /// <summary>
    /// بقالی
    /// </summary>
    Grocery,

    /// <summary>
    /// فروشگاه
    /// </summary>
    Shop,

    /// <summary>
    /// آبجو سازی / قهوه خانه
    /// </summary>
    Brewery,

    #endregion

    #region Religious

    /// <summary>
    /// مکتب خانه
    /// </summary>
    Alter,

    /// <summary>
    /// اتاق خواب
    /// </summary>
    Bedroom,

    /// <summary>
    /// سرداب
    /// </summary>
    Cellar,

    /// <summary>
    /// عبادتگاه
    /// </summary>
    Chapel,

    /// <summary>
    /// دخمه
    /// </summary>
    Crypt,

    /// <summary>
    /// کلیسا
    /// </summary>
    Bishopric,
    #endregion

    #region Nobles

    /// <summary>
    /// لوستر بزرگ
    /// </summary>
    GrandChandelier,

    /// <summary>
    /// تخت مجلل
    /// </summary>
    KingSizeBed,

    /// <summary>
    /// اتاق نشیمن
    /// </summary>
    DiningRoom,

    /// <summary>
    /// اسطبل
    /// </summary>
    Stables,
    
    /// <summary>
    /// گلخانه
    /// </summary>
    GreenHouse,

    /// <summary>
    /// غرفه / خیمه
    /// </summary>
    Pavilion,

    #endregion
}