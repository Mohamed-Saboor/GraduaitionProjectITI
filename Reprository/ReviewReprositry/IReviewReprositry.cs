using GraduaitionProjectITI.Models.Entity;
using GraduaitionProjectITI.ViewModel;

namespace GraduaitionProjectITI.Reprository.ReviewReprositry
{
    public interface IReviewReprositry
    {
        List<ReviewProductNameAndNoFReviewViewModel> GetAllProductThatHaveRevies();
        List<GetReviewsViewModel> GetReviewsOnSpecificProduct(int ProductId);
    }
}
