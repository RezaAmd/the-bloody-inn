using TheBloodyInn.Domain.Enum.Cards;
using TheBloodyInn.Domain.Enum.Guests;

namespace TheBloodyInn.Domain.Entities.Guests;

public static partial class GuestCardDefaults
{
    #region Artisans

    /// <summary>
    /// کشاورز
    /// </summary>
    public static GuestCardEntity Cultivator => new(nameof(Cultivator), GuestCategory.Artisans, RankType.Zero,
        AmountOfMoneyInPocket.Eight, BuildItemType.VegetableGarden);

    /// <summary>
    /// مکانیک
    /// </summary>
    public static GuestCardEntity Mechanic => new(nameof(Mechanic), GuestCategory.Artisans, RankType.One,
        AmountOfMoneyInPocket.Twelve, BuildItemType.Workshop);

    /// <summary>
    /// آشپز
    /// </summary>
    public static GuestCardEntity Distiller => new(nameof(Distiller), GuestCategory.Artisans, RankType.Two,
        AmountOfMoneyInPocket.Eighteen, BuildItemType.Distillery);

    /// <summary>
    /// باغبان
    /// </summary>
    public static GuestCardEntity Gardener => new(nameof(Gardener), GuestCategory.Artisans, RankType.Three,
        AmountOfMoneyInPocket.TwentySix, BuildItemType.Gardens);

    /// <summary>
    /// معمار
    /// </summary>
    public static GuestCardEntity Landscaper => new(nameof(Landscaper), GuestCategory.Artisans, RankType.Three,
        AmountOfMoneyInPocket.TwentySix, BuildItemType.Park);

    /// <summary>
    /// قصاب
    /// </summary>
    public static GuestCardEntity Butcher => new(nameof(Butcher), GuestCategory.Artisans, RankType.Three,
        AmountOfMoneyInPocket.TwentySix, BuildItemType.ButcherShop);

    #endregion

    #region Merchants

    /// <summary>
    /// روزنامه فروش
    /// </summary>
    public static GuestCardEntity NewsBoy => new(nameof(NewsBoy), GuestCategory.Merchants, RankType.Zero,
        AmountOfMoneyInPocket.Eight, BuildItemType.Kiosk);

    /// <summary>
    /// نماینده
    /// </summary>
    public static GuestCardEntity Representative => new(nameof(Representative), GuestCategory.Merchants, RankType.One,
        AmountOfMoneyInPocket.Twelve, BuildItemType.Parlor);

    /// <summary>
    /// سرایدار
    /// </summary>
    public static GuestCardEntity Concierge => new(nameof(Concierge), GuestCategory.Merchants, RankType.Two,
        AmountOfMoneyInPocket.Eighteen, BuildItemType.RoomService);

    /// <summary>
    /// بقال
    /// </summary>
    public static GuestCardEntity Grocer => new(nameof(Grocer), GuestCategory.Merchants, RankType.Three,
        AmountOfMoneyInPocket.TwentySix, BuildItemType.Grocery);

    /// <summary>
    /// فروشنده
    /// </summary>
    public static GuestCardEntity Shopkeeper => new(nameof(Shopkeeper), GuestCategory.Merchants, RankType.Three,
        AmountOfMoneyInPocket.TwentySix, BuildItemType.Shop);

    /// <summary>
    /// قهوه چی
    /// </summary>
    public static GuestCardEntity Brewer => new(nameof(Brewer), GuestCategory.Merchants, RankType.Three,
        AmountOfMoneyInPocket.TwentySix, BuildItemType.Brewery);

    #endregion

    #region Religious

    /// <summary>
    /// محصل
    /// </summary>
    public static GuestCardEntity Novice => new(nameof(Novice), GuestCategory.Religious, RankType.Zero,
        AmountOfMoneyInPocket.Eight, BuildItemType.Alter);

