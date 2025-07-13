using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace AzAgroPOS.BLL.Services
{
    public class ReceiptPrintService
    {
        private const string DEFAULT_PRINTER_NAME = "Zebra";
        private readonly string _printerName;
        private readonly bool _isZebraPrinter;
        
        public ReceiptPrintService(string printerName = null)
        {
            _printerName = printerName ?? DEFAULT_PRINTER_NAME;
            _isZebraPrinter = _printerName.ToLower().Contains("zebra");
        }

        public void PrintReceipt(string receiptContent)
        {
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
                // Convert to ZPL (Zebra Programming Language) format
                string zplContent = ConvertToZPL(content);
                
                // Send ZPL directly to printer
                if (SendStringToPrinter(_printerName, zplContent))
                {
                    Console.WriteLine("Zebra printer ilə çap uğurla tamamlandı");
                }
                else
                {
                    // Fallback to standard printing
                    PrintWithStandardPrinter(content);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Zebra printer xətası: {ex.Message}");
                // Fallback to standard printing
                PrintWithStandardPrinter(content);
            }
        }

        private void PrintWithStandardPrinter(string content)
        {
            try
            {
                PrintDocument printDoc = new PrintDocument();
                printDoc.PrinterSettings.PrinterName = _printerName;
                
                // If printer not found, use default printer
                if (!printDoc.PrinterSettings.IsValid)
                {
                    printDoc.PrinterSettings.PrinterName = "";
                }

                printDoc.DefaultPageSettings.PaperSize = new PaperSize("Receipt", 300, 600);
                printDoc.DefaultPageSettings.Margins = new Margins(10, 10, 10, 10);
                
                printDoc.PrintPage += (sender, e) => PrintReceiptPage(sender, e, content);
                printDoc.Print();
            }
            catch (Exception ex)
            {
                throw new Exception($"Çap xətası: {ex.Message}");
            }
        }

        private void PrintReceiptPage(object sender, PrintPageEventArgs e, string content)
        {
            Font printFont = new Font("Courier New", 8);
            float yPos = 0;
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;
            string[] lines = content.Split('\n');

            foreach (string line in lines)
            {
                yPos = topMargin + (Array.IndexOf(lines, line) * printFont.GetHeight(e.Graphics));
                e.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos);
            }

            e.HasMorePages = false;
        }

        private string ConvertToZPL(string content)
        {
            StringBuilder zpl = new StringBuilder();
            
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

        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

        [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public class DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDocName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pOutputFile;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDataType;
        }

        public static bool SendStringToPrinter(string szPrinterName, string szString)
        {
            IntPtr pBytes;
            Int32 dwCount;
            dwCount = szString.Length;
            pBytes = Marshal.StringToCoTaskMemAnsi(szString);
            
            bool result = SendBytesToPrinter(szPrinterName, pBytes, dwCount);
            Marshal.FreeCoTaskMem(pBytes);
            return result;
        }

        public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
        {
            Int32 dwError = 0, dwWritten = 0;
            IntPtr hPrinter = new IntPtr(0);
            DOCINFOA di = new DOCINFOA();
            bool bSuccess = false;

            di.pDocName = "Receipt";
            di.pDataType = "RAW";

            if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
            {
                if (StartDocPrinter(hPrinter, 1, di))
                {
                    if (StartPagePrinter(hPrinter))
                    {
                        bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                        EndPagePrinter(hPrinter);
                    }
                    EndDocPrinter(hPrinter);
                }
                ClosePrinter(hPrinter);
            }

            if (!bSuccess)
            {
                dwError = Marshal.GetLastWin32Error();
            }

            return bSuccess;
        }

        public void PrintBarcode(string barcodeData, string printerName = null)
        {
            string printer = printerName ?? _printerName;
            
            if (_isZebraPrinter)
            {
                // Generate ZPL for barcode
                StringBuilder zpl = new StringBuilder();
                zpl.AppendLine("^XA");
                zpl.AppendLine("^FO100,100");
                zpl.AppendLine($"^BCN,100,Y,N,N^FD{barcodeData}^FS");
                zpl.AppendLine("^XZ");
                
                SendStringToPrinter(printer, zpl.ToString());
            }
            else
            {
                // Standard barcode printing would require additional barcode font or component
                throw new NotSupportedException("Barcode printing is only supported with Zebra printers in this implementation");
            }
        }

        public static string[] GetAvailablePrinters()
        {
            string[] printers = new string[PrinterSettings.InstalledPrinters.Count];
            PrinterSettings.InstalledPrinters.CopyTo(printers, 0);
            return printers;
        }

        public static bool IsPrinterOnline(string printerName)
        {
            try
            {
                PrintDocument printDoc = new PrintDocument();
                printDoc.PrinterSettings.PrinterName = printerName;
                return printDoc.PrinterSettings.IsValid;
            }
            catch
            {
                return false;
            }
        }
    }
}