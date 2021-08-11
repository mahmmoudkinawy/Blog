using BlogAPI.Models.BlogComment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogAPI.Repository
{
    public interface IBlogCommentRepository
    {
        Task<BlogComment> UpsertAsync(BlogCommentCreate blogCommentCreate, int applicationUserId);
        Task<List<BlogComment>> GetAllAsync(int blogId);
        Task<BlogComment> GetAsync(int blogCommentId);
        Task<int> DeleteAsync(int blogCommentId);
    }
}
