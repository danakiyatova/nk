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
    
    public partial class ClientList
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public System.DateTime Date { get; set; }
        public string Service { get; set; }
        public decimal Price { get; set; }
        public int ClientId { get; set; }
        public int MasterId { get; set; }
        public int ServiceId { get; set; }
        public int UserId { get; set; }
        public int Id { get; set; }
    }
}