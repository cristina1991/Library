using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data.Entities;
using Library.Data;

namespace Repository.Concrete
{
    public class ReviewRepository : IReviewRepository
    {
        private UniLibraryDbContext db;

        public ReviewRepository(UniLibraryDbContext db)
        {
            this.db = db;
        }

        public void AddReview(Review review)
        {
            db.Reviews.Add(review);
            Save();
        }

        public void DeleteReview(Review review)
        {
            db.Reviews.Remove(review);
            Save();
        }

        public ICollection<Review> GetAllReviewsByBookId(int bookId)
        {
            return db.Reviews.Where(x => x.BookId == bookId).ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
