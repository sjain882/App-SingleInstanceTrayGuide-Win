using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_SingleInstanceTrayGuide_Win.Infrastructure.Theming
{
    public interface IOSThemeDetector
    {
        bool IsDarkThemeEnabled();
    }
}
