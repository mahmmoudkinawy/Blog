using BlogAPI.Models.Settings;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace BlogAPI.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly Cloudinary _cloudinary;

        public PhotoService(IOptions<CloudinaryOptions> config)
        {
            var account = new Account(
                config.Value.CloudName,
                config.Value.ApiKey,
                config.Value.ApiSecret);

            _cloudinary = new Cloudinary(account);
        }
        public Task<ImageUploadResult> AddPhotoAsync(IFormFile file)
        {
            throw new NotImplementedException();
        }

        public Task<DeletionResult> DeletePhotoAsync(string publicId)
        {
            throw new NotImplementedException();
        }
    }
}