    /// <summary>
    /// راهب
    /// </summary>
    public static GuestCardEntity Monk => new(nameof(Monk), GuestCategory.Religious, RankType.One,
        AmountOfMoneyInPocket.Twelve, BuildItemType.Bedroom);

    /// <summary>
    /// راهب بزرگ
    /// </summary>
    public static GuestCardEntity Abbot => new(nameof(Abbot), GuestCategory.Religious, RankType.Two,
        AmountOfMoneyInPocket.Eighteen, BuildItemType.Cellar);

    /// <summary>
    /// کشیش
    /// </summary>
    public static GuestCardEntity Priest => new(nameof(Priest), GuestCategory.Religious, RankType.Three,
        AmountOfMoneyInPocket.TwentySix, BuildItemType.Cellar);

    /// <summary>
    /// اسقف اعظم
    /// </summary>
    public static GuestCardEntity Archbishop => new(nameof(Archbishop), GuestCategory.Religious, RankType.Three,
        AmountOfMoneyInPocket.TwentySix, BuildItemType.Crypt);

    /// <summary>
    /// اسقف
    /// </summary>
    public static GuestCardEntity Bishop => new(nameof(Bishop), GuestCategory.Religious, RankType.Three,
        AmountOfMoneyInPocket.TwentySix, BuildItemType.Bishopric);

    #endregion

    #region Nobles

    /// <summary>
    /// نجیب زاده
    /// </summary>
    public static GuestCardEntity Baron => new(nameof(Baron), GuestCategory.Nobles, RankType.Zero,
        AmountOfMoneyInPocket.Eight, BuildItemType.GrandChandelier);

    /// <summary>
    /// تاجر
    /// </summary>
    public static GuestCardEntity Viscount => new(nameof(Viscount), GuestCategory.Nobles, RankType.One,
        AmountOfMoneyInPocket.Twelve, BuildItemType.KingSizeBed);

    /// <summary>
    /// کنت
    /// </summary>
    public static GuestCardEntity Count => new(nameof(Count), GuestCategory.Nobles, RankType.Two,
        AmountOfMoneyInPocket.Eighteen, BuildItemType.DiningRoom);

    /// <summary>
    /// دوک
    /// </summary>
    public static GuestCardEntity Duke => new(nameof(Duke), GuestCategory.Nobles, RankType.Three,
        AmountOfMoneyInPocket.TwentySix, BuildItemType.Stables);

    /// <summary>
    /// شاهزاده
    /// </summary>
    public static GuestCardEntity Prince => new(nameof(Prince), GuestCategory.Nobles, RankType.Three,
        AmountOfMoneyInPocket.TwentySix, BuildItemType.GreenHouse);

    /// <summary>
    /// اشراف زاده
    /// </summary>
    public static GuestCardEntity Marquis => new(nameof(Marquis), GuestCategory.Nobles, RankType.Three,
        AmountOfMoneyInPocket.TwentySix, BuildItemType.Pavilion);

    #endregion

    #region Polices

    /// <summary>
    /// کلانتر
    /// </summary>
    public static GuestCardEntity Sheriff => new(nameof(Sheriff), GuestCategory.Polices, RankType.Zero,
        AmountOfMoneyInPocket.Eight, BuildItemType.None);

    /// <summary>
    /// سروان
    /// </summary>
    public static GuestCardEntity Brigadier => new(nameof(Brigadier), GuestCategory.Polices, RankType.One,
        AmountOfMoneyInPocket.Twelve, BuildItemType.None);

    /// <summary>
    /// سرگرد
    /// </summary>
    public static GuestCardEntity BrigadierChief => new(nameof(BrigadierChief), GuestCategory.Polices, RankType.Two,
        AmountOfMoneyInPocket.Eighteen, BuildItemType.None);

    /// <summary>
    /// سرهنگ
    /// </summary>
    public static GuestCardEntity Major => new(nameof(Major), GuestCategory.Polices, RankType.Three,
        AmountOfMoneyInPocket.TwentySix, BuildItemType.None);

    #endregion
}