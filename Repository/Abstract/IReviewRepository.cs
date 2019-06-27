using Library.Data.Entities;
using System.Collections.Generic;

namespace Repository.Abstract
{
    public interface IReviewRepository
    {
        void AddReview(Review review);
        ICollection<Review> GetAllReviewsByBookId(int bookId);
        void Save();
    }
}
