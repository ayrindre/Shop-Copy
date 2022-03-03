using System;
using System.Collections.Generic;
using AutoMapper;
using core.Domain;
using core.Repository;
using infrastructure.Data.Context;
using infrastructure.Data.Entities;
using System.Linq;

namespace infrastructure.Repository
{
    public class RSize : ISize
    {
        private readonly IMapper iMap;
        private readonly Context context;
        public RSize(Context Context, IMapper IMap)
        {
            context = Context;
            iMap = IMap;
        }

        public bool AddSize(MSize Size)
        {
            var c= iMap.Map<Size>(Size);
            // Size c = new Size()
            // {
            //    Size=Size.Size
            // };
            context.Sizes.Add(c);
            context.SaveChanges();
            return true;
        }

        public bool DeleteSize(int id)
        {
            var select = context.Sizes.SingleOrDefault(u => u.Id == id);
            if (select != null)
            {
                context.Sizes.Remove(select);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<MSize> ShowSizeProduct()
        {
            var select = context.Sizes.ToList();
            if (select != null)
            {
                List<MSize> Size = new List<MSize>();
                foreach (var item in select)
                {
                    MSize c = new MSize()
                    {
                        Id=item.Id,
                        Size = item.size,
                        IdProduct=item.IdProduct
                    };
                    Size.Add(c);
                }
                return Size;
            }
            else
            {
                return null;
            }
        }

        public bool UpdateSize(MSize Size)
        {
           var Select = context.Sizes.SingleOrDefault(c=>c.Id==Size.Id);
            if (Select!=null)
            {
                Select.size = Size.Size;
                Select.IdProduct=Size.IdProduct;

                context.Update(Select);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}