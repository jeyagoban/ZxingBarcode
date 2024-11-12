using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScanApp.ViewModels
{
    public class ScanResultMessage
    {
        public string ScannedData { get; }

        public Guid Token { get; }

        public bool Success { get; }

        public ScanResultMessage(string scannedData, Guid token)
        {
            ScannedData = scannedData;
            Token = token;
        }
    }
}
