using ArifOmer.BlogApp.Business.Abstract;
using ArifOmer.BlogApp.DataAccess.Abstract;
using ArifOmer.BlogApp.Entities.Concrete;

namespace ArifOmer.BlogApp.Business.Concrete
{
    public class CommentManager : GenericManager<Comment>, ICommentService
    {
        private readonly IGenericDal<Comment> _genericDal;

        public CommentManager(IGenericDal<Comment> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
        }
    }
}
