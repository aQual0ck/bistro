//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace bistro.important
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cooking
    {
        public int Id { get; set; }
        public Nullable<int> Id_Dish { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    
        public virtual Dish Dish { get; set; }
    }
}