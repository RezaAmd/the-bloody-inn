namespace TheBloodyInn.Domain.Enum.Guests;

public enum GuestPosittionType
{
    // در انتظار ورود
    Pending,
    // درحال ورود - اولین ورودی دست بعد
    Incoming,
    // ساکن در اتاق
    InsideTheRoom,
    // رشوه داده شده
    Assistant,
    // مستقر شد - ساکن شد
    Established,
    // کشته شد
    Dead,
    // دفن شد
    Buried,
    // دفن فوری شد
    ImmediateBurial,
    // خارج شد
    Out
}