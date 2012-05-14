using System;
using System.Collections.Generic;
using Sce.Pss.Core;
using Sce.Pss.Core.Imaging;
using Sce.Pss.Core.Environment;
using Sce.Pss.HighLevel.UI;

namespace PSVReaderUI
{
    public partial class DownloadUI : Dialog
    {
        public DownloadUI()
            : base(null, null)
        {
            InitializeWidget();
        }
    }
}
