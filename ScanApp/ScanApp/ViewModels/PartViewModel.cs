using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScanApp.ViewModels
{
    public partial class PartViewModel : ObservableObject
    {
        public ScanTextViewModel PartNo { get; set; } = new();
        public ScanTextViewModel SerialNo { get; set; } = new();

    }
}
