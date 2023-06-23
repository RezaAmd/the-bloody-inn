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
    public static GuestCard Cultivator => new(nameof(Cultivator), GuestCategory.Artisans, RankType.Zero,
        AmountOfMoneyInPocket.Eight, BuildItemType.VegetableGarden);

    /// <summary>
    /// مکانیک
    /// </summary>
    public static GuestCard Mechanic => new(nameof(Mechanic), GuestCategory.Artisans, RankType.One,
        AmountOfMoneyInPocket.Twelve, BuildItemType.Workshop);

    /// <summary>
    /// آشپز
    /// </summary>
    public static GuestCard Distiller => new(nameof(Distiller), GuestCategory.Artisans, RankType.Two,
        AmountOfMoneyInPocket.Eighteen, BuildItemType.Distillery);

    /// <summary>
    /// باغبان
    /// </summary>
    public static GuestCard Gardener => new(nameof(Gardener), GuestCategory.Artisans, RankType.Three,
        AmountOfMoneyInPocket.TwentySix, BuildItemType.Gardens);

    /// <summary>
    /// معمار
    /// </summary>
    public static GuestCard Landscaper => new(nameof(Landscaper), GuestCategory.Artisans, RankType.Three,
        AmountOfMoneyInPocket.TwentySix, BuildItemType.Park);

    /// <summary>
    /// قصاب
    /// </summary>
    public static GuestCard Butcher => new(nameof(Butcher), GuestCategory.Artisans, RankType.Three,
        AmountOfMoneyInPocket.TwentySix, BuildItemType.ButcherShop);

    #endregion

    #region Merchants

    /// <summary>
    /// روزنامه فروش
    /// </summary>
    public static GuestCard NewsBoy => new(nameof(NewsBoy), GuestCategory.Merchants, RankType.Zero,
        AmountOfMoneyInPocket.Eight, BuildItemType.Kiosk);

    /// <summary>
    /// نماینده
    /// </summary>
    public static GuestCard Representative => new(nameof(Representative), GuestCategory.Merchants, RankType.One,
        AmountOfMoneyInPocket.Twelve, BuildItemType.Parlor);

    /// <summary>
    /// سرایدار
    /// </summary>
    public static GuestCard Concierge => new(nameof(Concierge), GuestCategory.Merchants, RankType.Two,
        AmountOfMoneyInPocket.Eighteen, BuildItemType.RoomService);

    /// <summary>
    /// بقال
    /// </summary>
    public static GuestCard Grocer => new(nameof(Grocer), GuestCategory.Merchants, RankType.Three,
        AmountOfMoneyInPocket.TwentySix, BuildItemType.Grocery);

    /// <summary>
    /// فروشنده
    /// </summary>
    public static GuestCard Shopkeeper => new(nameof(Shopkeeper), GuestCategory.Merchants, RankType.Three,
        AmountOfMoneyInPocket.TwentySix, BuildItemType.Shop);

    /// <summary>
    /// قهوه چی
    /// </summary>
    public static GuestCard Brewer => new(nameof(Brewer), GuestCategory.Merchants, RankType.Three,
        AmountOfMoneyInPocket.TwentySix, BuildItemType.Brewery);

    #endregion

    #region Religious

    /// <summary>
    /// محصل
    /// </summary>
    public static GuestCard Novice => new(nameof(Novice), GuestCategory.Religious, RankType.Zero,
        AmountOfMoneyInPocket.Eight, BuildItemType.Alter);

    /// <summary>
    /// راهب
    /// </summary>
    public static GuestCard Monk => new(nameof(Monk), GuestCategory.Religious, RankType.One,
        AmountOfMoneyInPocket.Twelve, BuildItemType.Bedroom);

    /// <summary>
    /// راهب بزرگ
    /// </summary>
    public static GuestCard Abbot => new(nameof(Abbot), GuestCategory.Religious, RankType.Two,
        AmountOfMoneyInPocket.Eighteen, BuildItemType.Cellar);

    /// <summary>
    /// کشیش
    /// </summary>
    public static GuestCard Priest => new(nameof(Priest), GuestCategory.Religious, RankType.Three,
        AmountOfMoneyInPocket.TwentySix, BuildItemType.Cellar);

    /// <summary>
    /// اسقف اعظم
    /// </summary>
    public static GuestCard Archbishop => new(nameof(Archbishop), GuestCategory.Religious, RankType.Three,
        AmountOfMoneyInPocket.TwentySix, BuildItemType.Crypt);

    /// <summary>
    /// اسقف
    /// </summary>
    public static GuestCard Bishop => new(nameof(Bishop), GuestCategory.Religious, RankType.Three,
        AmountOfMoneyInPocket.TwentySix, BuildItemType.Bishopric);

    #endregion

    #region Nobles

    /// <summary>
    /// نجیب زاده
    /// </summary>
    public static GuestCard Baron => new(nameof(Baron), GuestCategory.Nobles, RankType.Zero,
        AmountOfMoneyInPocket.Eight, BuildItemType.GrandChandelier);

    /// <summary>
    /// تاجر
    /// </summary>
    public static GuestCard Viscount => new(nameof(Viscount), GuestCategory.Nobles, RankType.One,
        AmountOfMoneyInPocket.Twelve, BuildItemType.KingSizeBed);

    /// <summary>
    /// کنت
    /// </summary>
    public static GuestCard Count => new(nameof(Count), GuestCategory.Nobles, RankType.Two,
        AmountOfMoneyInPocket.Eighteen, BuildItemType.DiningRoom);

    /// <summary>
    /// دوک
    /// </summary>
    public static GuestCard Duke => new(nameof(Duke), GuestCategory.Nobles, RankType.Three,
        AmountOfMoneyInPocket.TwentySix, BuildItemType.Stables);

    /// <summary>
    /// شاهزاده
    /// </summary>
    public static GuestCard Prince => new(nameof(Prince), GuestCategory.Nobles, RankType.Three,
        AmountOfMoneyInPocket.TwentySix, BuildItemType.GreenHouse);

    /// <summary>
    /// اشراف زاده
    /// </summary>
    public static GuestCard Marquis => new(nameof(Marquis), GuestCategory.Nobles, RankType.Three,
        AmountOfMoneyInPocket.TwentySix, BuildItemType.Pavilion);

    #endregion

    #region Polices

    /// <summary>
    /// کلانتر
    /// </summary>
    public static GuestCard Sheriff => new(nameof(Sheriff), GuestCategory.Polices, RankType.Zero,
        AmountOfMoneyInPocket.Eight, BuildItemType.None);

    /// <summary>
    /// سروان
    /// </summary>
    public static GuestCard Brigadier => new(nameof(Brigadier), GuestCategory.Polices, RankType.One,
        AmountOfMoneyInPocket.Twelve, BuildItemType.None);

    /// <summary>
    /// سرگرد
    /// </summary>
    public static GuestCard BrigadierChief => new(nameof(BrigadierChief), GuestCategory.Polices, RankType.Two,
        AmountOfMoneyInPocket.Eighteen, BuildItemType.None);

    /// <summary>
    /// سرهنگ
    /// </summary>
    public static GuestCard Major => new(nameof(Major), GuestCategory.Polices, RankType.Three,
        AmountOfMoneyInPocket.TwentySix, BuildItemType.None);

    #endregion
}