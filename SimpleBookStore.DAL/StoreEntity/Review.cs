using SimpleBookStore.DAL.CommonEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBookStore.DAL.StoreEntity
{
    public class Review : DbEntity, IStoreEntity
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public string UID { get; set; }  
        public User User { get; set; }

        [ForeignKey("Book")]
        public int BID { get; set; }     
        public Book Book { get; set; }
        public int Rating { get; set; }

        [MaxLength(1000)]
        public string Comment { get; set; }
    }
}
