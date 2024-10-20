using TheBloodyInn.Domain.Entities.Guests;
using TheBloodyInn.Domain.Enum.Cards;
using TheBloodyInn.Domain.Enum.Guests;

namespace TheBloodyInn.Domain.Common.Defaults.Guests;

public static partial class GuestCardDefaults
{
    #region Artisans

    /// <summary>
    /// کشاورز
    /// </summary>
    public static GuestEntity Cultivator => new(nameof(Cultivator), GuestCategory.Artisans, RankType.Zero,
        AmountOfMoneyInPocket.Eight, BuildItemType.VegetableGarden);

    /// <summary>
    /// مکانیک
    /// </summary>
    public static GuestEntity Mechanic => new(nameof(Mechanic), GuestCategory.Artisans, RankType.One,
        AmountOfMoneyInPocket.Twelve, BuildItemType.Workshop);

    /// <summary>
    /// آشپز
    /// </summary>
    public static GuestEntity Distiller => new(nameof(Distiller), GuestCategory.Artisans, RankType.Two,
        AmountOfMoneyInPocket.Eighteen, BuildItemType.Distillery);

    /// <summary>
    /// باغبان
    /// </summary>
    public static GuestEntity Gardener => new(nameof(Gardener), GuestCategory.Artisans, RankType.Three,
        AmountOfMoneyInPocket.TwentySix, BuildItemType.Gardens);

    /// <summary>
    /// معمار
    /// </summary>
    public static GuestEntity Landscaper => new(nameof(Landscaper), GuestCategory.Artisans, RankType.Three,
        AmountOfMoneyInPocket.TwentySix, BuildItemType.Park);

    /// <summary>
    /// قصاب
    /// </summary>
    public static GuestEntity Butcher => new(nameof(Butcher), GuestCategory.Artisans, RankType.Three,
        AmountOfMoneyInPocket.TwentySix, BuildItemType.ButcherShop);

    #endregion

    #region Merchants

    /// <summary>
    /// روزنامه فروش
    /// </summary>
    public static GuestEntity NewsBoy => new(nameof(NewsBoy), GuestCategory.Merchants, RankType.Zero,
        AmountOfMoneyInPocket.Eight, BuildItemType.Kiosk);

    /// <summary>
    /// نماینده
    /// </summary>
    public static GuestEntity Representative => new(nameof(Representative), GuestCategory.Merchants, RankType.One,
        AmountOfMoneyInPocket.Twelve, BuildItemType.Parlor);

    /// <summary>
    /// سرایدار
    /// </summary>
    public static GuestEntity Concierge => new(nameof(Concierge), GuestCategory.Merchants, RankType.Two,
        AmountOfMoneyInPocket.Eighteen, BuildItemType.RoomService);

    /// <summary>
    /// بقال
    /// </summary>
    public static GuestEntity Grocer => new(nameof(Grocer), GuestCategory.Merchants, RankType.Three,
        AmountOfMoneyInPocket.TwentySix, BuildItemType.Grocery);

    /// <summary>
    /// فروشنده
    /// </summary>
    public static GuestEntity Shopkeeper => new(nameof(Shopkeeper), GuestCategory.Merchants, RankType.Three,
        AmountOfMoneyInPocket.TwentySix, BuildItemType.Shop);

    /// <summary>
    /// قهوه چی
    /// </summary>
    public static GuestEntity Brewer => new(nameof(Brewer), GuestCategory.Merchants, RankType.Three,
        AmountOfMoneyInPocket.TwentySix, BuildItemType.Brewery);

    #endregion

    #region Religious

    /// <summary>
    /// محصل
    /// </summary>
    public static GuestEntity Novice => new(nameof(Novice), GuestCategory.Religious, RankType.Zero,
        AmountOfMoneyInPocket.Eight, BuildItemType.Alter);

