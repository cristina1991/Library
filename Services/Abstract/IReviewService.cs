using Library.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IReviewService
    {
        void AddReview(Review review);
        void DeleteReview(Review review);
        ICollection<Review> GetAllReviewsByBookId(int bookId);
    }
}
