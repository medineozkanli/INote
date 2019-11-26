using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INote.API.Models
{
    [Table("Notes")]
    public class Note
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey("Author")]
        public string AuthorId { get; set; } //yazar
        [Required]
        [StringLength(100)]
        public string Title { get; set; } //başlık

        public string Content { get; set; } //yazı

        [Required]
        public DateTime? CreatedTime { get; set; } //oluşturulduğu zaman

        public DateTime? ModifiedTime { get; set; } // güncellendiği zaman

        public ApplicationUser Author { get; set; } //başta sadece ıd ve bu satır vardı AuthorIdyi koymadık ama otomatik veritabanında ilişki oluştu.EF gelenek bazlı oluşturdu.
    }
}