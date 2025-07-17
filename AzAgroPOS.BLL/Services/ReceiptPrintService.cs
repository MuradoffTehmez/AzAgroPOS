using System;
using System.Drawing;
using System.Drawing.Printing;
using AzAgroPOS.BLL.Interfaces;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace AzAgroPOS.BLL.Services
{
    public class ReceiptPrintService : IDisposable
    {
        private const string DEFAULT_PRINTER_NAME = "Zebra";
        private readonly string _printerName;
        private readonly bool _isZebraPrinter;
        private Font _printFont;
        private bool _disposed = false;

        public ReceiptPrintService(string printerName = null)
        {
            _printerName = printerName ?? DEFAULT_PRINTER_NAME;
            _isZebraPrinter = _printerName.ToLower().Contains("zebra");
            _printFont = new Font("Courier New", 8); // Initialize font once
        }

        public void PrintReceipt(string receiptContent)
        {
            if (string.IsNullOrWhiteSpace(receiptContent))
                throw new ArgumentException("Receipt content cannot be empty", nameof(receiptContent));

            if (_isZebraPrinter)
            {
                PrintWithZebraPrinter(receiptContent);
            }
            else
            {
                PrintWithStandardPrinter(receiptContent);
            }
        }

        private void PrintWithZebraPrinter(string content)
        {
            try
            {
                string zplContent = ConvertToZPL(content);

                if (!SendStringToPrinter(_printerName, zplContent))
                {
                    // Fallback to standard printing
                    PrintWithStandardPrinter(content);
                }
            }
            catch (Exception ex)
            {
                throw new PrinterException($"Zebra printer error: {ex.Message}", ex);
            }
        }

        private void PrintWithStandardPrinter(string content)
        {
            try
            {
                using (var printDoc = new PrintDocument())
                {
                    printDoc.PrinterSettings.PrinterName = _printerName;

                    if (!printDoc.PrinterSettings.IsValid)
                    {
                        printDoc.PrinterSettings.PrinterName = "";
                    }

                    printDoc.DefaultPageSettings.PaperSize = new PaperSize("Receipt", 300, 600);
                    printDoc.DefaultPageSettings.Margins = new Margins(10, 10, 10, 10);

                    printDoc.PrintPage += (sender, e) => PrintReceiptPage(sender, e, content);
                    printDoc.Print();
                }
            }
            catch (Exception ex)
            {
                throw new PrinterException($"Printing error: {ex.Message}", ex);
            }
        }

        private void PrintReceiptPage(object sender, PrintPageEventArgs e, string content)
        {
            float yPos = e.MarginBounds.Top;
            float leftMargin = e.MarginBounds.Left;
            string[] lines = content.Split('\n');

            foreach (string line in lines)
            {
                e.Graphics.DrawString(line, _printFont, Brushes.Black, leftMargin, yPos);
                yPos += _printFont.GetHeight(e.Graphics);
            }

            e.HasMorePages = false;
        }

        private string ConvertToZPL(string content)
        {
            var zpl = new StringBuilder();

            // ZPL header
            zpl.AppendLine("^XA"); // Start of label
            zpl.AppendLine("^CFO,30"); // Default font

            string[] lines = content.Split('\n');
            int yPosition = 50;

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    yPosition += 20;
                    continue;
                }

                // Handle different formatting
                if (line.Contains("="))
                {
                    // Header or separator line
                    zpl.AppendLine($"^FO50,{yPosition}^A0N,25,25^FD{line}^FS");
                    yPosition += 35;
                }
                else if (line.Trim().StartsWith("AzAgro POS"))
                {
                    // Title
                    zpl.AppendLine($"^FO80,{yPosition}^A0N,30,30^FD{line.Trim()}^FS");
                    yPosition += 40;
                }
                else if (line.Contains("NET:") || line.Contains("TOPLAM:"))
                {
                    // Important totals
                    zpl.AppendLine($"^FO50,{yPosition}^A0N,25,25^FD{line.Trim()}^FS");
                    yPosition += 35;
                }
                else
                {
                    // Regular content
                    zpl.AppendLine($"^FO50,{yPosition}^A0N,20,20^FD{line.Trim()}^FS");
                    yPosition += 25;
                }
            }

            // ZPL footer
            zpl.AppendLine("^XZ"); // End of label

            return zpl.ToString();
        }

        public void PrintBarcode(string barcodeData, string printerName = null)
        {
            if (string.IsNullOrWhiteSpace(barcodeData))
                throw new ArgumentException("Barcode data cannot be empty", nameof(barcodeData));

            string printer = printerName ?? _printerName;

            if (_isZebraPrinter)
            {
                var zpl = new StringBuilder();
                zpl.AppendLine("^XA");
                zpl.AppendLine("^FO100,100");
                zpl.AppendLine($"^BCN,100,Y,N,N^FD{barcodeData}^FS");
                zpl.AppendLine("^XZ");

                if (!SendStringToPrinter(printer, zpl.ToString()))
                {
                    throw new PrinterException("Failed to print barcode");
                }
            }
            else
            {
                throw new NotSupportedException("Barcode printing is only supported with Zebra printers");
            }
        }

        public static string[] GetAvailablePrinters()
        {
            var printers = new string[PrinterSettings.InstalledPrinters.Count];
            PrinterSettings.InstalledPrinters.CopyTo(printers, 0);
            return printers;
        }

        public static bool IsPrinterOnline(string printerName)
        {
            try
            {
                using (var printDoc = new PrintDocument())
                {
                    printDoc.PrinterSettings.PrinterName = printerName;
                    return printDoc.PrinterSettings.IsValid;
                }
            }
            catch
            {
                return false;
            }
        }

        #region Native Printer Methods

        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

        [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        private class DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPStr)] public string pDocName;
            [MarshalAs(UnmanagedType.LPStr)] public string pOutputFile;
            [MarshalAs(UnmanagedType.LPStr)] public string pDataType;
        }

        private static bool SendStringToPrinter(string szPrinterName, string szString)
        {
            IntPtr pBytes = Marshal.StringToCoTaskMemAnsi(szString);
            try
            {
                return SendBytesToPrinter(szPrinterName, pBytes, szString.Length);
            }
            finally
            {
                Marshal.FreeCoTaskMem(pBytes);
            }
        }

        private static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
        {
            IntPtr hPrinter = IntPtr.Zero;
            var di = new DOCINFOA { pDocName = "Receipt", pDataType = "RAW" };

            try
            {
                if (!OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
                    return false;

                if (!StartDocPrinter(hPrinter, 1, di))
                    return false;

                if (!StartPagePrinter(hPrinter))
                    return false;

                bool success = WritePrinter(hPrinter, pBytes, dwCount, out _);
                EndPagePrinter(hPrinter);
                EndDocPrinter(hPrinter);

                return success;
            }
            finally
            {
                if (hPrinter != IntPtr.Zero)
                    ClosePrinter(hPrinter);
            }
        }

        #endregion

        #region IDisposable Implementation

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _printFont?.Dispose();
                }
                _disposed = true;
            }
        }

        ~ReceiptPrintService()
        {
            Dispose(false);
        }

        #endregion
    }

    public class PrinterException : Exception
    {
        public PrinterException(string message) : base(message) { }
        public PrinterException(string message, Exception innerException) : base(message, innerException) { }
    }
}