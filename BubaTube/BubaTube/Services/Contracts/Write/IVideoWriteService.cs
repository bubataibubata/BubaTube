﻿using BubaTube.Data.DTO;
using BubaTube.Data.Models;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace BubaTube.Services.Contracts.Write
{
    public interface IVideoWriteService
    {
        Video SaveToDatabase(VideoDTO video);

        Task SaveToRootFolder(IFormFile video, string path);
    }
}
