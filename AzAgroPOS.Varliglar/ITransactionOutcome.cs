namespace AzAgroPOS.Varliglar;

/// <summary>
/// Tranzaksiya daxilində biznes nəticəsi uğursuz olduqda verilənləri geri almaq üçün işarə.
/// </summary>
public interface ITransactionOutcome
{
    bool UgurluDur { get; }
}
