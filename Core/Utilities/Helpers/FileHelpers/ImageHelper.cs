using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelpers
{
    public class ImageHelper : IFileHelper
    {
        public  IResult Delete(string path)
        {
            throw new NotImplementedException();
        }

        public IResult Upload(string fileName, IFormFile file)
        {
            var imageName = fileName + Path.GetExtension(file.FileName);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/CarImages/" + imageName);
            var stream = new FileStream(path, FileMode.Create);
            file.CopyTo(stream);
            return new SuccessResult();
        }
    }
}
