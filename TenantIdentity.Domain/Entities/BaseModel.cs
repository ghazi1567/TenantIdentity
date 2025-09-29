using eBuildingBlocks.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenantIdentity.Domain.Entities
{
    public class BaseModel: TenantEntity<Guid>
    {
    }
}
