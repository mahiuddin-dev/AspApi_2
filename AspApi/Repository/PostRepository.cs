using AspApi.Context;
using AspApi.Interfaces.Repository;
using AspApi.Models;
using EF.Core.Repository.Repository;
using Microsoft.EntityFrameworkCore;

namespace AspApi.Repository
{
    public class PostRepository : CommonRepository<Post>, iPostRepository
    {
        public PostRepository(ApplicationDBContext dbContext) : base(dbContext) { }
    }
}
