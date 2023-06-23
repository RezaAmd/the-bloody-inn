using TheBloodyInn.Domain.Common.Defaults.Guests;
using TheBloodyInn.Domain.Enum.Cards;
using TheBloodyInn.Domain.Enum.Guests;

namespace TheBloodyInn.Framework.Utilities.Cards;

public static class CardHelper
{
    public static string GetTextColorClassByCategory(GuestCategory category)
    {
        switch (category)
        {
            case GuestCategory.Artisans:
                return "text-danger";
            case GuestCategory.Merchants:
                return "text-primary";
            case GuestCategory.Religious:
                return "text-purple";
            case GuestCategory.Nobles:
                return "text-success";
            case GuestCategory.Polices:
                return "text-secondary";
            default:
                return "";
        }
    }

    public static string GetBgColorClassByCategory(GuestCategory category)
    {
        switch (category)
        {
            case GuestCategory.Artisans:
                return "bg-danger-subtle";
            case GuestCategory.Merchants:
                return "bg-primary-subtle";
            case GuestCategory.Religious:
                return "bg-purple-subtle";
            case GuestCategory.Nobles:
                return "bg-success-subtle";
            case GuestCategory.Polices:
                return "bg-secondary-subtle";
            default:
                return "";
        }
    }
    
    public static string GetIconClassByCategory(GuestCategory category)
    {
        switch (category)
        {
            case GuestCategory.Artisans:
                return "far fa-digging";
            case GuestCategory.Merchants:
                return "far fa-money-bill";
            case GuestCategory.Religious:
                return "far fa-cross";
            case GuestCategory.Nobles:
                return "";
            case GuestCategory.Polices:
                return "far fa-crosshairs";
            default:
                return "";
        }
    }
    
    public static string GetNameByBuildItem(BuildItemType buildItem)
    {
        switch (buildItem)
        {
            case BuildItemType.VegetableGarden:
                return "مزرعه";
            case BuildItemType.Workshop:
                return "کارگاه";
            case BuildItemType.Distillery:
                return "آشپزخانه";
            case BuildItemType.Gardens:
                return "باغ";
            case BuildItemType.ButcherShop:
                return "قصابی";
            case BuildItemType.Park:
                return "پارک";
            default:
                return "";
        }
    }
    
    public static string GetNameBySystemName(string systemName)
    {
        switch (systemName)
        {
            #region Artisans
            case nameof(GuestCardDefaults.Cultivator):
                return "کشاورز";
            case nameof(GuestCardDefaults.Mechanic):
                return "مکانیک";
            case nameof(GuestCardDefaults.Distiller):
                return "آشپز";
            case nameof(GuestCardDefaults.Gardener):
                return "باغبان";
            case nameof(GuestCardDefaults.Landscaper):
            case "":
                return "معمار";
            case nameof(GuestCardDefaults.Butcher):
                return "قصاب";
            #endregion

            #region Merchants
            case nameof(GuestCardDefaults.NewsBoy):
                return "روزنامه فروش";
            case nameof(GuestCardDefaults.Representative):
                return "نماینده";
            case nameof(GuestCardDefaults.Concierge):
                return "سرایدار";
            case nameof(GuestCardDefaults.Grocer):
                return "بقال";
            case nameof(GuestCardDefaults.Shopkeeper):
                return "فروشنده";
            case nameof(GuestCardDefaults.Brewer):
                return "قهوه چی";
            #endregion

            #region Religious
            case nameof(GuestCardDefaults.Novice):
                return "محصل";
            case nameof(GuestCardDefaults.Monk):
                return "راهب";
            case nameof(GuestCardDefaults.Abbot):
                return "راهب بزرگ";
            case nameof(GuestCardDefaults.Priest):
                return "کشیش";
            case nameof(GuestCardDefaults.Archbishop):
                return "اسقف اعظم";
            case nameof(GuestCardDefaults.Bishop):
                return "اسقف";
            #endregion

            #region Nobles
            case nameof(GuestCardDefaults.Baron):
                return "نجیب زاده";
            case nameof(GuestCardDefaults.Viscount):
                return "تاجر";
            case nameof(GuestCardDefaults.Count):
                return "کنت";
            case nameof(GuestCardDefaults.Duke):
                return "دوک";
            case nameof(GuestCardDefaults.Prince):
                return "شاهزاده";
            case nameof(GuestCardDefaults.Marquis):
                return "اشراف زاده";
            #endregion

            #region Polices
            case nameof(GuestCardDefaults.Sheriff):
                return "کلانتر";
            case nameof(GuestCardDefaults.Brigadier):
                return "سروان";
            case nameof(GuestCardDefaults.BrigadierChief):
                return "سرگرد";
            case nameof(GuestCardDefaults.Major):
                return "سرهنگ";
            #endregion
            default:
                return systemName;
        }
    }

}