using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BusinessLogic.Contract;
using BusinessLogic.Utils;
using DataModels;
using DataModels.Base;
using DataModels.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Business
{
    public class GenericBusiness<T>: BaseBusiness, IGenericBusiness<T> where T : IdBase
    {
        protected readonly DbSet<T> Entries;

        protected GenericBusiness(BkdnContext context) : base(context)
        {
            Entries = context.Set<T>();
        }
        
        public async Task<TO> GetById<TO>(int id)
        {
            return (await Entries.FindAsync(id) ?? throw new BadRequestException("Record not found")).ConvertTo<TO>();
        }
        
        public virtual async Task<List<TO>> GetAll<TO>()
        {
            return (await Entries.ToListAsync()).ConvertTo<List<TO>>();
        }
        
        public virtual async Task Update(IdBase o)
        {
            var existing = await Entries.FirstOrDefaultAsync(x=>x.Id == o.Id)?? throw new BadRequestException("Record not found");
            var updated = o.ConvertTo<T>();
            
            Context.Entry(existing).CurrentValues.SetValues(updated);

            await Context.SaveChangesAsync();
        }
        
        public virtual async Task<TO> Create<TO>(object o)
        {
            var entry = o.ConvertTo<T>();
            Context.Entry(entry).State = EntityState.Added;
            await Context.SaveChangesAsync();
            
            return entry.ConvertTo<TO>();
        }
        
        public async Task Delete(int id)
        {
            await Delete(await Entries.FirstOrDefaultAsync(x => x.Id == id));
        }
        
        public async Task Delete(T entry)
        {
            entry = entry ?? throw new BadRequestException("Record not found");
            Context.Entry(entry).State = EntityState.Deleted;
            await Context.SaveChangesAsync();
        }

        public async Task<bool> Exist(Expression<Func<T, bool>> predicate)
        {
            return await Entries.AnyAsync(predicate);
        }
    }
}