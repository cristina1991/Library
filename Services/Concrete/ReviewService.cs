using Library.Data.Entities;
using Repository.Abstract;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class ReviewService : IReviewService
    {
        private IReviewRepository reviewRepo;

        public ReviewService(IReviewRepository reviewRepo)
        {
            this.reviewRepo = reviewRepo;
        }

        public void AddReview(Review review)
        {
            reviewRepo.AddReview(review);
        }

        public ICollection<Review> GetAllReviewsByBookId(int bookId)
        {
            return reviewRepo.GetAllReviewsByBookId(bookId);
        }
    }
}
