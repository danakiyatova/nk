//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NailsApp.Model.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Master
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public Nullable<int> AccountId { get; set; }
    
        public virtual Account Account { get; set; }
        public virtual User User { get; set; }
    }
}
