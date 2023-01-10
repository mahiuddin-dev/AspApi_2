using AspApi.Context;
using AspApi.Interfaces.Manager;
using AspApi.Models;
using AspApi.Repository;
using EF.Core.Repository.Interface.Repository;
using EF.Core.Repository.Manager;

namespace AspApi.Managers
{
    public class PostManager : CommonManager<Post>, iPostManager
    {
        public PostManager(ApplicationDBContext _dbContext) : base(new PostRepository(_dbContext))
        {
        }

        public Post GetById(int id)
        {
            return GetFirstOrDefault(i=> i.Id == id);
        }
    }
}
