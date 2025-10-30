// Fayl: AzAgroPOS.Teqdimat/Interfeysler/IXercView.cs
namespace AzAgroPOS.Teqdimat.Interfeysler;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Varliglar;
using System.ComponentModel;
using System.Windows.Forms;

namespace AzAgroPOS.Teqdimat.Interfeysler
{
    public interface IXercView
    {
        // View-dan məlumat oxumaq
        XercNovu SecilmisXercNovu { get; }
        string XercAdi { get; }
        decimal XercMeblegi { get; }
        DateTime XercTarixi { get; }
        string? XercSenedNomresi { get; }
        string? XercQeydi { get; }
        int? SecilmisXercId { get; }

        // View-a məlumat göndərmək
        void XercleriGoster(List<XercDto> xercler);
        void XercFormunuSifirla();
        void SecilmisXerciFormaYukle(XercDto xerc);
        DialogResult MesajGoster(string mesaj, string basliq, MessageBoxButtons düymələr, MessageBoxIcon ikon);

        // Hadisələr
        event EventHandler XercElaveEtIstek;
        event EventHandler XercYenileIstek;
        event EventHandler XercSilIstek;
        event EventHandler XercAxtarIstek;
        event EventHandler FormYuklendiIstek;
    }
}