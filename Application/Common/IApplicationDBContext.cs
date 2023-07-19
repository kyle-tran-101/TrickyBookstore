using Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common;
public interface IApplicationDBContext
{
    DbSet<AppSetting> AppSettings { get; set; }
    Task<int> SaveChangesAsync();
}

