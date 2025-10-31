// Fayl: AzAgroPOS.Mentiq/DTOs/EmekHaqqiDto.cs
namespace AzAgroPOS.Mentiq.DTOs;

using AzAgroPOS.Varliglar;
using System;

/// <summary>
/// Əmək haqqı hesablamaları üçün məlumatları daşıyan DTO.
/// </summary>
public class EmekHaqqiDto
{
    /// <summary>
    /// Əmək haqqı qeydinin unikal identifikatoru.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// İşçinin ID-si.
    /// </summary>
    public int IsciId { get; set; }

    /// <summary>
    /// İşçinin tam adı.
    /// </summary>
    public string IsciAdi { get; set; } = string.Empty;

    /// <summary>
    /// Əmək haqqı dövrü (məsələn, "2025 Yanvar").
    /// </summary>
    public string Dovr { get; set; } = string.Empty;

    /// <summary>
    /// Əmək haqqının hesablanma tarixi.
    /// </summary>
    public DateTime HesablanmaTarixi { get; set; } = DateTime.Now;

    /// <summary>
    /// Əsas maaş (sabit).
    /// </summary>
    public decimal EsasMaas { get; set; }

    /// <summary>
    /// Bonus və mükafatlar (performans əsasında).
    /// </summary>
    public decimal Bonuslar { get; set; } = 0;

    /// <summary>
    /// Əlavə ödənişlər (gecə növbələri, həftəsonu işi və s.).
    /// </summary>
    public decimal ElaveOdenisler { get; set; } = 0;

    /// <summary>
    /// İcazə günlərinə görə tutulmalar.
    /// </summary>
    public decimal IcazeTutulmasi { get; set; } = 0;

    /// <summary>
    /// Digər tutulmalar (cərimələr, avanslar və s.).
    /// </summary>
    public decimal DigerTutulmalar { get; set; } = 0;

    /// <summary>
    /// Yekun əmək haqqı = Əsas Maaş + Bonuslar + Əlavə Ödənişlər - İcazə Tutulması - Digər Tutulmalar.
    /// </summary>
    public decimal YekunEmekHaqqi => EsasMaas + Bonuslar + ElaveOdenisler - IcazeTutulmasi - DigerTutulmalar;

    /// <summary>
    /// Əmək haqqının ödənilməsi tarixi.
    /// </summary>
    public DateTime? OdenisTarixi { get; set; }

    /// <summary>
    /// Əmək haqqının statusu.
    /// </summary>
    public EmekHaqqiStatusu Status { get; set; } = EmekHaqqiStatusu.Hesablanmis;

    /// <summary>
    /// Əlavə qeydlər.
    /// </summary>
    public string? Qeyd { get; set; }
}
