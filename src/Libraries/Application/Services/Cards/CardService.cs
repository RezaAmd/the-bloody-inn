using TheBloodyInn.Domain.Common.Defaults.Guests;
using TheBloodyInn.Domain.Entities.Guests;

namespace TheBloodyInn.Application.Services.Cards;

public class CardService : ICardService
{
    public List<GuestEntity> GetAllGuestPatterns()
    {
        List<GuestEntity> guestList = new();

        #region Artisans

        guestList.AddRange(new[]
        {
            GuestCardDefaults.Cultivator,
            GuestCardDefaults.Cultivator,
            GuestCardDefaults.Cultivator,
            GuestCardDefaults.Cultivator,

            GuestCardDefaults.Mechanic,
            GuestCardDefaults.Mechanic,
            GuestCardDefaults.Mechanic,
            GuestCardDefaults.Mechanic,

            GuestCardDefaults.Distiller,
            GuestCardDefaults.Distiller,
            GuestCardDefaults.Distiller,

            GuestCardDefaults.Gardener,
            GuestCardDefaults.Landscaper,
            GuestCardDefaults.Butcher
        });

        #endregion

        #region Merchants

        guestList.AddRange(new[]
        {
            GuestCardDefaults.NewsBoy,
            GuestCardDefaults.NewsBoy,
            GuestCardDefaults.NewsBoy,
            GuestCardDefaults.NewsBoy,

            GuestCardDefaults.Representative,
            GuestCardDefaults.Representative,
            GuestCardDefaults.Representative,
            GuestCardDefaults.Representative,

            GuestCardDefaults.Concierge,
            GuestCardDefaults.Concierge,
            GuestCardDefaults.Concierge,

            GuestCardDefaults.Grocer,
            GuestCardDefaults.Shopkeeper,
            GuestCardDefaults.Brewer
        });

        #endregion

        #region Religious

        guestList.AddRange(new[]
        {
            GuestCardDefaults.Novice,
            GuestCardDefaults.Novice,
            GuestCardDefaults.Novice,
            GuestCardDefaults.Novice,

            GuestCardDefaults.Monk,
            GuestCardDefaults.Monk,
            GuestCardDefaults.Monk,
            GuestCardDefaults.Monk,

            GuestCardDefaults.Abbot,
            GuestCardDefaults.Abbot,
            GuestCardDefaults.Abbot,

            GuestCardDefaults.Priest,
            GuestCardDefaults.Archbishop,
            GuestCardDefaults.Bishop
        });

        #endregion

        #region Nobles

        guestList.AddRange(new[]
        {
            GuestCardDefaults.Baron,
            GuestCardDefaults.Baron,
            GuestCardDefaults.Baron,
            GuestCardDefaults.Baron,

            GuestCardDefaults.Viscount,
            GuestCardDefaults.Viscount,
            GuestCardDefaults.Viscount,
            GuestCardDefaults.Viscount,

            GuestCardDefaults.Count,
            GuestCardDefaults.Count,
            GuestCardDefaults.Count,

            GuestCardDefaults.Duke,
            GuestCardDefaults.Prince,
            GuestCardDefaults.Marquis
        });

        #endregion

        #region Polices

        guestList.AddRange(new[]
        {
            GuestCardDefaults.Sheriff,
            GuestCardDefaults.Sheriff,
            GuestCardDefaults.Sheriff,
            GuestCardDefaults.Sheriff,

            GuestCardDefaults.Brigadier,
            GuestCardDefaults.Brigadier,
            GuestCardDefaults.Brigadier,
            GuestCardDefaults.Brigadier,

            GuestCardDefaults.BrigadierChief,
            GuestCardDefaults.BrigadierChief,
            GuestCardDefaults.BrigadierChief,

            GuestCardDefaults.Major,
            GuestCardDefaults.Major,
            GuestCardDefaults.Major
        });

        #endregion

        return guestList;
    }
}