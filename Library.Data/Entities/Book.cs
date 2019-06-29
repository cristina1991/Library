﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Data.Entities
{
    public class Book : IEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Introducerea unui titlu este obligatorie")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Introducerea unei edituri este obligatorie")]
        public string Publisher { get; set; }
        public string Description { get; set; }
        public int Release { get; set; }
        public decimal Rating { get; set; }
        public int Pages { get; set; }
        public string ImgPath { get; set; }
        public bool? IsFavourite { get; set; }

        public ICollection<Review> Reviews { get; set; }

        [Required(ErrorMessage ="Selectarea unei categorii este obligatorie")]
        public int GenreId { get; set; }
        [ForeignKey("GenreId")]
        public virtual Genre Genre { get; set; }

        [Required(ErrorMessage = "Selectarea unui autor este obligatorie")]
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public virtual Author Author { get; set; }
    }
}
