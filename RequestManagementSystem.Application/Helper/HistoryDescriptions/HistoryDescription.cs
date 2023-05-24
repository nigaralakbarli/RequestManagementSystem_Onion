using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestManagementSystem.Application.Helper.HistoryDescriptions;

public class HistoryDescription
{
    public const string
    open = "Yeni sorğu yaratdı",
    inExecution = "Sorğunu öz üzərinə götürdü",
    waiting = "Sorğunu gözləməyə qoydu",
    close = "Sorğunu qapatdı";
}
