﻿using Core.Entities;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class WebsiteRepository : GenericRepository<Website>, IWebsiteRepository
    {
        public WebsiteRepository(IDbContext context) : base(context) { }

        public override void AddIfNew(Website item)
        {
            DbContext.Set<Website>().AddIfNotExists(item, i => i.Domain.Contains(item.Domain));
        }

        public Task<Website> FindByUrl(string url)
        {
            return DbContext.Set<Website>().Where(w => w.Domain == url).FirstOrDefaultAsync();
        }
    }
}
