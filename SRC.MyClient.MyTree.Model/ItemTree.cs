//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SRC.MyClient.MyTree.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class ItemTree
    {
        private string name;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ItemTree()
        {
            this.ItemTree1 = new HashSet<ItemTree>();
        }

        public int Id { get; set; }
        public string ItemName { get; set; }
        public Nullable<int> ParentId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemTree> ItemTree1 { get; set; }
        public virtual ItemTree ItemTree2 { get; set; }
    }
}
