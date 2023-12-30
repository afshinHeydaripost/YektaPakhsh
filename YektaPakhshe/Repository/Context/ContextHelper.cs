﻿using DAL.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Repository.Context
{
    public static class ContextHelper
    {
        public static void DetachLocal<T>(this DbContext context, T t, int entryId) where T : class, IEntity
        {
            var local = context.Set<T>()
                .Local
                .FirstOrDefault(entry => entry.Id == entryId);
            if (local != null)
                context.Entry(local).State = EntityState.Detached;
            context.Entry(t).State = EntityState.Modified;
        }
    }
}
