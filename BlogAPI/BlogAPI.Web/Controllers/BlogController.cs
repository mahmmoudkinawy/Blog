using BlogAPI.Models.Blog;
using BlogAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.Web.Controllers
{
    public class BlogController : BaseApiController
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IPhotoRepository _photoRepository;

        public BlogController(IBlogRepository blogRepository, IPhotoRepository photoRepository)
        {
            _blogRepository = blogRepository ??
                throw new ArgumentNullException(nameof(blogRepository));
            _photoRepository = photoRepository ??
                throw new ArgumentNullException(nameof(photoRepository));
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Blog>> Create(BlogCreate blogCreate)
        {
            int applicationUserId = int.Parse(User.Claims.First(i => i.Type == JwtRegisteredClaimNames.NameId).Value);

            if (blogCreate.PhotoId.HasValue)
            {
                var photo = await _photoRepository.GetAsync(blogCreate.PhotoId.Value);

                if (photo.ApplicationUserId != applicationUserId)
                    return BadRequest("You did not upload the photo.");
            }

            var blog = await _blogRepository.UpsertAsync(blogCreate, applicationUserId);

            return Ok(blog);
        }

        [HttpGet]
        public async Task<ActionResult<PagedResults<Blog>>> GetAll([FromQuery] BlogPaging blogPaging)
        {
            var blogs = await _blogRepository.GetAllAsync(blogPaging);

            if (blogs == null)
                return BadRequest();

            return Ok(blogs);
        }

        [HttpGet]
        [Route("{blogId}")]
        public async Task<ActionResult<Blog>> Get(int blogId)
        {
            var blog = await _blogRepository.GetAsync(blogId);

            if (blog == null)
                return NotFound();

            return Ok(blog);
        }

        [HttpGet]
        [Route("user/{applicationUserId}")]
        public async Task<ActionResult<List<Blog>>> GetByApplicationUserId(int applicationUserId)
        {
            var blogs = await _blogRepository.GetAllByUserIdAsync(applicationUserId);

            if (blogs == null)
                return NotFound();

            return Ok(blogs);
        }

        [HttpGet]
        [Route("famous")]
        public async Task<ActionResult<List<Blog>>> GetAllFamous()
        {
            var blogs = await _blogRepository.GetAllFamousAsync();

            if (blogs == null)
                return NotFound();

            return Ok(blogs);
        }

        [Authorize]
        [HttpDelete]
        [Route("{blogId}")]
        public async Task<ActionResult<int>> Delete(int blogId)
        {
            int applicationUserId = int.Parse(User.Claims.First(i => i.Type == JwtRegisteredClaimNames.NameId).Value);

            var foundBlog = await _blogRepository.GetAsync(blogId);

            if (foundBlog == null)
                return BadRequest("Blog does not exist.");

            if (foundBlog.ApplicationUserId == applicationUserId)
            {
                var affectedRows = await _blogRepository.DeleteAsync(blogId);

                return Ok(affectedRows);
            }
            else
                return BadRequest("You didn't create this blog.");

        }

    }
}
