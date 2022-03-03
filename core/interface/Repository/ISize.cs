using System;
using System.Collections.Generic;
using core.Domain;

namespace core.Repository
{
    public interface ISize
    {
        bool AddSize(MSize Size); 
        bool UpdateSize(MSize Size);
        bool DeleteSize(int id);
        List<MSize> ShowSizeProduct();
        
    }
}