    /// <summary>
    /// راهب
    /// </summary>
    public static GuestEntity Monk => new(nameof(Monk), GuestCategory.Religious, RankType.One,
        AmountOfMoneyInPocket.Twelve, BuildItemType.Bedroom);

    /// <summary>
    /// راهب بزرگ
    /// </summary>
    public static GuestEntity Abbot => new(nameof(Abbot), GuestCategory.Religious, RankType.Two,
        AmountOfMoneyInPocket.Eighteen, BuildItemType.Cellar);

    /// <summary>
    /// کشیش
    /// </summary>
    public static GuestEntity Priest => new(nameof(Priest), GuestCategory.Religious, RankType.Three,
        AmountOfMoneyInPocket.TwentySix, BuildItemType.Cellar);

    /// <summary>
    /// اسقف اعظم
    /// </summary>
    public static GuestEntity Archbishop => new(nameof(Archbishop), GuestCategory.Religious, RankType.Three,
        AmountOfMoneyInPocket.TwentySix, BuildItemType.Crypt);

    /// <summary>
    /// اسقف
    /// </summary>
    public static GuestEntity Bishop => new(nameof(Bishop), GuestCategory.Religious, RankType.Three,
        AmountOfMoneyInPocket.TwentySix, BuildItemType.Bishopric);

    #endregion

    #region Nobles

    /// <summary>
    /// نجیب زاده
    /// </summary>
    public static GuestEntity Baron => new(nameof(Baron), GuestCategory.Nobles, RankType.Zero,
        AmountOfMoneyInPocket.Eight, BuildItemType.GrandChandelier);

    /// <summary>
    /// تاجر
    /// </summary>
    public static GuestEntity Viscount => new(nameof(Viscount), GuestCategory.Nobles, RankType.One,
        AmountOfMoneyInPocket.Twelve, BuildItemType.KingSizeBed);

    /// <summary>
    /// کنت
    /// </summary>
    public static GuestEntity Count => new(nameof(Count), GuestCategory.Nobles, RankType.Two,
        AmountOfMoneyInPocket.Eighteen, BuildItemType.DiningRoom);

    /// <summary>
    /// دوک
    /// </summary>
    public static GuestEntity Duke => new(nameof(Duke), GuestCategory.Nobles, RankType.Three,
        AmountOfMoneyInPocket.TwentySix, BuildItemType.Stables);

    /// <summary>
    /// شاهزاده
    /// </summary>
    public static GuestEntity Prince => new(nameof(Prince), GuestCategory.Nobles, RankType.Three,
        AmountOfMoneyInPocket.TwentySix, BuildItemType.GreenHouse);

    /// <summary>
    /// اشراف زاده
    /// </summary>
    public static GuestEntity Marquis => new(nameof(Marquis), GuestCategory.Nobles, RankType.Three,
        AmountOfMoneyInPocket.TwentySix, BuildItemType.Pavilion);

    #endregion

    #region Polices

    /// <summary>
    /// کلانتر
    /// </summary>
    public static GuestEntity Sheriff => new(nameof(Sheriff), GuestCategory.Polices, RankType.Zero,
        AmountOfMoneyInPocket.Eight, BuildItemType.None);

    /// <summary>
    /// سروان
    /// </summary>
    public static GuestEntity Brigadier => new(nameof(Brigadier), GuestCategory.Polices, RankType.One,
        AmountOfMoneyInPocket.Twelve, BuildItemType.None);

    /// <summary>
    /// سرگرد
    /// </summary>
    public static GuestEntity BrigadierChief => new(nameof(BrigadierChief), GuestCategory.Polices, RankType.Two,
        AmountOfMoneyInPocket.Eighteen, BuildItemType.None);

    /// <summary>
    /// سرهنگ
    /// </summary>
    public static GuestEntity Major => new(nameof(Major), GuestCategory.Polices, RankType.Three,
        AmountOfMoneyInPocket.TwentySix, BuildItemType.None);

    #endregion
}